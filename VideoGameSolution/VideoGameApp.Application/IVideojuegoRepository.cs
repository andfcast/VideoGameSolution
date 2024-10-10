using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Utils;

namespace VideoGameApp.Application
{
    public interface IVideojuegoRepository
    {
        Task<List<VideojuegoDto>> Listar();
        Task<ListaPaginada<VideojuegoDto>> ListaPaginada(int indicePagina, int regsPagina);
        Task<VideojuegoDto> ObtenerXId(int id);
        Task<RespuestaDto> Insertar(VideojuegoDto newPersona);
        Task<RespuestaDto> Actualizar(VideojuegoDto objPersona);
        Task<RespuestaDto> Borrar(int id);
    }
}
