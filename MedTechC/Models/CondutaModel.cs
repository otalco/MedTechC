public class CondutaModel
{
    public int Id { get; set; }
    public int ProntuarioId { get; set; }
    public int PacienteId { get; set; }
    public string Medicacao { get; set; }
    public string Posologia { get; set; }
    public string Evolucao { get; set; }
    public string Recomendacoes { get; set; }
    public StatusConduta Status { get; set; }

    public ProntuarioModel Prontuario { get; set; }
    public PacienteModel Paciente { get; set; }
}

public enum StatusConduta
{
    Alta,
    EmEvolucao
}
