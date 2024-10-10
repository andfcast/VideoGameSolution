using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Infrastructure.Context;
using VideoGameApp.Infrastructure.Entidades;

namespace VideoGameApp.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly VideoGameStoreDbContext _context;

        public UsuarioRepository(VideoGameStoreDbContext context)
        {
            _context = context;
        }
        public async Task<RespuestaDto> Insertar(RegistroUsuarioDto dto)
        {
            try {
                Usuario newUsuario = new Usuario{
                    NombreUsuario = dto.NombreUsuario,
                    Password = dto.Password,
                    Email = dto.Email
                };
                await _context.Usuarios.AddAsync(newUsuario);
                await _context.SaveChangesAsync();
                return new RespuestaDto{ 
                    EsValido = true,
                    Mensaje = "Registro exitoso de usuario"
                };
            }
            catch (Exception ex) {
                return new RespuestaDto
                {
                    EsValido = false,
                    Mensaje = "Error ingresando usuario: " + ex.Message
                };
            }
            
            
        }
    }
}
