using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviseController : ControllerBase
    {
        private List<Devise> devises { get; set; }
        public DeviseController()
        {
            this.devises = new List<Devise>
            {
                new Devise{
                    Id = 1,
                    NomDevise = "Dollar",
                    Taux = 1.08
                },
                new Devise{
                    Id = 2,
                    NomDevise = "Franc Suisse",
                    Taux = 1.07
                },
                new Devise{
                    Id = 3,
                    NomDevise = "Yen",
                    Taux = 120
                },
            };
        }

        /// <summary>
        /// Get every currency.
        /// </summary>
        /// <returns>Http response</returns>
        // GET: api/<DeviseController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
        public IActionResult GetAll()
        {
            return Ok(this.devises);
        }

        /// <summary>
        /// Get a single currency.
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response> 
        // GET api/<DeviseController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            Devise devise = this.devises.FirstOrDefault(devise => devise.Id == id);
            if(devise == null)
            {
                return NotFound();
            }
            return Ok(devise);
        }

        /// <summary>
        /// Create one currency
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="devise">the currency to create</param>
        /// <response code="201">When the currency has been created</response>
        // POST api/<DeviseController>
        [HttpPost]
        [ProducesResponseType(typeof(Devise), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Devise devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { Id = devise.Id }, devise);
        }

        /// <summary>
        /// Modify one currency
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <param name="devise">The currency modified</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response> 
        /// <response code="400">When the currency passed isn't well formed</response> 
        // PUT api/<DeviseController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = this.devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            this.devises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Remove one currency
        /// </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found and removed</response>
        /// <response code="404">When the currency id is not found</response> 
        // DELETE api/<DeviseController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Devise), 201)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            Devise toDelete = this.devises.FirstOrDefault(devise => devise.Id == id);

            if(toDelete != default)
            {
                this.devises.Remove(toDelete);
                return Ok("Element supprimé");
            }
            return NotFound();
        }
    }
}
