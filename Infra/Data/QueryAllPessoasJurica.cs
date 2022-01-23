using Microsoft.Data.SqlClient;
using TirandoAsRodinhas.Endpoints;

namespace TirandoAsRodinhas.Infra.Data;

public class QueryAllPessoasJuridica
{
    private readonly IConfiguration configuration;

    public QueryAllPessoasJuridica(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<PessoasJuriResponse>> Execute()
    {
        var db = new SqlConnection(configuration["ConnectionString:BiciSemRodinhas"]);
        var query =
            @"
           SELECT
                pj.CNPJ, pj.RazaoSocial, e.CEP, e.Logradouro, e.Complemento,
                e.Numero, e.Bairro, e.Cidade, e.Estado, c.Email, c.TelCelular, c.TelFixo, 
                p.CreatedOn, p.Id
            FROM PessoaJuridicas pj
            INNER JOIN Parceiros p on
            pj.ParceiroId = p.Id
            INNER JOIN Enderecos e on
            p.EnderecoId = e.Id
            INNER JOIN Contatos c on
            c.Id = p.ContatoId
            order by pj.RazaoSocial
            "; //OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY --> Pesquisa por paginação
        return await db.QueryAsync<PessoasJuriResponse>( query, new {}
        );

    }
}
