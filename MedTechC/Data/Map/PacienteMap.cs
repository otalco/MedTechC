using MedTechC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedTechC.Data.Map
{
    public class PacienteMap : IEntityTypeConfiguration<PacienteModel>
    {

        public void Configure(EntityTypeBuilder<PacienteModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(11);
            builder.Property(x => x.CartaoSus).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Rg).IsRequired().HasMaxLength(15);
            builder.Property(x => x.DataNascimento).IsRequired();
            builder.Property(x => x.Sexo).IsRequired().HasMaxLength(10);
            builder.Property(x => x.NomeMae).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Endereco).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Observacoes).HasMaxLength(500);
        }
    }
}
