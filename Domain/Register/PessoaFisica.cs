
namespace TirandoAsRodinhas.Domain.Register;

public class PessoaFisica : Entity
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public Guid ParceiroId { get; set; }
    public Parceiro Parceiro { get; set; }

    public PessoaFisica(string cpf, string nome)
    {
        var contract = new Contract<PessoaFisica>()
            .IsNotNullOrEmpty(cpf, "Cpf")
            .IsLowerThan(cpf, 12,"Cpf")
            .IsGreaterThan(cpf, 10, "Cpf")
            .IsNotNullOrEmpty(nome, "Nome");
        AddNotifications(contract);

        Cpf = cpf;
        Nome = nome;
    }
}

    