using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Flos_Blog.Models;
using Microsoft.Ajax.Utilities;

namespace Flos_Blog.Controllers.API
{
    public class ApiAnalyticsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        public async Task<IHttpActionResult> GetPageVisits()
        {
            var pageVisits = await _db.PageVisits.ToListAsync();

            var pageVisitsVm = new PageVisitsViewModel
            {
                HomeVisits = pageVisits.Where(i => i.Link == "/" || i.Link == "/Home" || i.Link == "/Home/Index").Sum(i => i.Clicks),
                AboutVisits = pageVisits.Where(i => i.Link == "/About" || i.Link == "/About/Index").Sum(i => i.Clicks),
                ArchiveVisits = pageVisits.Where(i => i.Link == "/Archive" || i.Link == "/Archive/Index").Sum(i => i.Clicks),
                TimeSpentOnHome = (double) pageVisits.Where(i => i.Link == "/" || i.Link == "/Home" || i.Link == "/Home/Index").Sum(i => i.TimeSpentOnPage) /
                    pageVisits.Where(i => i.Link == "/" || i.Link == "/Home" || i.Link == "/Home/Index").Sum(i => i.Clicks),
                TimeSpentOnAbout = (double) pageVisits.Where(i => i.Link == "/About" || i.Link == "/About/Index").Average(i => i.TimeSpentOnPage) /
                    pageVisits.Where(i => i.Link == "/About" || i.Link == "/About/Index").Sum(i => i.Clicks),
                TimeSpentOnArchive = (double) pageVisits.Where(i => i.Link == "/Archive" || i.Link == "/Archive/Index").Average(i => i.TimeSpentOnPage) /
                    pageVisits.Where(i => i.Link == "/Archive" || i.Link == "/Archive/Index").Sum(i => i.Clicks)
            };

            return Ok(pageVisitsVm);
        }

        [HttpPut]
        public async Task<IHttpActionResult> SavePageVisit(PageVisitViewModel model)
        {
            var domainIndex = 0;
            if (model.Link.Contains(".net"))
            {
                domainIndex = model.Link.IndexOf(".net", StringComparison.Ordinal) + 4;
            }
            else if (model.Link.Contains(".de"))
            {
                domainIndex = model.Link.IndexOf(".de", StringComparison.Ordinal) + 3;
            }
            else if (model.Link.Contains(".blog"))
            {
                domainIndex = model.Link.IndexOf(".blog", StringComparison.Ordinal) + 5;
            }
            else
            {
                domainIndex = model.Link.IndexOf(":61145", StringComparison.Ordinal) + 6;
            }

            model.Link = model.Link.Substring(domainIndex);

            var page = await _db.PageVisits.FirstOrDefaultAsync(i => i.Link == model.Link);

            if (page == null)
            {
                return NotFound();
            }

            page.Clicks += 1;
            page.TimeSpentOnPage = model.TimeSpentOnPage;

            _db.Entry(page).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return Ok();
        }
    }
}
