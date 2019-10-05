using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class TelefoneConfiguration : ContatoConfiguration<Telefone>
    {
        public const int NumeroMaxLength = 15;
        
        public override void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("telefones");
            
            // Properties
            builder
                .Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(NumeroMaxLength);
        }
    }
}