using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EntityFramework.Exceptions.SqlServer;
using Microsoft.EntityFrameworkCore;
using Sitio_Web_Core_MVC_CRUD_EF.Models;

namespace Sitio_Web_Core_MVC_CRUD_EF.Data
{
    public class Sitio_Web_Core_MVC_CRUD_EFContext : DbContext
    {
        public Sitio_Web_Core_MVC_CRUD_EFContext (DbContextOptions<Sitio_Web_Core_MVC_CRUD_EFContext> options)
            : base(options)
        {
        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(b => b.Cedula)
                .IsUnique();
        }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseExceptionProcessor();
        }
        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Empresa> Empresa { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Sede> Sede { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Area> Area { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Operacion> Operacion { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Usuario> Usuario { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Cargo> Cargo { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Contrato> Contrato { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Equipo> Equipo { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Periferico> Periferico { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Software> Software { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.Leasing> Leasing { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.LeasingPerifericos> LeasingPerifericos { get; set; }

        public DbSet<Sitio_Web_Core_MVC_CRUD_EF.Models.LeasingSoftware> LeasingSoftware { get; set; }
    }
}
