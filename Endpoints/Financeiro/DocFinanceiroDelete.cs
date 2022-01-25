using TirandoAsRodinhas.Infra.Data;

namespace TirandoAsRodinhas.Endpoints.Financeiro;

public class DocFinanceiroDelete
{
    public static string Template => "/financeiro/delete/{id:guid}";
    public static string[] Methods => new string[] { HttpMethod.Delete.ToString() };
    public static Delegate Handle => Action;

    //Ação que realiza a exclusão de um documento por ID do tipo GUID, realiza uma busca pelo entity através do
    //DbContext e aplica a exclusão no BD.
    public static async Task<IResult> Action([FromRoute] Guid id, HttpContext http, ApplicationDbContext context)
    {

        var documento = context.DocsFinanceiros
                .Where(p => p.Id == id).FirstOrDefault();
        
        if (documento == null)
            return Results.NotFound();

        context.DocsFinanceiros.Remove(documento);

        await context.SaveChangesAsync();

        return Results.NoContent();

    }
}
