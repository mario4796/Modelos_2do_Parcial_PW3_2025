using GestionSuperheroes.Data.EF;

namespace GestionSuperheroes.Servicios
{
    public interface IUniversoServicio
    {
    }
    public class UniversoServicio : IUniversoServicio
    {
        private MiDbContext _context;
        public UniversoServicio(MiDbContext context)
        {
            _context = context;
        }
    }
}
