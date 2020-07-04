namespace Notas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class EvaluacionModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EvaluacionModel()
        {
            this.Tienes = new HashSet<TieneModel>();
        }

        public int evaluacionId { get; set; }

        [DisplayName("Clases, comprobaciones, examenes cortos y tareas")]
        public Nullable<int> notaCCQT { get; set; }

        [DisplayName("Tareas del curso")]
        public string notasTareas { get; set; }

        [DisplayName("Comprobaciones del curso")]
        public string notasComprobaciones { get; set; }

        [DisplayName("Examenes cortos del curso")]
        public string notasExamenesCortos { get; set; }

        [DisplayName("Examenes del curso")]
        public string notasExamenes { get; set; }

        [DisplayName("Laboratorios del curso")]
        public string notasLaboratorios { get; set; }

        [DisplayName("Clases virtual del curso")]
        public string notasClases { get; set; }

        [DisplayName("Partipacion en el foro del curso")]
        public Nullable<int> participacionForos { get; set; }

        [DisplayName("Investigacion del curso")]
        public Nullable<int> notaInvestigacion { get; set; }

        [DisplayName("Planificacion de la investigacion")]
        public Nullable<int> notaPlanificacion { get; set; }

        [DisplayName("Ejecucion y reporte de la investigacion")]
        public Nullable<int> notaEjecucionReporte { get; set; }

        [DisplayName("Video de la investigacion")]
        public Nullable<int> notaVideo { get; set; }

        [DisplayName("Presentacion de la investigacion")]
        public Nullable<int> notaPresentacion { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TieneModel> Tienes { get; set; }
    }
}