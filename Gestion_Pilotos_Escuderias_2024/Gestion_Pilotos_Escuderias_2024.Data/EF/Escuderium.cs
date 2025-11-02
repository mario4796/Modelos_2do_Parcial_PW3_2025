using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Pilotos_Escuderias_2024.Data.EF;

public partial class Escuderium
{
    [Key]
    public int IdEscuderia { get; set; }

    [StringLength(50)]
    public string NombreEscuderia { get; set; } = null!;

    [InverseProperty("IdEscuderiaNavigation")]
    public virtual ICollection<Piloto> Pilotos { get; set; } = new List<Piloto>();
}
