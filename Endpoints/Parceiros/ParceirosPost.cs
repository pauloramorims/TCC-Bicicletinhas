using TirandoAsRodinhas.Domain.Register;
using TirandoAsRodinhas.Infra.Data;

namespace TirandoAsRodinhas.Endpoints.Parceiros;

public class ParceirosPost
{
    public static string Template => "/cadastrar";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(ParceirosRequest parceirosRequest, ApplicationDbContext context)
    {
        
        var endereco = new Endereco {
            CEP = parceirosRequest.Cep,
            Logradouro = parceirosRequest.Logradouro,
            Numero = parceirosRequest.Numero,
            Complemento = parceirosRequest.Complemento,
            Bairro = parceirosRequest.Bairro,
            Cidade = parceirosRequest.Cidade,
            Estado = parceirosRequest.Estado,
        };

        var contato = new Contato {
            TelCelular = parceirosRequest.TelCelular,
            TelFixo = parceirosRequest.TelFixo,
            Email = parceirosRequest.Email,
        };
       

        var parceiro = new Parceiro 
        {
            EnderecoId  = endereco.Id,
            ContatoId = contato.Id,
            CreatedOn = DateTime.Now,
            EditedOn = DateTime.Now,
            EmpresaId = parceirosRequest.EmpresaID,
        };

        context.Enderecos.Add(endereco);
        context.Contatos.Add(contato);
        context.Parceiros.Add(parceiro);
        context.SaveChanges();

        return Results.Created($"/cadastrar/{parceiro.Id}", parceiro.Id);
    }
}
