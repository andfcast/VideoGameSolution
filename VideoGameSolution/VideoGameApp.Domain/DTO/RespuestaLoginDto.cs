using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApp.Domain.DTO
{
    public  class RespuestaLoginDto : RespuestaDto
    {
        public string Token { get; set; } = string.Empty;
    }
}
