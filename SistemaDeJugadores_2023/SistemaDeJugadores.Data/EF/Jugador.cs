using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SistemaDeJugadores.Data.EF;

[Table("Jugador")]
public partial class Jugador
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Nombre { get; set; } = null!;

    public int IdEquipo { get; set; }

    [ForeignKey("IdEquipo")]
    [InverseProperty("Jugadors")]
    public virtual Equipo IdEquipoNavigation { get; set; } = null!;
}
