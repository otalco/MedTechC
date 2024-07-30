using System.Runtime.InteropServices.JavaScript;
using MedTechC.Enums;

namespace MedTechC.Models
{
    public class ProntuarioModel
    {
        public int Id { get; set; } 

        public int PacienteId { get; set; }

        public PacienteModel Paciente { get; set; }

        public StatusProntuario Status { get; set; }

        public String? Peso { get; set; }

        public String? Altura { get; set; }

        public String? PressaoArterial { get; set; }

        public String? Temperatura { get; set; }

        public String? Saturacao { get; set; }

        public String? FrequenciaCardiaca { get; set; }

        public String? QueixaPrincipal { get; set; }

        public DateTime dataAtendimento { get; set; }
    }
}
