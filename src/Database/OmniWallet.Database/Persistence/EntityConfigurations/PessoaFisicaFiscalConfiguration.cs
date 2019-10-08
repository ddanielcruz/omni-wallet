using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OmniWallet.Database.Contracts.Persistence.Domain;

namespace OmniWallet.Database.Persistence.EntityConfigurations
{
    public class PessoaFisicaFiscalConfiguration : IEntityTypeConfiguration<PessoaFisicaFiscal>
    {
        public const int RGMaxLength = 20;
        public const int CPFFixedLength = 11;
        public const int CNHFixedLength = 11;
        public const int EmpresaTrabalhoMaxLength = 50;
        
        public void Configure(EntityTypeBuilder<PessoaFisicaFiscal> builder)
        {
            builder.ToTable("pessoas_fisicas_fiscal");
            
            // Properties
            builder
                .Property(x => x.RG)
                .HasMaxLength(RGMaxLength);

            builder
                .Property(x => x.CPF)
                .HasMaxLength(CPFFixedLength)
                .IsFixedLength();

            builder
                .Property(x => x.CNH)
                .HasMaxLength(CNHFixedLength)
                .IsFixedLength();

            builder
                .Property(x => x.EmpresaTrabalho)
                .HasMaxLength(EmpresaTrabalhoMaxLength);
            
            // Relationships
            builder
                .HasOne(x => x.Profissao)
                .WithMany(x => x.PessoasFisicasFiscal)
                .HasForeignKey(x => x.IdProfissao)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired(false);
        }
    }
}