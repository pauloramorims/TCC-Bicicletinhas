using TirandoAsRodinhas.Domain.FinancesDoc;
using TirandoAsRodinhas.Domain.Register;
using TirandoAsRodinhas.Infra.Data;
namespace TirandoAsRodinhas.Endpoints.Financeiro;

public class DocFinanceiroPost
{
    public static string Template => "/cadastrar/documento";
    public static string[] Methods => new string[] { HttpMethod.Post.ToString() };
    public static Delegate Handle => Action;

    public static async Task<IResult> Action(DocFinanceiroRequest docFinanceiroRequest, ApplicationDbContext context)
    {
        var documento = new DocFinanceiro 
        {
            ParceiroId = docFinanceiroRequest.ParceiroID,
            Valor = docFinanceiroRequest.Valor,
            Movimentacao = docFinanceiroRequest.Movimentacao,
            Observacao = docFinanceiroRequest.Observacao,
            EmpresaId = docFinanceiroRequest.EmpresaId
        };
                        
        context.DocsFinanceiros.Add(documento);
        context.SaveChanges();

        return Results.Created($"/cadastrar/documento{documento.Id}", documento.Id);
    }
}
