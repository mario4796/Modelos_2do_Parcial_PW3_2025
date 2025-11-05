using GestionSuperheroes.Data.EF;

namespace GestionSuperheroes.Servicios
{
    public interface IUniversoServicio
    {
        Universo ObtenerUniverosPorId(int idUniverso);
        List<Universo> ServicioObtenerUniversos();
    }
    public class UniversoServicio : IUniversoServicio
    {
        private MiDbContext _context;
        public UniversoServicio(MiDbContext context)
        {
            _context = context;
        }

        public Universo ObtenerUniverosPorId(int idUniverso)
        {
            return _context.Universos.Find(idUniverso);
        }

        public List<Universo> ServicioObtenerUniversos()
        {
            return _context.Universos
                .OrderBy(u => u.NombreUniverso)
                .ToList();
        }
    }
}
