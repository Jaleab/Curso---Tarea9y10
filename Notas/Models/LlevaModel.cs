//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LlevaModel
    {
        public string carneEstudianteFK { get; set; }
        public string siglasCursoFK { get; set; }
        public Nullable<int> notaCurso { get; set; }
    
        public virtual CursoModel Curso { get; set; }
        public virtual EstudianteModel Estudiante { get; set; }
    }
}
