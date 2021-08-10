using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BasicAPIDemo.Data;
using BasicAPIDemo.Models;

namespace BasicAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoredsController : ControllerBase
    {
        private readonly BasicAPIDemoContext _context;

        public BoredsController(BasicAPIDemoContext context)
        {
            _context = context;
        }

        // GET: api/Boreds
        [HttpGet]
        public IEnumerable<Bored> GetBored()
        {
            return _context.Bored;
        }

        // GET: api/Boreds/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBored([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bored = await _context.Bored.FindAsync(id);

            if (bored == null)
            {
                return NotFound();
            }

            return Ok(bored);
        }

        // PUT: api/Boreds/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBored([FromRoute] string id, [FromBody] Bored bored)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bored.BoredID)
            {
                return BadRequest();
            }

            _context.Entry(bored).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoredExists(id))
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

        // POST: api/Boreds
        [HttpPost]
        public async Task<IActionResult> PostBored([FromBody] Bored bored)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bored.Add(bored);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBored", new { id = bored.BoredID }, bored);
        }

        // DELETE: api/Boreds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBored([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bored = await _context.Bored.FindAsync(id);
            if (bored == null)
            {
                return NotFound();
            }

            _context.Bored.Remove(bored);
            await _context.SaveChangesAsync();

            return Ok(bored);
        }

        private bool BoredExists(string id)
        {
            return _context.Bored.Any(e => e.BoredID == id);
        }
    }
}