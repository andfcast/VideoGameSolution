using Microsoft.EntityFrameworkCore;
using VideoGameApp.Application;
using VideoGameApp.Domain.DTO;
using VideoGameApp.Domain.Utils;
using VideoGameApp.Infrastructure.Context;
using VideoGameApp.Infrastructure.Entidades;

namespace VideoGameApp.Infrastructure.Repositories
{
    public class VideojuegoRepository : IVideojuegoRepository
    {
        private readonly VideoGameStoreDbContext _context;

        public VideojuegoRepository(VideoGameStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<VideojuegoDto>> Listar()
        {
            List<VideojuegoDto> lstVideojuegos = ConvertirAListaDto(await _context.Videojuegos.ToListAsync());            
            return lstVideojuegos;
        }

        public async Task<ListaPaginada<VideojuegoDto>> ListaPaginada(BusquedaDto objDto, int indicePagina, int regsPagina = 5)
        {
            
            var videojuegos = await _context.Videojuegos
                .OrderBy(b => b.Id)
                .Skip((indicePagina - 1) * regsPagina)
                .Take(regsPagina)
                .ToListAsync();
            List<VideojuegoDto> lstVideojuegos = ConvertirAListaDto(videojuegos);

            var conteo = await _context.Videojuegos.CountAsync();
            var totalPaginas = (int)Math.Ceiling(conteo / (double)regsPagina);
            return new ListaPaginada<VideojuegoDto>(lstVideojuegos, indicePagina, totalPaginas);
        }

        public async Task<VideojuegoDto> ObtenerXId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto> Insertar(VideojuegoDto newPersona)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto> Actualizar(VideojuegoDto objPersona)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaDto> Borrar(int id)
        {
            throw new NotImplementedException();
        }

        private List<VideojuegoDto> ConvertirAListaDto(List<Videojuego> lstEntidades) {
            List<VideojuegoDto> lstVideojuegos = new List<VideojuegoDto>();
            foreach (var item in lstEntidades)
            {
                lstVideojuegos.Add(new VideojuegoDto
                {
                    AnioLanzamiento = item.AnioLanzamiento,
                    Compania = item.Compania,
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Precio = item.Precio,
                    Puntaje = item.Puntaje
                });
            }
            return lstVideojuegos;
        }
    }
}
