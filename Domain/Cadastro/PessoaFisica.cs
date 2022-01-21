namespace TirandoAsRodinhas.Domain.Cadastro;

public class PessoaFisica : Entity
{
    public string Cpf { get; set; }
    public DateOnly Nascimento { get; set; }
    public Guid CadastroId { get; set; }
    public Cadastro Cadastro { get; set; }
}

    