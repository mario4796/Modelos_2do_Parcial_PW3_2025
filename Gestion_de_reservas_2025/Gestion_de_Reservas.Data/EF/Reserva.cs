using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Reservas.Data.EF;

[Table("Reserva")]
public partial class Reserva
{
    [Key]
    public int IdReserva { get; set; }

    public int CantidadPasajeros { get; set; }

    public DateOnly FechaInicio { get; set; }

    public DateOnly FechaFin { get; set; }

    public int IdDestino { get; set; }

    public bool Eliminado { get; set; }

    [ForeignKey("IdDestino")]
    [InverseProperty("Reservas")]
    public virtual Destino IdDestinoNavigation { get; set; } = null!;
}
