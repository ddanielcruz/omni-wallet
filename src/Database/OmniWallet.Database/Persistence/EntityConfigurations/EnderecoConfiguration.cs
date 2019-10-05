using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public const int RuaMaxLength = 50;
        public const int NumeroMaxLength = 10;
        public const int BairroMaxLength = 20;
        public const int ComplementoMaxLength = 20;
        public const int CEPMaxLength = 10;
        public const int ReferenciaMaxLength = 256;
        
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("enderecos");
            
            // Properties
            builder
                .Property(x => x.Rua)
                .IsRequired()
                .HasMaxLength(RuaMaxLength);

            builder
                .Property(x => x.Numero)
                .IsRequired()
                .HasMaxLength(NumeroMaxLength);

            builder
                .Property(x => x.Bairro)
                .IsRequired()
                .HasMaxLength(BairroMaxLength);

            builder
                .Property(x => x.Complemento)
                .HasMaxLength(ComplementoMaxLength);

            builder
                .Property(x => x.CEP)
                .IsRequired()
                .HasMaxLength(CEPMaxLength);

            builder
                .Property(x => x.Referencia)
                .HasMaxLength(ReferenciaMaxLength);
            
            // Relationships
            builder
                .HasOne(x => x.Pessoa)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.IdPessoa)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasOne(x => x.Cidade)
                .WithMany(x => x.Enderecos)
                .HasForeignKey(x => x.IdCidade)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}