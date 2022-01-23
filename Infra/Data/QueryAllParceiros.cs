using Microsoft.Data.SqlClient;
using TirandoAsRodinhas.Endpoints;

namespace TirandoAsRodinhas.Infra.Data;

public class QueryAllParceiros
{
    private readonly IConfiguration configuration;

    public QueryAllParceiros(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public async Task<IEnumerable<ParceirosResponse>> Execute()
    {
        var db = new SqlConnection(configuration["ConnectionString:BiciSemRodinhas"]);
        var query =
            @"
           SELECT*
            FROM(
                SELECT 'PESSOA JURIDICA' AS TIPO
                    ,pj.CNPJ as CPF_CNPJ, pj.RazaoSocial as NOME_RAZAO, e.CEP, e.Logradouro, e.Complemento,
                    e.Numero, e.Bairro, e.Cidade, e.Estado, c.Email, c.TelCelular, c.TelFixo,
                    p.CreatedOn, p.Id as ParceiroId
                FROM PessoaJuridicas pj
                INNER JOIN Parceiros p on
                pj.ParceiroId = p.Id
                INNER JOIN Enderecos e on
                p.EnderecoId = e.Id
                INNER JOIN Contatos c on
                c.Id = p.ContatoId
                
                UNION ALL
            
                SELECT 'PESSOA FISICA' AS TIPO
                    ,pf.Cpf as CPF_CNPJ, pf.Nome as NOME_RAZAO, e.CEP, e.Logradouro, e.Complemento,
                    e.Numero, e.Bairro, e.Cidade, e.Estado, c.Email, c.TelCelular, c.TelFixo,
                    p.CreatedOn, p.Id as ParceiroId
                FROM PessoasFisicas pf
                INNER JOIN Parceiros p on
                pf.ParceiroId = p.Id
                INNER JOIN Enderecos e on
                p.EnderecoId = e.Id
                INNER JOIN Contatos c on
                c.Id = p.ContatoId) PARCEIROS
            "; //OFFSET (@page -1 ) * @rows ROWS FETCH NEXT @rows ROWS ONLY --> Pesquisa por paginação
        return await db.QueryAsync<ParceirosResponse>( query, new {}
        );

    }
}
