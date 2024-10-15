using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VideoGameApp.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class RankingController : ControllerBase
    {
        private readonly IRankingRepository _repository;

        public RankingController(IRankingRepository repository)
        {
            _repository = repository;
        }

        // POST api/<RankingController>
        [HttpPost]
        public async Task<IActionResult> GenerarRanking([FromBody] RankingRequestDto dto)
        {
            if (dto.NumeroTop <= 0) {
                return BadRequest(new RespuestaDto
                {
                    Mensaje = "Número no válido"
                });
            }
            return Ok(await _repository.ObtenerRanking(dto.NumeroTop));
        }

        
    }
}
