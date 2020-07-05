namespace Notas.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

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

        [DisplayName("Clases virtual del curso")]
        public string notasClases { get; set; }

        [DisplayName("Participacion en el foro del curso")]
        public Nullable<int> participacionForos { get; set; }

        [DisplayName("Investigacion del curso  (20%)")]
        public Nullable<int> notaInvestigacion { get; set; }

        [DisplayName("Planificacion de la investigacion")]
        public Nullable<int> notaPlanificacion { get; set; }

        [DisplayName("Ejecucion y reporte de la investigacion")]
        public Nullable<int> notaEjecucionReporte { get; set; }

        [DisplayName("Video de la investigacion")]
        public Nullable<int> notaVideo { get; set; }

        [DisplayName("Presentacion de la investigacion  (20%)")]
        public Nullable<int> notaPresentacion { get; set; }

        [DisplayName("Examenes del curso  (20%)")]
        public Nullable<int> notaParciales { get; set; }

        [DisplayName("Laboratorios del curso  (20%)")]
        public Nullable<int> notaLabs { get; set; }
    }
}