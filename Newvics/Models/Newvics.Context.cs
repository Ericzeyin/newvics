﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Newvics.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Newvics_dbEntities : DbContext
    {
        public Newvics_dbEntities()
            : base("name=Newvics_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<FootyClub> FootyClub { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<Rank> Rank { get; set; }
        public virtual DbSet<Sports> Sports { get; set; }
        public virtual DbSet<Team> Team { get; set; }
    }
}