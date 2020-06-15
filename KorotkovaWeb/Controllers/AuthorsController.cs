using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KorotkovaWeb.Models;
using Microsoft.AspNetCore.Authorization;

namespace KorotkovaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorsContext _context;

        public AuthorsController(AuthorsContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Authors>>> Getauthors()
        {
            return await _context.authors.ToListAsync();
        }

     
        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Authors>> GetAuthors(long id)
        {
            var authors = await _context.authors.FindAsync(id);

            if (authors == null)
            {
                return NotFound();
            }

            return authors;
        }

        [HttpGet("{id}/count")]
        public async Task<ActionResult<int>> GetBooks(long id)
        {
            var book = await _context.authors.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book.getBooks();
        }

        // PUT: api/Authors/5

        [HttpGet("Pushkin")]
        public async Task<ActionResult<IEnumerable<Authors>>> GetPushkin()
        {
            return _context.GetPushkinBooks(_context.authors).ToList();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthors(long id, Authors authors)
        {
            if (id != authors.id)
            {
                return BadRequest();
            }

            _context.Entry(authors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorsExists(id))
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

        // POST: api/Authors
    
        [HttpPost]
        public async Task<ActionResult<Authors>> PostAuthors(Authors authors)
        {
            _context.authors.Add(authors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthors", new { id = authors.id }, authors);
        }

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        

        public async Task<ActionResult<Authors>> DeleteAuthors(long id)
        {
            var authors = await _context.authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }

            _context.authors.Remove(authors);
            await _context.SaveChangesAsync();

            return authors;
        }

        private bool AuthorsExists(long id)
        {
            return _context.authors.Any(e => e.id == id);
        }
    }
}
