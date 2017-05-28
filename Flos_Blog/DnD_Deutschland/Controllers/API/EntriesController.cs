using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DnD_Deutschland.Data;
using DnD_Deutschland.Models;

namespace DnD_Deutschland.Controllers.API
{
    [Produces("application/json")]
    [Route("api/Entries")]
    public class EntriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EntriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Entries
        [HttpGet]
        public IEnumerable<Entry> GetEntries()
        {
            return _context.Entries;
        }

        [HttpGet]
        public IEnumerable<BlogEntry> GetBlogEntries()
        {
            return _context.BlogEntries;
        }

        [HttpGet]
        public IEnumerable<ForumEntry> GetForumEntries()
        {
            return _context.ForumEntries;
        }

        // GET: api/Entries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntry([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.EntryId == id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogEntry([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = await _context.BlogEntries.SingleOrDefaultAsync(m => m.EntryId == id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForumEntry([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = await _context.ForumEntries.SingleOrDefaultAsync(m => m.EntryId == id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        // PUT: api/Entries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry([FromRoute] Guid id, [FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entry.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Entries
        [HttpPost]
        public async Task<IActionResult> PostEntry([FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntry", new { id = entry.EntryId }, entry);
        }

        // DELETE: api/Entries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entry = await _context.Entries.SingleOrDefaultAsync(m => m.EntryId == id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();

            return Ok(entry);
        }

        private bool EntryExists(Guid id)
        {
            return _context.Entries.Any(e => e.EntryId == id);
        }
    }
}