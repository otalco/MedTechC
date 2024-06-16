using System.ComponentModel;

namespace MedTechC.Enums
{
    public enum StatusProntuario
    {
        [Description("Paciente aguardando atendimento")]
        Aberto =  1,

        [Description("Paciente em atendimento")]
        EmAndamento =  2,

        [Description("Paciente liberado")]
        Finalizado = 3
    }
}
