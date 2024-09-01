using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CondutaMap : IEntityTypeConfiguration<CondutaModel>
{
    public void Configure(EntityTypeBuilder<CondutaModel> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.ProntuarioId).IsRequired();
        builder.Property(c => c.PacienteId).IsRequired();
        builder.Property(c => c.Medicacao).IsRequired().HasMaxLength(512);
        builder.Property(c => c.Posologia).IsRequired().HasMaxLength(256);
        builder.Property(c => c.Evolucao).IsRequired().HasMaxLength(512);
        builder.Property(c => c.Recomendacoes).IsRequired().HasMaxLength(512);
        builder.Property(c => c.Status).IsRequired();
    }
}
