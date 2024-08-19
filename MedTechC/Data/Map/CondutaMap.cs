using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CondutaMap : IEntityTypeConfiguration<CondutaModel>
{
    public void Configure(EntityTypeBuilder<CondutaModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Medicacao).IsRequired();
        builder.Property(c => c.Posologia).IsRequired();
        builder.Property(c => c.Evolucao).IsRequired();
        builder.Property(c => c.Recomendacoes).IsRequired();
        builder.Property(c => c.Status).IsRequired();

        builder.HasOne(c => c.Prontuario)
               .WithMany()
               .HasForeignKey(c => c.ProntuarioId);

        builder.HasOne(c => c.Paciente)
               .WithMany()
               .HasForeignKey(c => c.PacienteId);
    }
}
