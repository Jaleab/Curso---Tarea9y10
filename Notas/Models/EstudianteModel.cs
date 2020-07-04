namespace Notas.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class EstudianteModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EstudianteModel()
        {
            this.Tienes = new HashSet<TieneModel>();
        }

        [Required(ErrorMessage = "*El carné es requerido.")]
        [DisplayName("Carné del estudiante")]
        public string carne { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string apellido2 { get; set; }

        [Required(ErrorMessage = "*El nombre completo del estudiante es requerido")]
        [DisplayName("Nombre completo del estudiante")]
        public string nombreCompleto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TieneModel> Tienes { get; set; }
    }
}