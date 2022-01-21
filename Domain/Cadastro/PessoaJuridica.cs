namespace TirandoAsRodinhas.Domain.Cadastro;

public class PessoaJuridica : Entity
{
    public string CNPJ { get; set; }
    public string RazaoSocial { get; set; }
    public Guid CadastroId { get; set; }
    public Cadastro Cadastro { get; set; }
}
