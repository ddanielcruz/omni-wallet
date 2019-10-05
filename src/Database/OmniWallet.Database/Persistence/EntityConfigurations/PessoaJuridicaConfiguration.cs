using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PessoaJuridicaConfiguration : IEntityTypeConfiguration<PessoaJuridica>
    {
        public const int NomeFantasiaMaxLength = 255;
        public const int RazaoSocialMaxLength = 255;
        public const int DominioMaxLength = 10;
        public const int CNPJFixedLength = 14;
        
        public void Configure(EntityTypeBuilder<PessoaJuridica> builder)
        {
            builder.ToTable("pessoas_juridicas");
            
            // Properties
            builder
                .Property(x => x.NomeFantasia)
                .IsRequired()
                .HasMaxLength(NomeFantasiaMaxLength);

            builder
                .Property(x => x.RazaoSocial)
                .IsRequired()
                .HasMaxLength(RazaoSocialMaxLength);

            builder
                .Property(x => x.Dominio)
                .IsRequired()
                .HasMaxLength(DominioMaxLength);

            builder
                .Property(x => x.CNPJ)
                .IsRequired()
                .HasMaxLength(CNPJFixedLength)
                .IsFixedLength();
            
            // Indexes
            builder
                .HasIndex(x => x.RazaoSocial)
                .IsUnique();

            builder
                .HasIndex(x => x.Dominio)
                .IsUnique();

            builder
                .HasIndex(x => x.CNPJ)
                .IsUnique();
        }
    }
}