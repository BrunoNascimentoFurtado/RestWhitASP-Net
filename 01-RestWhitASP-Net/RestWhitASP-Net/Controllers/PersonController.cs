using Microsoft.AspNetCore.Mvc;
using RestWhitASP_Net.Model;
using RestWhitASP_Net.Service;
using RestWhitASP_Net.Service.Implamantation;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestWhitASP_Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonservice _personservice;
       

        public PersonController( ILogger<PersonController> logger, IPersonservice personservice)
        {
            _personservice = personservice;
            _logger = logger;
        }

        // GET: api/<PersonController>
        [HttpGet("todos")]
        public ActionResult Get()
        {
            return Ok(_personservice.FindAll());           
        }

        // GET api/<PersonController>/5
        [HttpGet("id/{id}")]
        public IActionResult Get(long id)
        {
            var person = _personservice.FindByID(id);
            if (person == null) 
            { return NotFound(); }
            return Ok(person);
        }

        // POST api/<PersonController>
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personservice.Create(person));

        }

        // PUT api/<PersonController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(_personservice.update(person));

        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long  id)
        {
            _personservice.Delete(id);
            return NoContent();


        }
    }
}
