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

            return Ok(texts);
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

            return Ok(text);
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