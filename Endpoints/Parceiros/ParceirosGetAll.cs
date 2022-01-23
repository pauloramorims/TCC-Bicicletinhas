using TirandoAsRodinhas.Infra.Data;

namespace TirandoAsRodinhas.Endpoints;


public class ParceirosGetAll
{
    public static string Template => "/parceiros";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;



    public static async Task<IResult> Action( QueryAllParceiros query)
    {
        var result = await query.Execute();

        return Results.Ok(result);
    }

}