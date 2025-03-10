using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArmoaTechApi.Data;
using ArmoaTechApi.Models;

namespace ArmoaTechApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReparacionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReparacionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Reparaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reparaciones>>> GetReparaciones()
        {
            return await _context.Reparaciones.ToListAsync();
        }

        // GET: api/Reparaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reparaciones>> GetReparaciones(string id)
        {
            var reparaciones = await _context.Reparaciones.FindAsync(id);

            if (reparaciones == null)
            {
                return NotFound();
            }

            return reparaciones;
        }

        // PUT: api/Reparaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReparaciones(string id, Reparaciones reparaciones)
        {
            if (id != reparaciones.CodReparacion)
            {
                return BadRequest();
            }

            _context.Entry(reparaciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReparacionesExists(id))
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

        // POST: api/Reparaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reparaciones>> PostReparaciones(Reparaciones reparaciones)
        {
            _context.Reparaciones.Add(reparaciones);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ReparacionesExists(reparaciones.CodReparacion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetReparaciones", new { id = reparaciones.CodReparacion }, reparaciones);
        }

        // DELETE: api/Reparaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReparaciones(string id)
        {
            var reparaciones = await _context.Reparaciones.FindAsync(id);
            if (reparaciones == null)
            {
                return NotFound();
            }

            _context.Reparaciones.Remove(reparaciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReparacionesExists(string id)
        {
            return _context.Reparaciones.Any(e => e.CodReparacion == id);
        }
    }
}
