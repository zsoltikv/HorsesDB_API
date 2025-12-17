using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorsesDB_API.Models;

namespace HorsesDB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorsesController : ControllerBase
    {
        private readonly HorsesDBContext _context;

        public HorsesController(HorsesDBContext context)
        {
            _context = context;
        }

        // GET: api/Horses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horse>>> GetHorses()
        {
            return await _context.Horses.ToListAsync();
        }

        // GET: api/Horses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Horse>> GetHorse(int id)
        {
            var horse = await _context.Horses.FindAsync(id);

            if (horse == null)
            {
                return NotFound();
            }

            return horse;
        }

        // PUT: api/Horses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorse(int id, Horse horse)
        {
            if (id != horse.HorseId)
            {
                return BadRequest();
            }

            _context.Entry(horse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorseExists(id))
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

        // POST: api/Horses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Horse>> PostHorse(Horse horse)
        {
            _context.Horses.Add(horse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHorse", new { id = horse.HorseId }, horse);
        }

        // DELETE: api/Horses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorse(int id)
        {
            var horse = await _context.Horses.FindAsync(id);
            if (horse == null)
            {
                return NotFound();
            }

            _context.Horses.Remove(horse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorseExists(int id)
        {
            return _context.Horses.Any(e => e.HorseId == id);
        }
    }
}
