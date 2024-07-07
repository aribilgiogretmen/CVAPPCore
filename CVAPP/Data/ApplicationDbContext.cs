using System.Collections.Generic;
using System.Reflection.Emit;
using System;
using CVAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace CVAPP.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<User> User { get; set; }
        public DbSet<Cv> Cv { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Job>(e => e.Property(a => a.Aciklama).HasColumnName("Description"));
        }


    }
}
