using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Alquiler.Models;

namespace Backend_Alquiler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SancionesController : ControllerBase
    {
        private readonly ContextDB _context;

        public SancionesController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/Sanciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sancion>>> GetSanciones()
        {
            return await _context.Sanciones.ToListAsync();
        }

        // GET: api/Sanciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sancion>> GetSancion(int id)
        {
            var sancion = await _context.Sanciones.FindAsync(id);

            if (sancion == null)
            {
                return NotFound();
            }

            return sancion;
        }

        // PUT: api/Sanciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSancion(int id, Sancion sancion)
        {
            if (id != sancion.Id)
            {
                return BadRequest();
            }

            _context.Entry(sancion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SancionExists(id))
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

        // POST: api/Sanciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sancion>> PostSancion(Sancion sancion)
        {
            _context.Sanciones.Add(sancion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSancion", new { id = sancion.Id }, sancion);
        }

        // DELETE: api/Sanciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSancion(int id)
        {
            var sancion = await _context.Sanciones.FindAsync(id);
            if (sancion == null)
            {
                return NotFound();
            }

            _context.Sanciones.Remove(sancion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SancionExists(int id)
        {
            return _context.Sanciones.Any(e => e.Id == id);
        }
    }
}
