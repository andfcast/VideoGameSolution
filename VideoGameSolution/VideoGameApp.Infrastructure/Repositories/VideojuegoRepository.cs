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
            List<Videojuego> lstFiltro = await _context.Videojuegos.ToListAsync();
            if (!String.IsNullOrEmpty(objDto.Nombre)){
                lstFiltro = lstFiltro.Where(x => x.Nombre == objDto.Nombre).ToList();
            }
            if (!String.IsNullOrEmpty(objDto.Compania))
            {
                lstFiltro = lstFiltro.Where(x => x.Compania == objDto.Compania).ToList();
            }
            if (!String.IsNullOrEmpty(objDto.Anio)) {
                lstFiltro = lstFiltro.Where(x => x.AnioLanzamiento == objDto.Anio).ToList();
            }
            
            var videojuegos = lstFiltro
                .OrderBy(b => b.Id)
                .Skip((indicePagina - 1) * regsPagina)
                .Take(regsPagina)
                .ToList();
                
            List<VideojuegoDto> lstVideojuegos = ConvertirAListaDto(videojuegos);

            var conteo = lstFiltro.Count;
            var totalPaginas = (int)Math.Ceiling(conteo / (double)regsPagina);
            return new ListaPaginada<VideojuegoDto>(lstVideojuegos, indicePagina, totalPaginas);
        }

        public async Task<VideojuegoDto> ObtenerXId(int id)
        {
            return ConvertirADto(await _context.Videojuegos.FirstAsync(x => x.Id == id));            
        }

        public async Task<RespuestaDto> Insertar(VideojuegoDto newPersona)
        {
            try
            {
                await _context.Videojuegos.AddAsync(ConvertirAEntity(newPersona));
                await _context.SaveChangesAsync();
                return new RespuestaDto
                {
                    EsValido = true,
                    Mensaje = "Inserción exitosa"
                };
            }
            catch (Exception ex) {
                return new RespuestaDto
                {
                    EsValido = false,
                    Mensaje = "Error al realizar inserción: " + ex.Message
                };
            }            
        }

        public async Task<RespuestaDto> Actualizar(VideojuegoDto objPersona)
        {
            try
            {
                _context.Entry(ConvertirAEntity(objPersona)).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return new RespuestaDto
                {
                    EsValido = true,
                    Mensaje = "Actualización exitosa"
                };
            }
            catch (Exception ex)
            {
                return new RespuestaDto
                {
                    EsValido = false,
                    Mensaje = "Error al realizar actualización: " + ex.Message
                };
            }
        }

        public async Task<RespuestaDto> Borrar(int id)
        {
            try
            {
                var borrado = await _context.Videojuegos.FirstOrDefaultAsync(x => x.Id == id);
                _context.Videojuegos.Remove(borrado);
                await _context.SaveChangesAsync();
                return new RespuestaDto
                {
                    EsValido = true,
                    Mensaje = "Eliminaión exitosa"
                };

            }
            catch (Exception ex)
            {
                return new RespuestaDto
                {
                    EsValido = false,
                    Mensaje = "Error al eliminar:" + ex.Message
                };
            }
        }

        private VideojuegoDto ConvertirADto(Videojuego entidad) {
            return new VideojuegoDto
            {
                AnioLanzamiento = entidad.AnioLanzamiento,
                Compania = entidad.Compania,
                Id = entidad.Id,
                Nombre = entidad.Nombre,
                Precio = entidad.Precio,
                Puntaje = entidad.Puntaje
            };
        }

        private List<VideojuegoDto> ConvertirAListaDto(List<Videojuego> lstEntidades) {
            List<VideojuegoDto> lstVideojuegos = new List<VideojuegoDto>();
            foreach (var item in lstEntidades)
            {
                lstVideojuegos.Add(ConvertirADto(item));
            }
            return lstVideojuegos;
        }

        private Videojuego ConvertirAEntity(VideojuegoDto dto)
        {
            return new Videojuego
            {
                AnioLanzamiento = dto.AnioLanzamiento,
                Compania = dto.Compania,
                Id = dto.Id,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Puntaje = dto.Puntaje
            };
        }
    }
}
