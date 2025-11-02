using GestionSuperheroes.Data.EF;

namespace GestionSuperheroes.Servicios
{
    public interface ISuperheroeServicio
    {

    }
    public class SuperheroeServicio : ISuperheroeServicio
    {
        private MiDbContext _context;
        public SuperheroeServicio(MiDbContext context)
        {
            _context = context;
        }

    }
}
