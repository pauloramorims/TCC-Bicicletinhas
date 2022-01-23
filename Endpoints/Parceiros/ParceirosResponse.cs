namespace TirandoAsRodinhas.Endpoints;

public record class ParceirosResponse(string Tipo, string CPF_CNPJ, string NOME_RAZAO, string CEP, string Logradouro, string Complemento,
                    int Numero, string Bairro, string Cidade, string Estado, string Email, string TelCelular, string TelFixo,
                    DateTime CreatedOn, Guid ParceiroId);

