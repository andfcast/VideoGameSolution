using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Utils;
using VideoGameApp.WebAPI.Custom;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly AuthGenerator _authGenerator;

        public AuthController(IAuthRepository repository, AuthGenerator authGenerator)
        {
            _repository = repository;
            _authGenerator = authGenerator;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto objDto)
        {
            objDto.Password = Helpers.Encriptar(objDto.Password);
            RespuestaDto respuesta = await _repository.Login(objDto);
            if (respuesta.EsValido)
            {
                RespuestaLoginDto resLogin = (RespuestaLoginDto)respuesta;
                resLogin.Token = _authGenerator.GenerarJwt((UsuarioDto)respuesta.Contenido);
                return Ok(resLogin);
            }
            else
                return BadRequest(respuesta);
        }
    }
}
