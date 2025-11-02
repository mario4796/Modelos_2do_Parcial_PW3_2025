using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionSuperheroes.Data.EF;

[Table("Superheroe")]
public partial class Superheroe
{
    [Key]
    public int IdSuperheroe { get; set; }

    [StringLength(50)]
    public string NombreSuperheroe { get; set; } = null!;

    public int IdUniverso { get; set; }

    public bool Eliminado { get; set; }

    [ForeignKey("IdUniverso")]
    [InverseProperty("Superheroes")]
    public virtual Universo IdUniversoNavigation { get; set; } = null!;
}
