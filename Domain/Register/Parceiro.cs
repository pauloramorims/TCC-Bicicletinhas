
using TirandoAsRodinhas.Domain.FinancesDoc;

namespace TirandoAsRodinhas.Domain.Register;


public class Parceiro : Entity
{
    public Guid EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
    public Guid ContatoId { get; set; }
    public Contato Contato { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime EditedOn { get; set; }
    public bool Active { get; set; } = true;
    public Guid EmpresaId { get; set; }
    public Empresa Empresa { get; set; }

    public IList<DocFinanceiro> Documentos { get; set; }

}
