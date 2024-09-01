using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using MedTechC.Enums;

namespace MedTechC.Models
{
    public class ProntuarioModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } 

        public int PacienteId { get; set; }
        
        public StatusProntuario Status { get; set; }

        public UrgenciaProntuario Urgencia { get; set; }

        public String? Peso { get; set; }

        public String? Altura { get; set; }

        public String? PressaoArterial { get; set; }

        public String? Temperatura { get; set; }

        public String? Saturacao { get; set; }

        public String? FrequenciaCardiaca { get; set; }

        public String? QueixaPrincipal { get; set; }

        public DateTime DataAtendimento { get; set; }
    }
}
