﻿using System;
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
    public class TitulosController : ControllerBase
    {
        private readonly ContextDB _context;

        public TitulosController(ContextDB context)
        {
            _context = context;
        }

        // GET: api/Titulos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Titulo>>> GetTitulos()
        {
            return await _context.Titulos.ToListAsync();
        }

        // GET: api/Titulos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Titulo>> GetTitulo(int id)
        {
            var titulo = await _context.Titulos.FindAsync(id);

            if (titulo == null)
            {
                return NotFound();
            }

            return titulo;
        }

        // PUT: api/Titulos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitulo(int id, Titulo titulo)
        {
            if (id != titulo.Id)
            {
                return BadRequest();
            }

            _context.Entry(titulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TituloExists(id))
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

        // POST: api/Titulos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Titulo>> PostTitulo(Titulo titulo)
        {
            _context.Titulos.Add(titulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTitulo", new { id = titulo.Id }, titulo);
        }

        // DELETE: api/Titulos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitulo(int id)
        {
            var titulo = await _context.Titulos.FindAsync(id);
            if (titulo == null)
            {
                return NotFound();
            }

            _context.Titulos.Remove(titulo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TituloExists(int id)
        {
            return _context.Titulos.Any(e => e.Id == id);
        }
    }
}
