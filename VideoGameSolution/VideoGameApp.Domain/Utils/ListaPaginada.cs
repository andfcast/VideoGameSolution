using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameApp.Domain.Utils
{
    public class ListaPaginada<T>
    {
        public List<T> Items { get; }
        public int Indice { get; }
        public int TotalPaginas { get; }
        public bool TienePaginaAnterior => Indice > 1;
        public bool TienePaginaSiguiente => Indice < TotalPaginas;

        public ListaPaginada(List<T> items, int indice, int totalPaginas)
        {
            Items = items;
            Indice = indice;
            TotalPaginas = totalPaginas;
        }

    }
}
