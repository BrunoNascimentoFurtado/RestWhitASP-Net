using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWhitASP_Net.Model;
using RestWhitASP_Net.Service;

namespace RestWhitASP_Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class PersonControllerBD : ControllerBase
    {
        private readonly ILoggerBD <PersonController> _logger;
        private IPersonservice _personservice;

        public PersonControllerBD( ILoggerBD<PersonControllerBD> logger, IPersonservice personservice)
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
        public IActionResult Delete(long id)
        {
            _personservice.Delete(id);
            return NoContent();
        }



    }
}
