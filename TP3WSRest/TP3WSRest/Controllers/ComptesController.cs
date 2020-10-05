using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP3WSRest.Models.DataManager;
using TP3WSRest.Models.EntityFramework;
using TP3WSRest.Models.Repository;

namespace TP3WSRest.Controllers
{
    [Route("api/compte")]
    [ApiController]
    public class ComptesController : ControllerBase
    {
        private readonly IDataRepository<Compte> _dataRepository;

        public ComptesController(IDataRepository<Compte> compteManager)
        {
            _dataRepository = compteManager;
        }

        // GET: api/Comptes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compte>>> GetComptes()
        {
            return await _dataRepository.GetAll();
        }

        // GET: api/Comptes/5
        [Route("GetById/{id}")]
        [HttpGet]
        public async Task<ActionResult<Compte>> GetCompteById(int id)
        {
            var compte = await _dataRepository.GetById(id);

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
            var compte = await _dataRepository.GetByString(email);

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

            var compteToUpdate = await _dataRepository.GetById(id);
            if (compteToUpdate == null)
            {
                return NotFound();
            }
            await _dataRepository.Update(compteToUpdate.Value, compte);

            return NoContent();
        }

        // POST: api/Comptes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Compte>> PostCompte(Compte compte)
        {
            await _dataRepository.Add(compte);

            return CreatedAtAction("GetCompteById", new { id = compte.CompteId }, compte);
        }

        // DELETE: api/Comptes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Compte>> DeleteCompte(int id)
        {
            var compte = await _dataRepository.GetById(id);
            if (compte == null)
            {
                return NotFound();
            }
            await _dataRepository.Delete(compte.Value);

            return compte;
        }
    }
}
