namespace Notas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class EvaluacionModel
    {
        public int evaluacionId { get; set; }


        [DisplayName("Clases, comprobaciones, examenes cortos y tareas (20%)")]
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

        [DisplayName("Clases virtuales del curso")]
        public string notasClases { get; set; }

        [Required(ErrorMessage = "*La nota de la participacion  en el foro requerida.")]
        [DisplayName("Participación en el foro del curso (20%)")]
        public Nullable<int> participacionForos { get; set; }

        [DisplayName("Investigación del curso (20%)")]
        public Nullable<int> notaInvestigacion { get; set; }

        [Required(ErrorMessage = "*La nota de la planificación es requerida.")]
        [DisplayName("Planificación de la investigación (20%)")]
        public Nullable<int> notaPlanificacion { get; set; }

        [Required(ErrorMessage = "*La nota de la ejecución y reporte es requerida.")]
        [DisplayName("Ejecución y reporte de la investigación (30%)")]
        public Nullable<int> notaEjecucionReporte { get; set; }

        [Required(ErrorMessage = "*La nota del video es requerida.")]
        [DisplayName("Video de la investigación (30%)")]
        public Nullable<int> notaVideo { get; set; }

        [Required(ErrorMessage = "*La nota de la presentaciones requerida.")]
        [DisplayName("Presentación de la investigación (20%)")]
        public Nullable<int> notaPresentacion { get; set; }

        [DisplayName("Examenes del curso  (20%)")]
        public Nullable<int> notaParciales { get; set; }

        [DisplayName("Laboratorios del curso  (20%)")]
        public Nullable<int> notaLabs { get; set; }
    }
}