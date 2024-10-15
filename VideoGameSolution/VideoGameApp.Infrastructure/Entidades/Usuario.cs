using System;
using System.Collections.Generic;

namespace VideoGameApp.Infrastructure.Entidades;

public partial class Usuario
{
    public int Id { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<Calificacione> CalificacioneIdUsuarioActualizacionNavigations { get; set; } = new List<Calificacione>();

    public virtual ICollection<Calificacione> CalificacioneIdUsuarioNavigations { get; set; } = new List<Calificacione>();

    public virtual ICollection<Videojuego> Videojuegos { get; set; } = new List<Videojuego>();
}
