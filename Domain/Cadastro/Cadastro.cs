namespace TirandoAsRodinhas.Domain.Cadastro;

public class Cadastro : Entity
{
    public DateTime CreatedOn { get; set; }
    public DateTime EditedOn { get; set; }
    public bool Active { get; set; } = true;
}
