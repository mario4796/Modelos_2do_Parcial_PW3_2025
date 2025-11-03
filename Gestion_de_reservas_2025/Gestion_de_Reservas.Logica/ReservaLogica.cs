using Gestion_de_Reservas.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Gestion_de_Reservas.Logica
{
    public interface IReservaLogica
    {
        void AgregarReserva(Reserva reservaEntidad);
        void EliminarReserva(int id);
        List<Reserva> ObtenerReservasPorDestino(int value);
        List<Reserva> ObtenerTodasLasReservas();
    }
    public class ReservaLogica : IReservaLogica
    {
        private readonly MiDbContext _context;
        public ReservaLogica(MiDbContext context)
        {
            _context = context;
        }

        public void AgregarReserva(Reserva reservaEntidad)
        {
            _context.Reservas.Add(reservaEntidad);
            _context.SaveChanges();
        }

        public void EliminarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva != null)
            {
                reserva.Eliminado = true;
                _context.SaveChanges();
            }
        }

        public List<Reserva> ObtenerReservasPorDestino(int value)
        {
            return _context.Reservas
                .Include(r => r.IdDestinoNavigation)
                .Where(r => r.IdDestino == value && !r.Eliminado)
                .ToList();
        }

        public List<Reserva> ObtenerTodasLasReservas()
        {
            return _context.Reservas
                .Include(r => r.IdDestinoNavigation)
                .Where(r => !r.Eliminado)
                .ToList();
        }
    }
}
