using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Utils;
using VideoGameApp.Domain.Validators;
using VideoGameApp.WebAPI.Custom;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly IValidator<LoginDto> _validator;
        private readonly AuthGenerator _authGenerator;

        public AuthController(IAuthRepository repository, IValidator<LoginDto> validator, AuthGenerator authGenerator)
        {
            _repository = repository;
            _validator = validator;
            _authGenerator = authGenerator;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto objDto)
        {
            ValidationResult resValidacion = await _validator.ValidateAsync(objDto);
            if (resValidacion.IsValid)
            {
                objDto.Password = Helpers.Encriptar(objDto.Password);
                RespuestaDto respuesta = await _repository.Login(objDto);
                if (respuesta.EsValido)
                {
                    RespuestaLoginDto resLogin = new RespuestaLoginDto { 
                        Contenido = respuesta.Contenido,
                        EsValido = true,
                        Mensaje = respuesta.Mensaje
                    };
                    resLogin.Token = _authGenerator.GenerarJwt((UsuarioDto)respuesta.Contenido);
                    return Ok(resLogin);
                }
                else
                    return BadRequest(respuesta);
            }
            else {
                StringBuilder sb = new StringBuilder();
                foreach (var item in resValidacion.Errors) {
                    sb.AppendLine(item.ErrorMessage);
                }
                return BadRequest(new RespuestaDto
                {
                    Mensaje = sb.ToString()
                });
            }
            
        }
    }
}
