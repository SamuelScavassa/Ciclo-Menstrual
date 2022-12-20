
namespace API.Models;

public class Mestruacao
{
    public int MestruacaoId { get; set; }
    public int UserId { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime? Fim { get; set; }
    public int Fluxo { get; set; }
    public string? Observacao { get; set;}

}