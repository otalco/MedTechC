using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTechC.Models
{
    public class PacienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Nome { get; set; }

        public String Cpf { get; set; }

        public String CartaoSus { get; set; }

        public String Rg { get; set; }

        public String DataNascimento { get; set; }

        public String Sexo { get; set; }

        public String NomeMae { get; set; }

        public String? NomePai { get; set; }

        public String Telefone { get; set; }

        public String Endereco { get; set; }

        public String? Observacoes { get; set; }

    }
}
