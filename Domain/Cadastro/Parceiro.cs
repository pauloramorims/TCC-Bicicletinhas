namespace TirandoAsRodinhas.Domain.Cadastro;

public class Parceiro : Entity
{
    public Guid CadastroId { get; set; }
    public Cadastro Cadastro { get; set; }
    public Guid EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
    public Guid ContatoId { get; set; }
    public Contato Contato { get; set; }

}
