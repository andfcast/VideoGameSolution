using System;
using System.Collections.Generic;

namespace VideoGameApp.Infrastructure.Entidades;

public partial class Calificacione
{
    public Guid Id { get; set; }

    public int IdVideojuego { get; set; }

    public int IdUsuario { get; set; }

    public decimal Puntaje { get; set; }

    public DateTime FechaActualizacion { get; set; }

    public int IdUsuarioActualizacion { get; set; }

    public virtual Usuario IdUsuarioActualizacionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Videojuego IdVideojuegoNavigation { get; set; } = null!;
}
