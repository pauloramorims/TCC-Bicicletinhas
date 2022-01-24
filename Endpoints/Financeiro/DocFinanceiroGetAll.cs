using TirandoAsRodinhas.Infra.Data;
namespace TirandoAsRodinhas.Endpoints.Financeiro;

public class DocFinanceirosGetAll
{
    public static string Template => "/financeiro";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;



    public static async Task<IResult> Action(QueryAllDocsFinanceiros query)
    {
        var result = await query.Execute();

        return Results.Ok(result);
    }

}