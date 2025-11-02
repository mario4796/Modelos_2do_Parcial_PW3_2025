using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Pilotos_Escuderias_2024.Data.EF;

[Table("Piloto")]
public partial class Piloto
{
    [Key]
    public int IdPiloto { get; set; }

    [StringLength(50)]
    public string NombrePiloto { get; set; } = null!;

    public int IdEscuderia { get; set; }

    public bool Eliminado { get; set; }

    [ForeignKey("IdEscuderia")]
    [InverseProperty("Pilotos")]
    public virtual Escuderium IdEscuderiaNavigation { get; set; } = null!;
}
