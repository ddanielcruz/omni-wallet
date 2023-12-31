using System.Collections.Generic;

namespace OmniWallet.Database.Contracts.Persistence.Domain
{
    public class Pessoa
    {
        public Pessoa()
        {
            Emails = new HashSet<Email>();
            Telefones = new HashSet<Telefone>();
            PessoasRedesSociais = new HashSet<PessoaRedeSocial>();
            Enderecos = new HashSet<Endereco>();
        }
        
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int? IdPessoaFisica { get; set; }
        public int? IdPessoaJuridica { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Telefone> Telefones { get; set; }
        public virtual ICollection<PessoaRedeSocial> PessoasRedesSociais { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}