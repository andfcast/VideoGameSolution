using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Domain.DTO;

namespace VideoGameApp.Application
{
    public interface IAuthRepository
    {
        Task<RespuestaDto> Login(LoginDto dto);
    }
}
