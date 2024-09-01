using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedTechC.Enums;

public class CondutaModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int ProntuarioId { get; set; }
    public int PacienteId { get; set; }
    public string? Medicacao { get; set; }
    public string? Posologia { get; set; }
    public string? Evolucao { get; set; }
    public string? Recomendacoes { get; set; }
    public StatusConduta Status { get; set; }

}

