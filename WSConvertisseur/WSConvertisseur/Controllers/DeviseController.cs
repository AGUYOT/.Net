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
        // GET: api/<DeviseController>
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(this.devises);
        }

        // GET api/<DeviseController>/5
        [HttpGet("{id}", Name = "GetDevise")]
        public IActionResult GetById(int id)
        {
            Devise devise = this.devises.FirstOrDefault(devise => devise.Id == id);
            if(devise == null)
            {
                return NotFound();
            }
            return Ok(devise);
        }

        // POST api/<DeviseController>
        [HttpPost]
        public IActionResult Post([FromBody] Devise devise)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            this.devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { Id = devise.Id }, devise);
        }

        // PUT api/<DeviseController>/5
        [HttpPut("{id}")]
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

        // DELETE api/<DeviseController>/5
        [HttpDelete("{id}")]
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
