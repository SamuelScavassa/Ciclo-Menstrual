
namespace API.Models;

public class Mestruacao
{
    public int MestruacaoId { get; set; }
    public int UserId { get; set; }
    public string Inicio { get; set; }
    public string Fim { get; set; }
    public int Fluxo { get; set; }
    public string Observacao { get; set;}

}