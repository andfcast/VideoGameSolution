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

        [HttpPost]
        public async Task<IActionResult> ListarXFiltro([FromBody] BusquedaDto objDto, int pagina)
        {
            return Ok(await _repository.ListaPaginada(objDto,pagina));
        }

        // GET api/<VideoGameController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerXId(int id)
        {
            return Ok(await _repository.ObtenerXId(id));
        }

        // POST api/<VideoGameController>
        [HttpPost]
        public async Task<IActionResult> InsertarNuevo([FromBody] VideojuegoDto dto)
        {
            var respuesta = await _repository.Insertar(dto);
            if (respuesta.EsValido)
                return Ok(respuesta);
            else
                return BadRequest(respuesta);
        }

        // PUT api/<VideoGameController>
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VideojuegoDto dto)
        {
            var respuesta = await _repository.Actualizar(dto);
            if (respuesta.EsValido)
                return Ok(respuesta);
            else
                return BadRequest(respuesta);
        }

        // DELETE api/<VideoGameController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var respuesta = await _repository.Borrar(id);
            if (respuesta.EsValido)
                return Ok(respuesta);
            else
                return BadRequest(respuesta);
        }
    }
}
