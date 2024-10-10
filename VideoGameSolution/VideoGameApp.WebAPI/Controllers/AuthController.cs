using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;

        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto objDto)
        {
            objDto.Password = Helpers.Encriptar(objDto.Password);
            RespuestaDto respuesta = await _repository.Login(objDto);
            if (respuesta.EsValido)
                return Ok(respuesta);
            else
                return BadRequest(respuesta);
        }
    }
}
