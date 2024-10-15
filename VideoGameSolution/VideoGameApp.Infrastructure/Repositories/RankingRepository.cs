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
    public class RankingRepository : IRankingRepository
    {
        private readonly VideoGameStoreDbContext _context;

        public RankingRepository(VideoGameStoreDbContext context)
        {
            _context = context;
        }
        public async Task<List<RankingDto>> ObtenerRanking(int numTop)
        {
            List<RankingDto> lstRankings = new List<RankingDto>();
            var rankings = _context.Videojuegos.OrderByDescending(x => x.Puntaje).Take(numTop).ToList();
            int i = 1;
            foreach (var item in rankings) {
                lstRankings.Add(new RankingDto
                {
                    Anio = item.AnioLanzamiento,
                    Puntaje = item.Puntaje,
                    Compania = item.Compania,
                    Nombre = item.Nombre,
                    Clasificacion = i < (numTop / 2) ? "GOAT" : "AAA"
                });
                i++;
            }
            return lstRankings;
        }
    }
}
