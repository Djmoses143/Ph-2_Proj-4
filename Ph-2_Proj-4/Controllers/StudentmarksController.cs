using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ph_2_Proj_4.Models;

namespace Ph_2_Proj_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentmarksController : ControllerBase
    {
        private readonly Rainbow_schoolContext _context;

        public StudentmarksController(Rainbow_schoolContext context)
        {
            _context = context;
        }

        // GET: api/Studentmarks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studentmark>>> GetStudentmarks()
        {
          if (_context.Studentmarks == null)
          {
              return NotFound();
          }
            return await _context.Studentmarks.ToListAsync();
        }

        // GET: api/Studentmarks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Studentmark>> GetStudentmark(int id)
        {
          if (_context.Studentmarks == null)
          {
              return NotFound();
          }
            var studentmark = await _context.Studentmarks.FindAsync(id);

            if (studentmark == null)
            {
                return NotFound();
            }

            return studentmark;
        }

        // PUT: api/Studentmarks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentmark(int id, Studentmark studentmark)
        {
            if (id != studentmark.Sid)
            {
                return BadRequest();
            }

            _context.Entry(studentmark).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentmarkExists(id))
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

        // POST: api/Studentmarks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Studentmark>> PostStudentmark(Studentmark studentmark)
        {
          if (_context.Studentmarks == null)
          {
              return Problem("Entity set 'Rainbow_schoolContext.Studentmarks'  is null.");
          }
            _context.Studentmarks.Add(studentmark);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentmarkExists(studentmark.Sid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentmark", new { id = studentmark.Sid }, studentmark);
        }

        // DELETE: api/Studentmarks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentmark(int id)
        {
            if (_context.Studentmarks == null)
            {
                return NotFound();
            }
            var studentmark = await _context.Studentmarks.FindAsync(id);
            if (studentmark == null)
            {
                return NotFound();
            }

            _context.Studentmarks.Remove(studentmark);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentmarkExists(int id)
        {
            return (_context.Studentmarks?.Any(e => e.Sid == id)).GetValueOrDefault();
        }
    }
}
