using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Domain.DTO;

namespace VideoGameApp.Application
{
    public interface IUsuarioRepository
    {
        Task<RespuestaDto> Insertar(RegistroUsuarioDto dto);
    }
}
