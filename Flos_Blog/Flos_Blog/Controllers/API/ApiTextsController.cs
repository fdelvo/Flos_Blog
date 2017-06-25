using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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
                .Where(p => p.TextPublished)
                .OrderByDescending(d => d.TextPublishDate)
                .Skip(pageSize * page)
                .Take(pageSize)
                .ToListAsync();

            var textsViewModel = new List<TextUserViewModel>();

            textsViewModel.AddRange(texts.Select(t => new TextUserViewModel
            {
                TextId = t.TextId,
                TextContent = t.TextContent,
                TextPublishDate = t.TextPublishDate,
                TextDate = t.TextDate,
                TextTitle = t.TextTitle
            }));

            return Ok(textsViewModel);
        }

        public async Task<IHttpActionResult> GetTextsByMonth(int month, int year)
        {
            var texts = await _db.Texts
                .Where(p => p.TextPublished && p.TextPublishDate.Month == month && p.TextPublishDate.Year == year)
                .OrderByDescending(d => d.TextPublishDate)
                .ToListAsync();

            var textsViewModel = new List<TextUserViewModel>();

            textsViewModel.AddRange(texts.Select(t => new TextUserViewModel
            {
                TextId = t.TextId,
                TextContent = t.TextContent,
                TextPublishDate = t.TextPublishDate,
                TextDate = t.TextDate,
                TextTitle = t.TextTitle
            }));

            return Ok(textsViewModel);
        }

        [HttpGet]
        public async Task<IHttpActionResult> SearchText(string query, int page, int pageSize)
        {
            var texts = await _db.Texts
                .Where(p => p.TextPublished && (p.TextTitle.Contains(query) || p.TextContent.Contains(query)))
                .OrderByDescending(d => d.TextPublishDate)
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var textsViewModel = new List<TextUserViewModel>();

            textsViewModel.AddRange(texts.Select(t => new TextUserViewModel
            {
                TextId = t.TextId,
                TextContent = t.TextContent,
                TextPublishDate = t.TextPublishDate,
                TextDate = t.TextDate,
                TextTitle = t.TextTitle
            }));

            return Ok(textsViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IHttpActionResult> TextsForAdmin()
        {
            var texts = await _db.Texts
                .OrderByDescending(d => d.TextPublishDate)
                .ToListAsync();

            var textsViewModel = new List<TextAdminViewModel>();

            textsViewModel.AddRange(texts.Select(t => new TextAdminViewModel
            {
                TextId = t.TextId,
                TextContent = t.TextContent,
                TextDate = t.TextDate,
                TextPublishDate = t.TextPublishDate,
                TextTitle = t.TextTitle,
                TextShares = t.TextShares,
                TextViews = t.TextViews,
                TextStayDuration = GetAverageTextStayDuration(t.TextId),
                TextPublished = t.TextPublished
            }));

            return Ok(textsViewModel);
        }

        // GET: api/ApiTexts/5
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> GetText(Guid id)
        {
            var text = await _db.Texts.FindAsync(id);
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
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public async Task<IHttpActionResult> TextShared(TextSharedViewModel model)
        {
            var text = await _db.Texts.FindAsync(model.Id);
            if (text == null)
            {
                return NotFound();
            }

            text.TextShares += 1;

            _db.Entry(text).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextExists(model.Id))
                {
                    return NotFound();
                }
                throw;
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IHttpActionResult> SaveTextStayDuration(TextStayViewModel model)
        {
            var text = await _db.Texts.FindAsync(model.Id);
            if (text == null)
            {
                return NotFound();
            }

            var stayDuration = new TextStayDuration
            {
                TextStayDurationId = Guid.NewGuid(),
                Duration = model.Duration,
                Text = text
            };

            _db.TextStays.Add(stayDuration);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TextExists(model.Id))
                {
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        public double GetAverageTextStayDuration(Guid id)
        {
            var average = 0.0;

            if (_db.TextStays.Any(i => i.Text.TextId == id))
            {
                average = Median(
                    _db.TextStays
                    .Include(t => t.Text)
                    .Where(t => t.Text.TextId == id)
                    .Select(i => i.Duration)
                    .ToList());
            }

            return average;
        }

        private static double Median(List<int> list)
        {
            list.Sort();
            var index = 0;
            if (list.Count % 2 != 0)
            {
                index = (list.Count + 1) / 2;
                return list[index - 1];
            }

            return (list[((list.Count / 2) - 1)] + list[(list.Count / 2)]) / 2;
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
                throw;
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
            text.TextPublished = false;
            text.TextPublishDate = DateTime.Now;

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
                throw;
            }

            return CreatedAtRoute("DefaultApi", new {id = text.TextId}, text);
        }

        [Authorize]
        [HttpPut]
        public async Task<IHttpActionResult> PublishText(Guid id, TextAdminViewModel model)
        {
            var text = await _db.Texts.FirstOrDefaultAsync(i => i.TextId == id);

            if (text.TextPublished)
            {
                return BadRequest("Text already published");
            }

            text.TextPublished = true;
            text.TextPublishDate = DateTime.Now;

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
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Authorize]
        [HttpPut]
        public async Task<IHttpActionResult> RevokeText(Guid id, TextAdminViewModel model)
        {
            var text = await _db.Texts.FirstOrDefaultAsync(i => i.TextId == id);

            if (text == null)
            {
                return BadRequest("Text doesn't exist");
            }

            text.TextPublished = false;

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
                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/ApiTexts/5
        [Authorize]
        [ResponseType(typeof(Text))]
        public async Task<IHttpActionResult> DeleteText(Guid id)
        {
            var text = await _db.Texts.FindAsync(id);
            if (text == null)
            {
                return NotFound();
            }
            var textStayDurations = _db.TextStays.Where(t => t.Text.TextId == id);
            _db.TextStays.RemoveRange(textStayDurations);
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