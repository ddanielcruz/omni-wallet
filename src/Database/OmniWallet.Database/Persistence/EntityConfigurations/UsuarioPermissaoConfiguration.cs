using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class UsuarioPermissaoConfiguration : IEntityTypeConfiguration<UsuarioPermissao>
    {
        public void Configure(EntityTypeBuilder<UsuarioPermissao> builder)
        {
            builder.ToTable("usuarios_permissoes");

            builder.HasKey(x => new
            {
                x.IdUsuario,
                x.IdPermissao
            });
            
            // Relationships
            builder
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Permissoes)
                .HasForeignKey(x => x.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder
                .HasOne(x => x.Permissao)
                .WithMany(x => x.Usuarios)
                .HasForeignKey(x => x.IdPermissao)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}