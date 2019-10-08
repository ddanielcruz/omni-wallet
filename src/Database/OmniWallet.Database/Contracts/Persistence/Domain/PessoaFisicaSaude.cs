using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class PessoaFisicaSaude
    {
        public int Id { get; set; }
        public bool? Fuma { get; set; }
        public FrequenciaBebida? FrequenciaBebida { get; set; }
        public FrequenciaEsportes? FrequenciaEsportes { get; set; }

        public virtual PessoaFisica Pessoa { get; set; }
    }
}