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
    public class DetalleAlquileresController : ControllerBase
    {
        private readonly ContextDB _context;

        public DetalleAlquileresController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/DetalleAlquileres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleAlquiler>>> GetDetalleAlquileres()
        {
            return await _context.DetalleAlquileres.ToListAsync();
        }

        // GET: api/DetalleAlquileres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleAlquiler>> GetDetalleAlquiler(int id)
        {
            var detalleAlquiler = await _context.DetalleAlquileres.FindAsync(id);

            if (detalleAlquiler == null)
            {
                return NotFound();
            }

            return detalleAlquiler;
        }

        // PUT: api/DetalleAlquileres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleAlquiler(int id, DetalleAlquiler detalleAlquiler)
        {
            if (id != detalleAlquiler.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleAlquiler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleAlquilerExists(id))
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

        // POST: api/DetalleAlquileres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleAlquiler>> PostDetalleAlquiler(DetalleAlquiler detalleAlquiler)
        {
            _context.DetalleAlquileres.Add(detalleAlquiler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleAlquiler", new { id = detalleAlquiler.Id }, detalleAlquiler);
        }

        // DELETE: api/DetalleAlquileres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleAlquiler(int id)
        {
            var detalleAlquiler = await _context.DetalleAlquileres.FindAsync(id);
            if (detalleAlquiler == null)
            {
                return NotFound();
            }

            _context.DetalleAlquileres.Remove(detalleAlquiler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleAlquilerExists(int id)
        {
            return _context.DetalleAlquileres.Any(e => e.Id == id);
        }
    }
}
