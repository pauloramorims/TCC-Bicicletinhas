using TirandoAsRodinhas.Infra.Data;

namespace TirandoAsRodinhas.Endpoints;


public class ParceirosGetAll
{
    public static string Template => "/parceiros";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;

    /// <summary>
    /// Lista todos meus parceiros por query parameter.
    /// </summary>
    /// <returns>Os meus parceiros da pesquisa</returns>
    /// <response code="200">Returna todos os parceiros cadastrados</response>
    public static async Task<IResult> Action( QueryAllParceiros query)
    {
        var result = await query.Execute();

        return Results.Ok(result);
    }

}