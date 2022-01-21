namespace TirandoAsRodinhas.Domain.Register;

public class Empresa : Entity
{
    public string CNPJ { get; set; }
    public string RazaoSocial { get; set; }
    public string NomeFantasia { get; set; }
    public Guid EnderecoId { get; set; }
    public Endereco Endereco { get; set; }
    public Guid ContatoId { get; set; }
    public Contato Contato { get; set; }
    public IList<Parceiro> Parceiros { get; set; }
}
