using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedTechC.Models;

namespace MedTechC.Data.Map
{
    public class ProntuarioMap : IEntityTypeConfiguration<ProntuarioModel>
    {
        public void Configure(EntityTypeBuilder<ProntuarioModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.PacienteId).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.Urgencia).IsRequired();
            builder.Property(p => p.Peso).IsRequired();
            builder.Property(p => p.Altura).IsRequired();
            builder.Property(p => p.PressaoArterial).IsRequired();
            builder.Property(p => p.Temperatura).IsRequired();
            builder.Property(p => p.Saturacao).IsRequired();
            builder.Property(p => p.FrequenciaCardiaca).IsRequired();
            builder.Property(p => p.QueixaPrincipal).IsRequired();
            builder.Property(p => p.DataAtendimento).IsRequired();
        }
    }
}