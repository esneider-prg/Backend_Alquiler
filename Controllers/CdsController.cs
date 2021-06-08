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
    public class CdsController : ControllerBase
    {
        private readonly ContextDB _context;

        public CdsController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/Cds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cd>>> GetCds()
        {
            return await _context.Cds.ToListAsync();
        }

        // GET: api/Cds/disponibles
        [HttpGet("disponibles")]
        public async Task<ActionResult<IEnumerable<CdViewModel>>> GetCdsDisponibles()
        {
            var Lista =  (from i in _context.Cds
                         select new CdViewModel
                         {
                             Id = i.Id,
                             Ubicacion = i.Ubicacion,
                             Condicion = i.Condicion,
                             estado = i.Estado,
                             Titulo = _context.Titulos.Where(titulo => titulo.Id == i.TituloId).FirstOrDefault()

                         }).Where(cd => cd.estado == "Disponible").ToList();

            return Lista;
        }

        // GET: api/Cds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cd>> GetCd(int id)
        {
            var cd = await _context.Cds.FindAsync(id);

            if (cd == null)
            {
                return NotFound();
            }

            return cd;
        }


        // PUT: api/Cds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCd(int id, Cd cd)
        {
            if (id != cd.Id)
            {
                return BadRequest();
            }

            _context.Entry(cd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CdExists(id))
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

        // POST: api/Cds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cd>> PostCd(Cd cd)
        {

            _context.Cds.Add(cd);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCd", new { id = cd.Id }, cd);
        }

        // DELETE: api/Cds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCd(int id)
        {
            var cd = await _context.Cds.FindAsync(id);
            if (cd == null)
            {
                return NotFound();
            }

            _context.Cds.Remove(cd);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CdExists(int id)
        {
            return _context.Cds.Any(e => e.Id == id);
        }
    }
}
