using Microsoft.Data.SqlClient;
using TirandoAsRodinhas.Endpoints;

namespace TirandoAsRodinhas.Infra.Data;

public class QueryParceiros
{
    private readonly IConfiguration configuration;

    public QueryParceiros(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<ParceirosResponse>> Execute(string filtro)
    {
        var db = new SqlConnection(configuration["ConnectionString:BiciSemRodinhas"]);
        var query =
            @"
          SELECT
               CPF_CNPJ, NOME_RAZAO, CEP, Logradouro, Complemento,
               Numero, Bairro, Cidade, Estado, Email, TelCelular, TelFixo,
               CreatedOn, ParceiroId
          FROM VW_Parceiros
          WHERE CPF_CNPJ = @filtro
            "; //OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY --> Pesquisa por paginação
        return await db.QueryAsync<ParceirosResponse>( query, new {filtro}
        );

    }
}
