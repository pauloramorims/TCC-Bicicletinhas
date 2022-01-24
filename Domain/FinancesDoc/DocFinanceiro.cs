using TirandoAsRodinhas.Domain.Register;

namespace TirandoAsRodinhas.Domain.FinancesDoc;
public class DocFinanceiro : Entity
{
    public string Movimentacao { get; set; }
    public string Observacao { get; set; }
    public Guid ParceiroId { get; set; }
    public Parceiro Parceiro { get; set; }
    public float Valor { get; set; }
    public Guid EmpresaId { get; set; }
    public Empresa Empresa { get; set; }


}
