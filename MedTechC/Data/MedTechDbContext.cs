using MedTechC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MedTechC.Data
{
    public class MedTechDbContext : DbContext
    {
        public MedTechDbContext(DbContextOptions<MedTechDbContext> options) : base(options)
        {
        }

        public DbSet<PacienteModel> Pacientes { get; set; }
        public DbSet<ProntuarioModel> Prontuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Map.PacienteMap());
            modelBuilder.ApplyConfiguration(new Map.ProntuarioMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDatabase");
        }
    }
}
