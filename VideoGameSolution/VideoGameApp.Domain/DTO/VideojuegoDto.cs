using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApp.Domain.DTO
{
    public class VideojuegoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Compania { get; set; } = string.Empty;
        public string AnioLanzamiento { get; set; } = string.Empty;
        public decimal Precio { get; set; }        
        public decimal Puntaje { get; set; }
        public string UsuarioIngreso { get; set; }
    }
}
