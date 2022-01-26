using TirandoAsRodinhas.Infra.Data;
using System.Data;

namespace TirandoAsRodinhas.Endpoints.Parceiros;

public class ParceiroDelete
{
    public static string Template => "/parceiros/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;
    
    public static async Task<IResult> Action([FromRoute] Guid id, HttpContext http, ApplicationDbContext context)
    {
        //Como o CASCADE está desabilitado da minha tabela PARCEIROS, para apagar todos os registros referente a parceiros,
        //tenho que ir deletando todas as ligações.
          
        var consultaParceiro = context.Parceiros.Find(id);
        
        if (consultaParceiro == null) 
            { return Results.NotFound("Não foi encontrado nenhum parceiro com o ID informado!");}
        
        var consultaEndereco = context.Enderecos.Find(consultaParceiro.EnderecoId);

        var consultaContato = context.Contatos.Find(consultaParceiro.ContatoId);

        var consultaDocumento = context.DocsFinanceiros.Where(p => p.ParceiroId == id).ToList();       //Buscando todos os documentos vinculados a Parceiro
            
        var consultaPf = context.PessoasFisicas.Where(p => p.ParceiroId == id).First();                //Buscando se há o ID na tabela de Pesssoas Fisica

        if (consultaPf == null) 
        {
            var consultaPj = context.PessoaJuridicas.Where(p => p.ParceiroId == id).First();           //Buscando se há o ID na tabela de Pesssoas Juridica

            if (consultaPj == null) { return Results.NotFound(); }

            context.PessoaJuridicas.Remove(consultaPj);
        }

        foreach (var item in consultaDocumento) {
            context.DocsFinanceiros.Remove(item);
        }

        
        context.Contatos.Remove(consultaContato);
        context.Enderecos.Remove(consultaEndereco);
        context.Parceiros.Remove(consultaParceiro);



        await context.SaveChangesAsync();

        return Results.NoContent();
    }
}
