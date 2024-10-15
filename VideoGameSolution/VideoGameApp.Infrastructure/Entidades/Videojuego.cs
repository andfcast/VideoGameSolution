using System;
using System.Collections.Generic;

namespace VideoGameApp.Infrastructure.Entidades;

public partial class Videojuego
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Compania { get; set; } = null!;

    public string AnioLanzamiento { get; set; } = null!;

    public decimal Precio { get; set; }

    public decimal Puntaje { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public int IdUsuarioActualizacion { get; set; }

    public virtual ICollection<Calificacione> Calificaciones { get; set; } = new List<Calificacione>();

    public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;
}
