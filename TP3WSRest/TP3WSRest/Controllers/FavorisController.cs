using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3WSRest.Models.EntityFramework;

namespace TP3WSRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavorisController : ControllerBase
    {
        private readonly WSFilmsContext _context;

        public FavorisController(WSFilmsContext context)
        {
            _context = context;
        }

        // GET: api/Favoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favori>>> GetFavoris()
        {
            return await _context.Favoris.ToListAsync();
        }

        // GET: api/Favoris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favori>> GetFavori(int id)
        {
            var favori = await _context.Favoris.FindAsync(id);

            if (favori == null)
            {
                return NotFound();
            }

            return favori;
        }

        // PUT: api/Favoris/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavori(int id, Favori favori)
        {
            if (id != favori.CompteId)
            {
                return BadRequest();
            }

            _context.Entry(favori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavoriExists(id))
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

        // POST: api/Favoris
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Favori>> PostFavori(Favori favori)
        {
            _context.Favoris.Add(favori);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavoriExists(favori.CompteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavori", new { id = favori.CompteId }, favori);
        }

        // DELETE: api/Favoris/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Favori>> DeleteFavori(int id)
        {
            var favori = await _context.Favoris.FindAsync(id);
            if (favori == null)
            {
                return NotFound();
            }

            _context.Favoris.Remove(favori);
            await _context.SaveChangesAsync();

            return favori;
        }

        private bool FavoriExists(int id)
        {
            return _context.Favoris.Any(e => e.CompteId == id);
        }
    }
}
