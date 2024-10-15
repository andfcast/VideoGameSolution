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
            var usuario = await _context.Usuarios.Where(x => x.NombreUsuario.ToLower() == dto.Usuario.ToLower() && x.Password == dto.Password).ToListAsync();
            if (usuario.Count > 0)
            {
                respuesta.EsValido = true;
                respuesta.Contenido = new UsuarioDto { 
                    Id = usuario.First().Id,
                    Email = usuario.First().Email,
                    NombreUsuario = usuario.First().NombreUsuario
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
