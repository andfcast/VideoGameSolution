using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApp.Domain.DTO
{
    public  class RankingDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Compania { get; set; } = string.Empty;
        public string Anio { get; set; } = string.Empty;        
        public decimal Puntaje { get; set; }
        public string Clasificacion { get; set; } = string.Empty;
    }
}
