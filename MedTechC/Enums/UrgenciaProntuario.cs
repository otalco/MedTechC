using System.ComponentModel;

namespace MedTechC.Enums
{
    public enum UrgenciaProntuario
    {
        [Description("Pulseira azul, atendimento em até 4 horas")]
        NaoUrgente = 1,

        [Description("Pulseira verde, atendimento em até 2 horas")]
        PoucoUrgente = 2,

        [Description("Pulseira amarela, atendimento em até 1 hora")]
        Urgente = 3,

        [Description("Pulseira laranja, atendimento em até 10 minutos")]
        MuitoUrgente = 4,

        [Description("Pulseira vermelha, atendimento imediato")]
        Emergencia = 5
    }
}
