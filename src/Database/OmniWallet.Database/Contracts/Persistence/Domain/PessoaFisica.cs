using System;
using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class PessoaFisica
    {
        public int Id { get; set; }
        public int? IdPessoaFisicaSaude { get; set; }
        public int? IdPessoaFisicaFiscal { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public Sexo? Sexo { get; set; }
        public OrientacaoSexual? OrientacaoSexual { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }
        public virtual PessoaFisicaSaude Saude { get; set; }
        public virtual PessoaFisicaFiscal Fiscal { get; set; }
    }
}