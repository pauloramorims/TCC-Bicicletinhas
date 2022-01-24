namespace TirandoAsRodinhas.Endpoints.Financeiro;

public record class DocFinanceiroResponse(string TIPO, string CPF_CNPJ, string NOME_RAZAO, string CEP, string Logradouro,
                                          string Complemento, int Numero, string Bairro, string Cidade, string Estado, string Email,
                                          string TelCelular, string TelFixo, DateTime CreatedOn, Guid ParceiroId, string Movimentacao,
                                          float Valor, string Observacao, string EMP_Cnpj, string EMP_Razao, string EMP_Email, string EMP_Celu,
                                          string EMP_Fixo, string EMP_Cep, string EMP_Logradouro, string EMP_Bairro, int EMP_Numero, string EMP_Complemento,
                                          string EMP_Cidade, string EMP_Estado);

