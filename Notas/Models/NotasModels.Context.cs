﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NotasDBEntities1 : DbContext
    {
        public NotasDBEntities1()
            : base("name=NotasDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EstudianteModel> EstudianteModels { get; set; }
        public virtual DbSet<EvaluacionModel> EvaluacionModels { get; set; }
        public virtual DbSet<TieneModel> TieneModels { get; set; }
    }
}
