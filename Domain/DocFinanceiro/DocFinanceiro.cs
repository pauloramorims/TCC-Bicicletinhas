namespace TirandoAsRodinhas.Domain.DocFinanceiro;
using TirandoAsRodinhas.Domain.Cadastro;


public class DocFinanceiro : Entity
{
    public string Movimentacao { get; set; }
    public string Observacao { get; set; }
    public Guid CadastroID { get; set; }
    public Cadastro Cadastro { get; set; }
    public Guid EmpresaId { get; set; }
    public Empresa Empresa { get; set; }
    public float Valor { get; set; }
}
