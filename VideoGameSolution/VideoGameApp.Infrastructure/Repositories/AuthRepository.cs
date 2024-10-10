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
            var usuario = await _context.Usuarios.FirstAsync(x => x.NombreUsuario.ToLower() == dto.Usuario.ToLower() && x.Password == dto.Password);
            if (usuario != null)
            {
                respuesta.EsValido = true;
                respuesta.Contenido = new UsuarioDto { 
                    Id = usuario.Id,
                    Email = usuario.Email,
                    NombreUsuario = usuario.NombreUsuario
                };
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
