namespace Gestion_de_Reservas.web.Models
{
    public class ReservaViewModel
    {
        public int IdReserva { get; set; }
        public int IdDestino { get; set; }
        public DateOnly FechaInicio { get; set; }
        public DateOnly FechaFin { get; set; }
        public int CantidadPasajeros { get; set; }
    }
}
