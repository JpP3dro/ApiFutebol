using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiFutebol.Data;
using ApiFutebol.Models;

namespace ApiFutebol.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadoresFutebolController : ControllerBase
    {
        private readonly DbJogadoresContext _context;

        public JogadoresFutebolController(DbJogadoresContext context)
        {
            _context = context;
        }

        // GET: api/JogadoresFutebol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogadorFutebol>>> GetJogadorFutebol()
        {
          if (_context.JogadorFutebol == null)
          {
              return NotFound();
          }
            return await _context.JogadorFutebol.ToListAsync();
        }

        // GET: api/JogadoresFutebol/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JogadorFutebol>> GetJogadorFutebol(int id)
        {
          if (_context.JogadorFutebol == null)
          {
              return NotFound();
          }
            var jogadorFutebol = await _context.JogadorFutebol.FindAsync(id);

            if (jogadorFutebol == null)
            {
                return NotFound();
            }

            return jogadorFutebol;
        }

        // PUT: api/JogadoresFutebol/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogadorFutebol(int id, JogadorFutebol jogadorFutebol)
        {
            if (id != jogadorFutebol.Id)
            {
                return BadRequest();
            }

            _context.Entry(jogadorFutebol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogadorFutebolExists(id))
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

        // POST: api/JogadoresFutebol
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JogadorFutebol>> PostJogadorFutebol(JogadorFutebol jogadorFutebol)
        {
          if (_context.JogadorFutebol == null)
          {
              return Problem("Entity set 'DbJogadoresContext.JogadorFutebol'  is null.");
          }
            _context.JogadorFutebol.Add(jogadorFutebol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJogadorFutebol", new { id = jogadorFutebol.Id }, jogadorFutebol);
        }

        // DELETE: api/JogadoresFutebol/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogadorFutebol(int id)
        {
            if (_context.JogadorFutebol == null)
            {
                return NotFound();
            }
            var jogadorFutebol = await _context.JogadorFutebol.FindAsync(id);
            if (jogadorFutebol == null)
            {
                return NotFound();
            }

            _context.JogadorFutebol.Remove(jogadorFutebol);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JogadorFutebolExists(int id)
        {
            return (_context.JogadorFutebol?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
