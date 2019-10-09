using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class OperadorConfiguration : IEntityTypeConfiguration<Operador>
    {
        public const int LoginMaxLength = 32;
        
        public void Configure(EntityTypeBuilder<Operador> builder)
        {
            builder.ToTable("operadores");
            
            // Properties
            builder
                .Property(x => x.Login)
                .HasMaxLength(LoginMaxLength)
                .IsRequired();
            
            builder
                .Property(x => x.SenhaHash)
                .IsRequired()
                .HasMaxLength(64)
                .IsFixedLength();

            builder
                .Property(x => x.SenhaSalt)
                .IsRequired()
                .HasMaxLength(128)
                .IsFixedLength();
        }
    }
}