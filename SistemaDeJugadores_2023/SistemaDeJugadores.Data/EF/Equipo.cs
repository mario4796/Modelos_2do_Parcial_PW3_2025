using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeJugadores.Data.EF;

[Table("Equipo")]
public partial class Equipo
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdEquipoNavigation")]
    public virtual ICollection<Jugador> Jugadors { get; set; } = new List<Jugador>();
}
