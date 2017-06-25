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
                HomeVisits = pageVisits.Where(i => i.Link == "/" || i.Link == "/Home" || i.Link == "/Home/Index")
                    .Sum(i => i.Clicks),
                AboutVisits = pageVisits.Where(i => i.Link == "/About" || i.Link == "/About/Index").Sum(i => i.Clicks),
                ArchiveVisits = pageVisits.Where(i => i.Link == "/Archive" || i.Link == "/Archive/Index")
                    .Sum(i => i.Clicks),
                TimeSpentOnHome = Median(pageVisits
                                      .Where(i => i.Link == "/" || i.Link == "/Home" || i.Link == "/Home/Index")
                                      .Select(i => i.TimeSpentOnPage)
                                      .ToList()),
                TimeSpentOnAbout = Median(pageVisits
                                      .Where(i => i.Link == "/About" || i.Link == "/About/Index")
                                      .Select(i => i.TimeSpentOnPage)
                                      .ToList()),
                TimeSpentOnArchive = Median(pageVisits
                                      .Where(i => i.Link == "/Archive" || i.Link == "/Archive/Index")
                                      .Select(i => i.TimeSpentOnPage)
                                      .ToList())
            };

            return Ok(pageVisitsVm);
        }

        [HttpPost]
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
            else if (model.Link.Contains(".org"))
            {
                domainIndex = model.Link.IndexOf(".org", StringComparison.Ordinal) + 4;
            }
            else
            {
                domainIndex = model.Link.IndexOf(":61145", StringComparison.Ordinal) + 6;
            }

            model.Link = model.Link.Substring(domainIndex);

                var newPage = new PageVisit();
                newPage.PageVisitId = Guid.NewGuid();
                newPage.Link = model.Link;
                newPage.Clicks = 1;
                newPage.TimeSpentOnPage = model.TimeSpentOnPage;

            _db.PageVisits.Add(newPage);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
            }

            return Ok();
        }

        private static double Median(List<int> list)
        {
            list.Sort();
            var index = 0;
            if (list.Count % 2 != 0)
            {
                index = (list.Count + 1) / 2;
                return list[index-1];
            }

            return (list[((list.Count / 2)-1)] + list[(list.Count / 2)])/2;
        }
    }
}