using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            _repository = repository;
        }


        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] RegistroUsuarioDto objDto)
        {
            objDto.Password = Helpers.Encriptar(objDto.Password);
            RespuestaDto respuesta = await _repository.Insertar(objDto);
            if (respuesta.EsValido)
                return Ok(respuesta);
            else
                return BadRequest(respuesta);
        }             
    }
}
