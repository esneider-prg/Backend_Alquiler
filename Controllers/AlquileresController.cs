using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend_Alquiler.Models;
using Backend_Alquiler.ViewModels;

namespace Backend_Alquiler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        private readonly ContextDB _context;

        public AlquileresController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/Alquileres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alquiler>>> GetAlquileres()
        {
            return await _context.Alquileres.ToListAsync();
        }

        // GET: api/Alquileres/listado
        [HttpGet("listado")]
        public async Task<ActionResult<IEnumerable<AlquilerViewModel>>> GetAlquileresListado()
        {
            var Lista =  (from i in _context.Alquileres
                         select new AlquilerViewModel
                         {
                             Id = i.Id,
                             FechaAlquiler = i.FechaAlquiler,
                             valor = i.ValorAlquiler,
                             Cliente = _context.Clientes.Where(c => c.Id == i.ClienteId).FirstOrDefault(),
                             DetalleAlquilers = _context.DetalleAlquileres.Where(d => d.AlquilerId == i.Id).ToList()
        }).ToList();
            return Lista;
        }

        // GET: api/Alquileres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alquiler>> GetAlquiler(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);

            if (alquiler == null)
            {
                return NotFound();
            }

            return alquiler;
        }

        // PUT: api/Alquileres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlquiler(int id, Alquiler alquiler)
        {
            if (id != alquiler.Id)
            {
                return BadRequest();
            }

            _context.Entry(alquiler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlquilerExists(id))
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

        // POST: api/Alquileres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AlquilerViewModel>> PostAlquiler(AlquilerViewModel alquilerViewModel)
        {
            Alquiler alquiler = new Alquiler();
            alquiler.ClienteId = alquilerViewModel.ClienteId;
            alquiler.FechaAlquiler = alquilerViewModel.FechaAlquiler;
            alquiler.ValorAlquiler = alquilerViewModel.valor;
            _context.Alquileres.Add(alquiler);
            await _context.SaveChangesAsync();
            
            foreach (var cdId in alquilerViewModel.Detalle)
            {
                DetalleAlquiler detalleAlquiler = new DetalleAlquiler();
                detalleAlquiler.AlquilerId = alquiler.Id;
                detalleAlquiler.CdId = cdId;
                _context.DetalleAlquileres.Add(detalleAlquiler);
                _context.SaveChanges();
            }

            return CreatedAtAction("GetAlquiler", new { id = alquiler.Id }, alquiler);
        }

        // DELETE: api/Alquileres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlquiler(int id)
        {
            var alquiler = await _context.Alquileres.FindAsync(id);
            if (alquiler == null)
            {
                return NotFound();
            }

            _context.Alquileres.Remove(alquiler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlquilerExists(int id)
        {
            return _context.Alquileres.Any(e => e.Id == id);
        }
    }
}
