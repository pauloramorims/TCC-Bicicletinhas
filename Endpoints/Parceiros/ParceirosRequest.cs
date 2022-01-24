namespace TirandoAsRodinhas.Endpoints.Parceiros;

public record class ParceirosRequest(string Cep, string Logradouro, int Numero, string Complemento, string Bairro, string Cidade,
                                      string Estado, string TelCelular, string TelFixo, string Email, string CPF_CNPJ, string Nome_Razao , Guid EmpresaID);
//