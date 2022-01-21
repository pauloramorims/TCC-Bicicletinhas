using TirandoAsRodinhas.Domain.Cadastro;

namespace TirandoAsRodinhas.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Cadastro> Cadastros { get; set; }
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Parceiro> Parceiros { get; set; }
    public DbSet<PessoaFisica > PessoasFisicas { get; set; }
    public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder builder) //Configurando minhas colunas
    {
        builder.Ignore<Notification>(); //Não quero salvar no meu BD

        builder.Entity<Contato>()
            .Property(c => c.TelCelular).IsRequired();
        builder.Entity<Contato>()
            .Property(c => c.Email).IsRequired();

        builder.Entity<PessoaFisica>()
            .Property(pf => pf.Cpf).IsRequired();

        builder.Entity<PessoaJuridica>()
            .Property(pf => pf.CNPJ).IsRequired();
        builder.Entity<PessoaJuridica>()
            .Property(pf => pf.CNPJ).HasMaxLength(15);
        builder.Entity<PessoaJuridica>()
            .Property(pf => pf.RazaoSocial).IsRequired();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}