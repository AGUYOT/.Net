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
    [Route("api/compte")]
    [ApiController]
    public class ComptesController : ControllerBase
    {
        private readonly WSFilmsContext _context;

        public ComptesController(WSFilmsContext context)
        {
            _context = context;
        }

        // GET: api/Comptes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compte>>> GetComptes()
        {
            return await _context.Comptes.ToListAsync();
        }

        // GET: api/Comptes/5
        [Route("GetById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Compte>> GetCompteById(int id)
        {
            var compte = await _context.Comptes.FindAsync(id);

            if (compte == null)
            {
                return NotFound();
            }

            return compte;
        }

        // GET: api/Comptes/5
        [Route("GetByEmail/{email}")]
        [HttpGet]
        public async Task<ActionResult<Compte>> GetCompteByEmail(string email)
        {
            var compte = await _context.Comptes.FirstOrDefaultAsync(c => c.Mel == email);

            if (compte == null)
            {
                return NotFound();
            }

            return compte;
        }

        // PUT: api/Comptes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompte(int id, Compte compte)
        {
            if (id != compte.CompteId)
            {
                return BadRequest();
            }

            _context.Entry(compte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompteExists(id))
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

        // POST: api/Comptes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            _context.Comptes.Add(compte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompteById", new { id = compte.CompteId }, compte);
        }

        //// DELETE: api/Comptes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Compte>> DeleteCompte(int id)
        //{
        //    var compte = await _context.Comptes.FindAsync(id);
        //    if (compte == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Comptes.Remove(compte);
        //    await _context.SaveChangesAsync();

        //    return compte;
        //}

        private bool CompteExists(int id)
        {
            return _context.Comptes.Any(e => e.CompteId == id);
        }
    }
}
