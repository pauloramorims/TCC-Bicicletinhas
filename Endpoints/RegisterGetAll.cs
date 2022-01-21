using TirandoAsRodinhas.Infra.Data;
using TirandoAsRodinhas.Domain.Register;
namespace TirandoAsRodinhas.Endpoints;



public class RegisterGetAll
{
    public static string Template => "/registers";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;



    public static IResult Action(ApplicationDbContext context)
    {
        var registers = context.Parceiros.ToList();
        var response = registers.Select(c => new RegisterResponse { Id = c.Id, Active = c.Active, CreatedOn = c.CreatedOn });


        return Results.Ok(response);
    }




}
