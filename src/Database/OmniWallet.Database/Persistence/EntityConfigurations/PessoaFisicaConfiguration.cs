using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica>
    {
        public const int NomeMaxLength = 32;
        public const int SobrenomeMaxLength = 64;
        
        public void Configure(EntityTypeBuilder<PessoaFisica> builder)
        {
            builder.ToTable("pessoas_fisicas");
            
            // Properties
            builder
                .Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(NomeMaxLength);

            builder
                .Property(x => x.Sobrenome)
                .IsRequired()
                .HasMaxLength(SobrenomeMaxLength);
            
            // Relationships
            builder
                .HasOne(x => x.Saude)
                .WithOne(x => x.Pessoa)
                .HasForeignKey<PessoaFisica>(x => x.IdPessoaFisicaSaude)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
            
            builder
                .HasOne(x => x.Fiscal)
                .WithOne(x => x.Pessoa)
                .HasForeignKey<PessoaFisica>(x => x.IdPessoaFisicaFiscal)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}