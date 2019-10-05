using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PessoaRedeSocialConfiguration : IEntityTypeConfiguration<PessoaRedeSocial>
    {
        public void Configure(EntityTypeBuilder<PessoaRedeSocial> builder)
        {
            builder.ToTable("pessoas_redes_sociais");
            builder
                .HasKey(x => new
                {
                    x.IdPessoa,
                    x.IdRedeSocial
                });
            
            // Properties
            builder
                .HasOne(x => x.RedeSocial)
                .WithMany(x => x.PessoasRedeSociais)
                .HasForeignKey(x => x.IdRedeSocial)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Pessoa)
                .WithMany(x => x.PessoasRedesSociais)
                .HasForeignKey(x => x.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}