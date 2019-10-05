using OmniWallet.Database.Contracts.Persistence.Enumerations;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Endereco
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public int IdCidade { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Referencia { get; set; }
        public TipoEndereco? Tipo { get; set; }

        public virtual Pessoa Pessoa { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}