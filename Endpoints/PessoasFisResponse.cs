using TirandoAsRodinhas.Domain.Register;

namespace TirandoAsRodinhas.Endpoints; 

public record class PessoasFisResponse (string Cpf, string Nome, string Email, string Cep, string Logradouro, string Complemento,
                int Numero, string Bairro, string Cidade, string Estado, string TelCelular, string TelFixo,
                DateTime CreatedOn, Guid Id );
/*{
    /*Preciso retornar
     id de parceiro
    cpf ou cnpj do meu parceiro
    nome ou razao do meu parceiro
    endereco completo 
     /*
     string Cpf, string Nome, string Cep, string Logradouro, string Complemento, int Numero, string Bairro, string Cidade, string Estado, string Email, string TelCelular, string TelFixo,

}
*/


