﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NominationFormEntities : DbContext
    {
        public NominationFormEntities()
            : base("name=NominationFormEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NominationForm>().ToTable("NominationForm");
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<NominationForm> NominationForms { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.StudentApplication> StudentApplications { get; set; }

        public System.Data.Entity.DbSet<WebApplication1.Models.User> Users { get; set; }
    }
}
