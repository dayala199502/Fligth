﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FligthsEntities : DbContext
    {
        public FligthsEntities()
            : base("name=FligthsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FLIGHT> FLIGHT { get; set; }
        public virtual DbSet<JOURNEY> JOURNEY { get; set; }
        public virtual DbSet<TRANSPORT> TRANSPORT { get; set; }
        public virtual DbSet<JOURNEYFLIGHT> JOURNEYFLIGHTSet { get; set; }
    }
}