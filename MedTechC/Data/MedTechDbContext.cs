using MedTechC.Models;
using Microsoft.EntityFrameworkCore;

namespace MedTechC.Data
{
    public class MedTechDbContext : DbContext
    {
        public MedTechDbContext(DbContextOptions<MedTechDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=medtechdb;Username=sa;Password=met@morfosE1");
            }
        }

        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<ProntuarioModel> Prontuarios { get; set; }
        public DbSet<CondutaModel> Condutas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PacienteModel>().ToTable("Pacientes");
            modelBuilder.Entity<ProntuarioModel>().ToTable("Prontuarios");
            modelBuilder.Entity<CondutaModel>().ToTable("Condutas");

            modelBuilder.ApplyConfiguration(new Map.PacienteMap());
            modelBuilder.ApplyConfiguration(new Map.ProntuarioMap());
            modelBuilder.ApplyConfiguration(new Map.CondutaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}