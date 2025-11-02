using Gestion_Pilotos_Escuderias_2024.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Pilotos_Escuderias_2024.Logica
{
    public interface IEscuderiaLogica
    {
        Escuderium ObtenerEscuderiaPorId(int idEscuderia);
        List<Escuderium> ObtenerEscuderias();
    }
    public class EscuderiaLogica : IEscuderiaLogica
    {
        private MiDbContext _context;
        public EscuderiaLogica(MiDbContext context)
        {
            _context = context;
        }

        public Escuderium ObtenerEscuderiaPorId(int idEscuderia)
        {
            return _context.Escuderia
            .Find(idEscuderia);
        }

        public List<Escuderium> ObtenerEscuderias()
        {
            return _context.Escuderia
            .OrderBy(o => o.NombreEscuderia)
            .ToList();
        }
    }
}
