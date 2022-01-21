
namespace TirandoAsRodinhas.Domain.Register;

public class PessoaFisica : Entity
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public Guid ParceiroId { get; set; }
    public Parceiro Parceiro { get; set; }
}

    