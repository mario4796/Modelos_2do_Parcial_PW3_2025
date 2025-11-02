using System.ComponentModel.DataAnnotations;

namespace Gestion_Pilotos_Escuderias_2024.Web.Models
{
    public class PilotoViewModel
    {
        public string NombrePiloto { get; set; }
        public int IdPiloto { get; set; }
        public int IdEscuderia { get; set; }
    }
}
