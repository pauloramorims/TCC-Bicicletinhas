using TirandoAsRodinhas.Domain.Register;
using TirandoAsRodinhas.Domain.FinancesDoc;

namespace TirandoAsRodinhas.Infra.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Contato> Contatos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Parceiro> Parceiros { get; set; }
    public DbSet<PessoaFisica> PessoasFisicas { get; set; }
    public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<DocFinanceiro> DocsFinanceiros { get; set; }

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
        builder.Entity<PessoaFisica>()
            .Property(pf => pf.Nome).IsRequired();

        builder.Entity<PessoaJuridica>()
            .Property(pf => pf.CNPJ).IsRequired();
        builder.Entity<PessoaJuridica>()
            .Property(pf => pf.CNPJ).HasMaxLength(15);
        builder.Entity<PessoaJuridica>()
            .Property(pf => pf.RazaoSocial).IsRequired();

        builder.Entity<Parceiro>()
            .HasOne(p => p.Empresa)
            .WithMany(k => k.Parceiros)
            .HasForeignKey(p => p.EmpresaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<DocFinanceiro>()
           .HasOne(p => p.Parceiro)
           .WithMany(k => k.Documentos)
           .HasForeignKey(p => p.ParceiroId)
           .OnDelete(DeleteBehavior.NoAction);

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configuration)
    {
        configuration.Properties<string>()
            .HaveMaxLength(100);
    }
}