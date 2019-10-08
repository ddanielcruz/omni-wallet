using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class PessoaFisicaFiscal
    {
        public int Id { get; set; }
        public short? IdProfissao { get; set; }
        public string EmpresaTrabalho { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public EstadoCivil? EstadoCivil { get; set; }

        public virtual PessoaFisica Pessoa { get; set; }
        public virtual Profissao Profissao { get; set; }
    }
}