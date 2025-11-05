using System.ComponentModel.DataAnnotations;

namespace GestionSuperheroes.Web.Models
{
    public class SuperheroeViewModel
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
        [RegularExpression("^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$", ErrorMessage = "Solo se permiten letras y espacios.")]
        public string NombreSuperheroe { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un universo.")]
        public int IdUniverso { get; set; }

        public int IdSuperheroe { get; set; }
    }
}
