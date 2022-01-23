using TirandoAsRodinhas.Infra.Data;

namespace TirandoAsRodinhas.Endpoints.Parceiros;

public class ParceirosGet
{
    public static string Template => "/parceiros/buscar";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;



    public static async Task<IResult> Action(string filtro, QueryParceiros query)
    {
        Console.WriteLine(filtro);
        var result = await query.Execute(filtro);

        return Results.Ok(result);
    }
}
