﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingMasterWebAPI.Models.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TMEntities : DbContext
    {
        public TMEntities()
            : base("name=TMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<exercise> exercise { get; set; }
        public virtual DbSet<foodItem> foodItem { get; set; }
        public virtual DbSet<foodPortion> foodPortion { get; set; }
        public virtual DbSet<foodProgram> foodProgram { get; set; }
        public virtual DbSet<foodProgramDate> foodProgramDate { get; set; }
        public virtual DbSet<goals> goals { get; set; }
        public virtual DbSet<measurementCM> measurementCM { get; set; }
        public virtual DbSet<measureMM> measureMM { get; set; }
        public virtual DbSet<paymentMethod> paymentMethod { get; set; }
        public virtual DbSet<product> product { get; set; }
        public virtual DbSet<progressImage> progressImage { get; set; }
        public virtual DbSet<trainer> trainer { get; set; }
        public virtual DbSet<training> training { get; set; }
        public virtual DbSet<trainingProgram> trainingProgram { get; set; }
        public virtual DbSet<trainingProgramDate> trainingProgramDate { get; set; }
        public virtual DbSet<trainingSale> trainingSale { get; set; }
        public virtual DbSet<trainingSaleProduct> trainingSaleProduct { get; set; }
        public virtual DbSet<zipcodes> zipcodes { get; set; }
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
    }
}
