using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;
using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public abstract class ContatoConfiguration<TContato> : IEntityTypeConfiguration<TContato> where TContato : Contato
    {
        public const int DescricaoMaxLength = 32;
        
        public virtual void Configure(EntityTypeBuilder<TContato> builder)
        {
            // Properties
            builder
                .Property(x => x.Descricao)
                .HasMaxLength(DescricaoMaxLength);
            
            builder
                .Property(x => x.Tipo)
                .IsRequired()
                .HasDefaultValue(TipoContato.Outro);
        }
    }
}