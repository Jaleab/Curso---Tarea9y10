namespace Notas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class EstudianteModel
    {
        [Required(ErrorMessage = "*El carné es requerido.")]
        [DisplayName("Carné del estudiante")]
        public string carne { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string apellido2 { get; set; }

        [Required(ErrorMessage = "*El nombre completo del estudiante es requerido")]
        [DisplayName("Nombre completo del estudiante")]
        public string nombreCompleto { get; set; }
    }
}