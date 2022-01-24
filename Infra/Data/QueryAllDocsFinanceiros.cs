using TirandoAsRodinhas.Endpoints.Financeiro;

namespace TirandoAsRodinhas.Infra.Data;

public class QueryAllDocsFinanceiros
{
    private readonly IConfiguration configuration;

    public QueryAllDocsFinanceiros(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<DocFinanceiroResponse>> Execute()
    {
        var db = new SqlConnection(configuration["ConnectionString:BiciSemRodinhas"]);
        var query =
            @"
          SELECT 
                p.*, df.Movimentacao, df.Valor, df.Observacao, ep.CNPJ AS EMP_Cnpj, 
                ep.RazaoSocial as EMP_Razao, c.Email as EMP_Email, c.TelCelular as EMP_Celu, 
                c.TelFixo as EMP_Fixo, e.CEP as EMP_Cep, e.Logradouro as EMP_Logradouro,
                e.Bairro as EMP_Bairro, e.Numero as EMP_Numero, e.Complemento as EMP_Complemento,
                e.Cidade as EMP_Cidade, e.Estado as EMP_Estado
          FROM DocsFinanceiros df
            INNER JOIN Empresas ep ON
                ep.Id=df.EmpresaId
            INNER JOIN Enderecos e ON
                ep.EnderecoId = e.Id
            INNER JOIN Contatos c ON
                ep.ContatoId=c.Id
            INNER JOIN [dbo].[VW_Parceiros] p ON
                p.ParceiroId = df.ParceiroId
            "; //OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY --> Pesquisa por paginação
        return await db.QueryAsync<DocFinanceiroResponse>( query, new {}
        );

    }
}
