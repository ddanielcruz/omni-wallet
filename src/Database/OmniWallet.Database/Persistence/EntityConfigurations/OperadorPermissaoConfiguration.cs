using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class OperadorPermissaoConfiguration : IEntityTypeConfiguration<OperadorPermissao>
    {
        public void Configure(EntityTypeBuilder<OperadorPermissao> builder)
        {
            builder.ToTable("operadores_permissoes");
            builder.HasKey(x => new
            {
                x.IdOperador,
                x.IdPermissao
            });

            // Relationships
            builder
                .HasOne(x => x.Operador)
                .WithMany(x => x.Permissoes)
                .HasForeignKey(x => x.IdOperador)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(x => x.Permissao)
                .WithMany(x => x.Operadores)
                .HasForeignKey(x => x.IdPermissao)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}