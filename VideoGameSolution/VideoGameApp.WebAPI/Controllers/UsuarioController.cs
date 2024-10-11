using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Utils;
using VideoGameApp.Domain.Validators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly IValidator<RegistroUsuarioDto> _validator;

        public UsuarioController(IUsuarioRepository repository, IValidator<RegistroUsuarioDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }


        // POST api/<UsuarioController>
        [HttpPost]
        public async Task<IActionResult> Registrar([FromBody] RegistroUsuarioDto objDto)
        {
            ValidationResult resValidacion = await _validator.ValidateAsync(objDto);
            if (resValidacion.IsValid)
            {
                objDto.Password = Helpers.Encriptar(objDto.Password);
                RespuestaDto respuesta = await _repository.Insertar(objDto);
                if (respuesta.EsValido)
                    return Ok(respuesta);
                else
                    return BadRequest(respuesta);
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (var item in resValidacion.Errors)
                {
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
