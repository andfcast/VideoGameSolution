using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Infrastructure.Context;

namespace VideoGameApp.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly VideoGameStoreDbContext _context;

        public AuthRepository(VideoGameStoreDbContext context)
        {
            _context = context;
        }
        public async Task<RespuestaDto> Login(LoginDto dto)
        {
            RespuestaDto respuesta = new RespuestaDto();
            if (await _context.Usuarios.AnyAsync(x => x.NombreUsuario.ToLower() == dto.Usuario.ToLower() && x.Password == dto.Password))
            {
                respuesta.EsValido = true;
            }
            else
            {
                respuesta.EsValido = false;
                respuesta.Mensaje = "Credenciales incorrectas";
            }
            return respuesta;
        }
    }
}
