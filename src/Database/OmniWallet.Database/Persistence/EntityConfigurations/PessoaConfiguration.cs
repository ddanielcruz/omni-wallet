using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("pessoas");
            
            // Relationships
            builder
                .HasOne(x => x.PessoaFisica)
                .WithOne(x => x.Pessoa)
                .HasForeignKey<Pessoa>(x => x.IdPessoaFisica)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder
                .HasOne(x => x.PessoaJuridica)
                .WithOne(x => x.Pessoa)
                .HasForeignKey<Pessoa>(x => x.IdPessoaJuridica)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);

            builder
                .HasMany(x => x.Emails)
                .WithOne(x => x.Pessoa)
                .HasForeignKey(x => x.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasMany(x => x.Telefones)
                .WithOne(x => x.Pessoa)
                .HasForeignKey(x => x.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}