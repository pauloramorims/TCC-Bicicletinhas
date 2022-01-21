using Microsoft.Data.SqlClient;
using TirandoAsRodinhas.Endpoints;

namespace TirandoAsRodinhas.Infra.Data;

public class QueryAllPessoasFisicas
{
    private readonly IConfiguration configuration;

    public QueryAllPessoasFisicas(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<PessoasFisResponse>> Execute(int page, int rows)
    {
        var db = new SqlConnection(configuration["ConnectionString:BiciSemRodinhas"]);
        var query =
            @"
            SELECT
                pf.Cpf, pf.Nome, c.Email
            FROM PessoasFisicas pf
            INNER JOIN Parceiros p on
            pf.ParceiroId = p.Id
            INNER JOIN Enderecos e on
            p.EnderecoId = e.Id
            INNER JOIN Contatos c on
            c.Id = p.ContatoId
            order by pf.Nome
            OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY";
        return await db.QueryAsync<PessoasFisResponse>( query, new { page, rows }
        );
    }
    /*, p.Id as ParceiroId, e.CEP, e.Logradouro, e.Complemento,
                e.Numero, e.Bairro, e.Cidade, e.Estado, c.Email, c.TelCelular, c.TelFixo,
                p.CreatedOn
    */
}
