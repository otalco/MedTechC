using MedTechC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedTechC.Data.Map
{
    public class ProntuarioMap : IEntityTypeConfiguration<ProntuarioModel>
    {

        public void Configure(EntityTypeBuilder<ProntuarioModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Paciente).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Peso).HasMaxLength(10);
            builder.Property(x => x.Altura).HasMaxLength(10);
            builder.Property(x => x.PressaoArterial).HasMaxLength(10);
            builder.Property(x => x.Temperatura).HasMaxLength(10);
            builder.Property(x => x.Saturacao).HasMaxLength(10);
            builder.Property(x => x.FrequenciaCardiaca).HasMaxLength(10);
            builder.Property(x => x.QueixaPrincipal).HasMaxLength(255);
            builder.Property(x => x.dataAtendimento).IsRequired();
        }
    }
}
