using TirandoAsRodinhas.Infra.Data;
using TirandoAsRodinhas.Domain.Register;

namespace TirandoAsRodinhas.Endpoints;



public class PessoasJuriGetAll
{
    public static string Template => "/pessoasjuridica";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;



    public static async Task<IResult> Action( QueryAllPessoasJuridica query)
    {
        var result = await query.Execute();

        return Results.Ok(result);
    }




}
