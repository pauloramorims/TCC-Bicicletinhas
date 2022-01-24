namespace TirandoAsRodinhas.Endpoints.Financeiro;

public record class DocFinanceiroRequest (Guid ParceiroID, float Valor, string Movimentacao, string Observacao, 
                                          Guid EmpresaId);