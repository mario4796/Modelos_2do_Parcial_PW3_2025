using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionSuperheroes.Data.EF;

[Table("Universo")]
public partial class Universo
{
    [Key]
    public int IdUniverso { get; set; }

    [StringLength(50)]
    public string NombreUniverso { get; set; } = null!;

    [InverseProperty("IdUniversoNavigation")]
    public virtual ICollection<Superheroe> Superheroes { get; set; } = new List<Superheroe>();
}
