using Gestion_de_Reservas.Data.EF;

namespace Gestion_de_Reservas.Logica
{
    public interface IDestinoLogica
    {
        List<Destino> ObtenerDestinos();
        Destino ObtenerDestinosPorId(int idDestino);
    }
    public class DestinoLogica : IDestinoLogica
    {
        private readonly MiDbContext _context;
        public DestinoLogica(MiDbContext context)
        {
            _context = context;
        }

        public List<Destino> ObtenerDestinos()
        {
            return _context.Destinos
                .OrderBy(d => d.Nombre)
                .ToList();
        }

        public Destino ObtenerDestinosPorId(int idDestino)
        {
            return _context.Destinos
                .Find(idDestino);
        }
    }
}
