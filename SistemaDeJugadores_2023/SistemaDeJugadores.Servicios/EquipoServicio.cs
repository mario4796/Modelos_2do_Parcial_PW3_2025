using SistemaDeJugadores.Data.EF;

namespace SistemaDeJugadores.Servicios
{
    public interface IEquipoServicio;
    public class EquipoServicio : IEquipoServicio
    {
        private MiDbContext _context;
        public EquipoServicio(MiDbContext context)
        {
            _context = context;
        }
    }
}
