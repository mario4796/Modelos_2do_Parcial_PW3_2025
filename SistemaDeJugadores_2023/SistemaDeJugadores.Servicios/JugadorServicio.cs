using SistemaDeJugadores.Data.EF;

namespace SistemaDeJugadores.Servicios
{
    public interface IJugadorServicio;
    public class JugadorServicio : IJugadorServicio
    {
        private MiDbContext _context;
        public JugadorServicio(MiDbContext context)
        {
            _context = context;
        }

    }
}
