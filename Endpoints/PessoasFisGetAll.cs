using TirandoAsRodinhas.Infra.Data;
using TirandoAsRodinhas.Domain.Register;

namespace TirandoAsRodinhas.Endpoints;



public class PessoasFisGetAll
{
    public static string Template => "/pessoasfisicas";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;



    public static async Task<IResult> Action(int? page, int? rows, QueryAllPessoasFisicas query)
    {
        var result = await query.Execute(page.Value, rows.Value);

        return Results.Ok(result);
    }




}
