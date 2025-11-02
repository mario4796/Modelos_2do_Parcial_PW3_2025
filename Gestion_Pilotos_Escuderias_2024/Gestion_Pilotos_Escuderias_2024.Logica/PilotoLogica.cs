using Gestion_Pilotos_Escuderias_2024.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Pilotos_Escuderias_2024.Logica
{
    public interface IPilotoLogica
    {
        void AgregarPiloto(Piloto piloto);
        void EliminarPiloto(int idPiloto);
        List<Piloto> ObtenerPilotosPorEscuderia(int idEscuderia);
        List<Piloto> ObtnenerTodosLosPilotos();
    }
    public class PilotoLogica : IPilotoLogica
    {
        private MiDbContext _context;
        public PilotoLogica(MiDbContext context)
        {
            _context = context;
        }

        public void AgregarPiloto(Piloto piloto)
        {
            _context.Pilotos.Add(piloto);
            _context.SaveChanges();
        }

        public void EliminarPiloto(int idPiloto)
        {
            var piloto = _context.Pilotos.Find(idPiloto);
            if (piloto != null)
            {
                piloto.Eliminado = true;
                _context.SaveChanges();
            }
        }

        public List<Piloto> ObtenerPilotosPorEscuderia(int idEscuderia)
        {
            return _context.Pilotos
            .Include(p => p.IdEscuderiaNavigation)
            .Where(p => p.IdEscuderia == idEscuderia &&
                    !p.Eliminado)
            .ToList();
        }

        public List<Piloto> ObtnenerTodosLosPilotos()
        {
            return _context.Pilotos
           .Include(p => p.IdEscuderiaNavigation)
           .Where(p => !p.Eliminado)
           .ToList();
        }
    }
}
