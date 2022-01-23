using Microsoft.Data.SqlClient;
using TirandoAsRodinhas.Endpoints;

namespace TirandoAsRodinhas.Infra.Data;

public class QueryAllPessoasFisica
{
    private readonly IConfiguration configuration;

    public QueryAllPessoasFisica(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<PessoasFisResponse>> Execute()
    {
        var db = new SqlConnection(configuration["ConnectionString:BiciSemRodinhas"]);
        var query =
            @"
            SELECT
                pf.Cpf, pf.Nome, c.Email, e.CEP, e.Logradouro, e.Complemento,
                e.Numero, e.Bairro, e.Cidade, e.Estado, c.TelCelular, c.TelFixo,
                p.CreatedOn, p.Id
            FROM PessoasFisicas pf
            INNER JOIN Parceiros p on
            pf.ParceiroId = p.Id
            INNER JOIN Enderecos e on
            p.EnderecoId = e.Id
            INNER JOIN Contatos c on
            c.Id = p.ContatoId
            order by pf.Nome
            "; //OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY --> Pesquisa por paginação
        return await db.QueryAsync<PessoasFisResponse>( query, new {}
        );

    }
}
