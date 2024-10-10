using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        private readonly IVideojuegoRepository _repository;

        public VideoGameController(IVideojuegoRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<VideoGameController>
        [HttpGet]
        public async Task<IActionResult> ListarTodo()
        {
            return Ok(await _repository.Listar());
        }

        [HttpGet]
        public async Task<IActionResult> Listar([FromBody] BusquedaDto objDto)
        {
            return Ok();
        }

        // GET api/<VideoGameController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VideoGameController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VideoGameController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VideoGameController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
