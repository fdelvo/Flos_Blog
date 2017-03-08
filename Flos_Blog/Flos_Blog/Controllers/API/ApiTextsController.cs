using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Flos_Blog.Models;

namespace Flos_Blog.Controllers.API
{
    public class ApiTextsController : ApiController
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: api/ApiTexts
        public async Task<IHttpActionResult> GetTexts(int pageSize, int page)
        {
            var texts = await _db.Texts
                .OrderBy(d => d.TextDate)
                .Take(pageSize)
                .Skip(pageSize * page)
                .ToListAsync();

            var textsViewModel = new List<TextUserViewModel>();

            textsViewModel.AddRange(texts.Select(t => new TextUserViewModel
            {
                TextId = t.TextId,
                TextContent = t.TextContent,
                TextDate = t.TextDate,
                TextTitle = t.TextTitle
            }));

            return Ok(textsViewModel);
        }

        [Authorize]
        public async Task<IHttpActionResult> TextsForAdmin(int pageSize, int page)
        {
            var texts = await _db.Texts
                .OrderBy(d => d.TextDate)
                .Take(pageSize)
                .Skip(pageSize * page)
                .ToListAsync();

            var textsViewModel = new List<TextAdminViewModel>();

            textsViewModel.AddRange(texts.Select(t => new TextAdminViewModel
            {
                TextId = t.TextId,
                TextContent = t.TextContent,
                TextDate = t.TextDate,
                TextTitle = t.TextTitle,
                TextShared = t.TextShared,
                TextViews = t.TextViews,
                TextStayDuration = GetAverageTextStayDuration(t.TextId)
        }));

            return Ok(textsViewModel);
        }

        // GET: api/ApiTexts/5
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> GetText(Guid id)
        {
            Text text = await _db.Texts.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }

            await AddView(id);           

            return Ok(text);
        }

        public async Task AddView(Guid id)
        {
            var text = await _db.Texts.FirstOrDefaultAsync(i => i.TextId == id);
            text.TextViews += 1;

            _db.Entry(text).State = EntityState.Modified;


            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextExists(id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<IHttpActionResult> TextShared(Guid id)
        {
            Text text = await _db.Texts.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }

            text.TextShared += 1;

            _db.Entry(text).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        public async Task SaveTextStayDuration(Guid id, int duration)
        {
            Text text = await _db.Texts.FindAsync(id);
            if (text == null)
            {
                return;
            }

            TextStayDuration stayDuration = new TextStayDuration
            {
                StayDurationId = Guid.NewGuid(),
                Duration = duration,
                Text = text
            };

            _db.StayDurations.Add(stayDuration);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextExists(id))
                {
                    return;
                }
                else
                {
                    throw;
                }
            }
        }

        public double GetAverageTextStayDuration(Guid id)
        {
            var average = _db.TextStayDurations
                .Include(t => t.Text.TextId == id)
                .Where(t => t.Text.TextId == id)
                .Average(i => i.Duration);

            return average;
        }

        // PUT: api/ApiTexts/5
        [Authorize]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutText(Guid id, Text text)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != text.TextId)
            {
                return BadRequest();
            }

            _db.Entry(text).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ApiTexts
        [Authorize]
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> PostText(Text text)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            text.TextId = Guid.NewGuid();
            text.TextDate = DateTime.Now;

            _db.Texts.Add(text);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TextExists(text.TextId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = text.TextId }, text);
        }

        // DELETE: api/ApiTexts/5
        [Authorize]
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> DeleteText(Guid id)
        {
            Text text = await _db.Texts.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }

            _db.Texts.Remove(text);
            await _db.SaveChangesAsync();

            return Ok(text);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TextExists(Guid id)
        {
            return _db.Texts.Count(e => e.TextId == id) > 0;
        }
    }
}