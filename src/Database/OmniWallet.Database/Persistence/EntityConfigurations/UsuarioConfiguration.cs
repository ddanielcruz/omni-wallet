using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public const int EmailMaxLength = 255;
        public const int SenhaMinLength = 8;
        
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuarios");
            
            // Properties
            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(EmailMaxLength);

            builder
                .Property(x => x.EmailConfirmado)
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

            builder
                .Property(x => x.MembroDesde)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            builder
                .Property(x => x.Ativo)
                .IsRequired()
                .HasDefaultValue(true);
            
            // Relationships
            builder
                .HasOne(x => x.Pessoa)
                .WithOne(x => x.Usuario)
                .HasForeignKey<Pessoa>(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.Restrict);

            // Indexes
            builder
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}