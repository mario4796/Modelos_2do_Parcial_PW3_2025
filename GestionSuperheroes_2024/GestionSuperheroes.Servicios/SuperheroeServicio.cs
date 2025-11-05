using GestionSuperheroes.Data.EF;
using Microsoft.EntityFrameworkCore;

namespace GestionSuperheroes.Servicios
{
    public interface ISuperheroeServicio
    {
        void AgregarSuperheroe(Superheroe superheroe);
        void EliminarSuperheroe(int id);
        List<Superheroe> ObtenerSuperheroesPorDestino(int value);
        List<Superheroe> ObtenerTodosLosSuperheroes();
    }
    public class SuperheroeServicio : ISuperheroeServicio
    {
        private MiDbContext _context;
        public SuperheroeServicio(MiDbContext context)
        {
            _context = context;
        }

        public void AgregarSuperheroe(Superheroe superheroe)
        {
            _context.Superheroes.Add(superheroe);
            _context.SaveChanges();
        }

        public void EliminarSuperheroe(int id)
        {
            var superheroe = _context.Superheroes.Find(id);
            if (superheroe != null)
            {
                superheroe.Eliminado = true;
                _context.SaveChanges();
            }
        }

        public List<Superheroe> ObtenerSuperheroesPorDestino(int value)
        {
            return _context.Superheroes
                .Include(s => s.IdUniversoNavigation)
                .Where(s => s.IdUniverso == value && !s.Eliminado)
                .ToList();
        }

        public List<Superheroe> ObtenerTodosLosSuperheroes()
        {
            return _context.Superheroes
                .Include(s => s.IdUniversoNavigation)
                .Where(s => !s.Eliminado)
                .ToList();
        }
    }
}
