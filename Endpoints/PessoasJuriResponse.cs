namespace TirandoAsRodinhas.Infra.Data;

public record class PessoasJuriResponse (string CNPJ, string RazaoSocial, string Cep,  string Logradouro, string Complemento,
                int Numero, string Bairro, string Cidade, string Estado, string Email, string TelCelular, string TelFixo,
                DateTime CreatedOn, Guid Id);

/*pj.CNPJ, pj.RazaoSocial, e.CEP, e.Logradouro, e.Complemento,
e.Numero, e.Bairro, e.Cidade, e.Estado, c.Email, c.TelCelular, c.TelFixo, 
                p.CreatedOn, p.Id as ParceiroId
*/