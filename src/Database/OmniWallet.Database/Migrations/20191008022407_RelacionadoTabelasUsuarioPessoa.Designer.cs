﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OmniWallet.Database.Persistence;

namespace OmniWallet.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191008022407_RelacionadoTabelasUsuarioPessoa")]
    partial class RelacionadoTabelasUsuarioPessoa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("IdEstado")
                        .HasColumnName("id_estado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(200);

                    b.HasKey("Id")
                        .HasName("pk_cidades");

                    b.HasIndex("IdEstado")
                        .HasName("ix_cidades_id_estado");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasName("ix_cidades_nome");

                    b.ToTable("cidades");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnName("descricao");

                    b.Property<int>("IdPessoa")
                        .HasColumnName("id_pessoa");

                    b.Property<byte>("Tipo")
                        .HasColumnName("tipo");

                    b.Property<string>("Valor")
                        .IsRequired()
                        .HasColumnName("valor")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("pk_emails");

                    b.HasIndex("IdPessoa")
                        .HasName("ix_emails_id_pessoa");

                    b.HasIndex("Valor")
                        .IsUnique()
                        .HasName("ix_emails_valor");

                    b.ToTable("emails");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnName("bairro")
                        .HasMaxLength(20);

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnName("cep")
                        .HasMaxLength(10);

                    b.Property<string>("Complemento")
                        .HasColumnName("complemento")
                        .HasMaxLength(20);

                    b.Property<int>("IdCidade")
                        .HasColumnName("id_cidade");

                    b.Property<int>("IdPessoa")
                        .HasColumnName("id_pessoa");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("numero")
                        .HasMaxLength(10);

                    b.Property<string>("Referencia")
                        .HasColumnName("referencia")
                        .HasMaxLength(256);

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnName("rua")
                        .HasMaxLength(50);

                    b.Property<byte?>("Tipo")
                        .HasColumnName("tipo");

                    b.HasKey("Id")
                        .HasName("pk_enderecos");

                    b.HasIndex("IdCidade")
                        .HasName("ix_enderecos_id_cidade");

                    b.HasIndex("IdPessoa")
                        .HasName("ix_enderecos_id_pessoa");

                    b.ToTable("enderecos");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<short>("IdPais")
                        .HasColumnName("id_pais");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("pk_estados");

                    b.HasIndex("IdPais")
                        .HasName("ix_estados_id_pais");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasName("ix_estados_nome");

                    b.ToTable("estados");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Pais", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("DDI")
                        .IsRequired()
                        .HasColumnName("ddi")
                        .HasMaxLength(4);

                    b.Property<string>("ISO2")
                        .HasColumnName("iso2")
                        .IsFixedLength(true)
                        .HasMaxLength(2);

                    b.Property<string>("ISO3")
                        .HasColumnName("iso3")
                        .IsFixedLength(true)
                        .HasMaxLength(3);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(100);

                    b.HasKey("Id")
                        .HasName("pk_paises");

                    b.HasIndex("DDI")
                        .IsUnique()
                        .HasName("ix_paises_ddi");

                    b.HasIndex("ISO2")
                        .IsUnique()
                        .HasName("ix_paises_iso2");

                    b.HasIndex("ISO3")
                        .IsUnique()
                        .HasName("ix_paises_iso3");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasName("ix_paises_nome");

                    b.ToTable("paises");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("IdPessoaFisica")
                        .HasColumnName("id_pessoa_fisica");

                    b.Property<int?>("IdPessoaJuridica")
                        .HasColumnName("id_pessoa_juridica");

                    b.Property<int>("IdUsuario")
                        .HasColumnName("id_usuario");

                    b.HasKey("Id")
                        .HasName("pk_pessoas");

                    b.HasIndex("IdPessoaFisica")
                        .IsUnique()
                        .HasName("ix_pessoas_id_pessoa_fisica");

                    b.HasIndex("IdPessoaJuridica")
                        .IsUnique()
                        .HasName("ix_pessoas_id_pessoa_juridica");

                    b.HasIndex("IdUsuario")
                        .IsUnique()
                        .HasName("ix_pessoas_id_usuario");

                    b.ToTable("pessoas");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnName("data_nascimento");

                    b.Property<int?>("IdPessoaFisicaFiscal")
                        .HasColumnName("id_pessoa_fisica_fiscal");

                    b.Property<int?>("IdPessoaFisicaSaude")
                        .HasColumnName("id_pessoa_fisica_saude");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(32);

                    b.Property<byte?>("OrientacaoSexual")
                        .HasColumnName("orientacao_sexual");

                    b.Property<byte?>("Sexo")
                        .HasColumnName("sexo");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnName("sobrenome")
                        .HasMaxLength(64);

                    b.HasKey("Id")
                        .HasName("pk_pessoas_fisicas");

                    b.HasIndex("IdPessoaFisicaFiscal")
                        .IsUnique()
                        .HasName("ix_pessoas_fisicas_id_pessoa_fisica_fiscal");

                    b.HasIndex("IdPessoaFisicaSaude")
                        .IsUnique()
                        .HasName("ix_pessoas_fisicas_id_pessoa_fisica_saude");

                    b.ToTable("pessoas_fisicas");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisicaFiscal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("CNH")
                        .HasColumnName("cnh")
                        .IsFixedLength(true)
                        .HasMaxLength(11);

                    b.Property<string>("CPF")
                        .HasColumnName("cpf")
                        .IsFixedLength(true)
                        .HasMaxLength(11);

                    b.Property<string>("EmpresaTrabalho")
                        .HasColumnName("empresa_trabalho")
                        .HasMaxLength(50);

                    b.Property<byte?>("EstadoCivil")
                        .HasColumnName("estado_civil");

                    b.Property<short?>("IdProfissao")
                        .HasColumnName("id_profissao");

                    b.Property<string>("RG")
                        .HasColumnName("rg")
                        .HasMaxLength(20);

                    b.HasKey("Id")
                        .HasName("pk_pessoas_fisicas_fiscal");

                    b.HasIndex("IdProfissao")
                        .HasName("ix_pessoas_fisicas_fiscal_id_profissao");

                    b.ToTable("pessoas_fisicas_fiscal");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisicaSaude", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<byte?>("FrequenciaBebida")
                        .HasColumnName("frequencia_bebida");

                    b.Property<byte?>("FrequenciaEsportes")
                        .HasColumnName("frequencia_esportes");

                    b.Property<bool?>("Fuma")
                        .HasColumnName("fuma");

                    b.HasKey("Id")
                        .HasName("pk_pessoas_fisicas_saudes");

                    b.ToTable("pessoas_fisicas_saudes");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaJuridica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("cnpj")
                        .IsFixedLength(true)
                        .HasMaxLength(14);

                    b.Property<string>("Dominio")
                        .IsRequired()
                        .HasColumnName("dominio")
                        .HasMaxLength(10);

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnName("nome_fantasia")
                        .HasMaxLength(255);

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnName("razao_social")
                        .HasMaxLength(255);

                    b.HasKey("Id")
                        .HasName("pk_pessoas_juridicas");

                    b.HasIndex("CNPJ")
                        .IsUnique()
                        .HasName("ix_pessoas_juridicas_cnpj");

                    b.HasIndex("Dominio")
                        .IsUnique()
                        .HasName("ix_pessoas_juridicas_dominio");

                    b.HasIndex("RazaoSocial")
                        .IsUnique()
                        .HasName("ix_pessoas_juridicas_razao_social");

                    b.ToTable("pessoas_juridicas");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaRedeSocial", b =>
                {
                    b.Property<int>("IdPessoa")
                        .HasColumnName("id_pessoa");

                    b.Property<byte>("IdRedeSocial")
                        .HasColumnName("id_rede_social");

                    b.Property<string>("Perfil")
                        .HasColumnName("perfil");

                    b.HasKey("IdPessoa", "IdRedeSocial")
                        .HasName("pk_pessoas_redes_sociais");

                    b.HasIndex("IdRedeSocial")
                        .HasName("ix_pessoas_redes_sociais_id_rede_social");

                    b.ToTable("pessoas_redes_sociais");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Profissao", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(50);

                    b.HasKey("Id")
                        .HasName("pk_profissoes");

                    b.ToTable("profissoes");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.RedeSocial", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnName("id");

                    b.Property<bool>("Integrado")
                        .HasColumnName("integrado");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("nome")
                        .HasMaxLength(32);

                    b.HasKey("Id")
                        .HasName("pk_redes_sociais");

                    b.HasIndex("Nome")
                        .IsUnique()
                        .HasName("ix_redes_sociais_nome");

                    b.ToTable("redes_sociais");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Descricao")
                        .HasColumnName("descricao");

                    b.Property<short>("IdPais")
                        .HasColumnName("id_pais");

                    b.Property<int>("IdPessoa")
                        .HasColumnName("id_pessoa");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("numero")
                        .HasMaxLength(15);

                    b.Property<byte>("Tipo")
                        .HasColumnName("tipo");

                    b.HasKey("Id")
                        .HasName("pk_telefones");

                    b.HasIndex("IdPais")
                        .HasName("ix_telefones_id_pais");

                    b.HasIndex("IdPessoa")
                        .HasName("ix_telefones_id_pessoa");

                    b.ToTable("telefones");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ativo")
                        .HasDefaultValue(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasMaxLength(255);

                    b.Property<bool>("EmailConfirmado")
                        .HasColumnName("email_confirmado");

                    b.Property<DateTime>("MembroDesde")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("membro_desde")
                        .HasDefaultValueSql("NOW()");

                    b.Property<byte[]>("SenhaHash")
                        .IsRequired()
                        .HasColumnName("senha_hash")
                        .IsFixedLength(true)
                        .HasMaxLength(64);

                    b.Property<byte[]>("SenhaSalt")
                        .IsRequired()
                        .HasColumnName("senha_salt")
                        .IsFixedLength(true)
                        .HasMaxLength(128);

                    b.HasKey("Id")
                        .HasName("pk_usuarios");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasName("ix_usuarios_email");

                    b.ToTable("usuarios");
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Cidade", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("IdEstado")
                        .HasConstraintName("fk_cidades_estados_id_estado")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Email", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", "Pessoa")
                        .WithMany("Emails")
                        .HasForeignKey("IdPessoa")
                        .HasConstraintName("fk_emails_pessoas_id_pessoa")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Endereco", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Cidade", "Cidade")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdCidade")
                        .HasConstraintName("fk_enderecos_cidades_id_cidade")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", "Pessoa")
                        .WithMany("Enderecos")
                        .HasForeignKey("IdPessoa")
                        .HasConstraintName("fk_enderecos_pessoas_id_pessoa")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Estado", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("IdPais")
                        .HasConstraintName("fk_estados_paises_id_pais")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisica", "PessoaFisica")
                        .WithOne("Pessoa")
                        .HasForeignKey("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", "IdPessoaFisica")
                        .HasConstraintName("fk_pessoas_pessoas_fisicas_id_pessoa_fisica")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.PessoaJuridica", "PessoaJuridica")
                        .WithOne("Pessoa")
                        .HasForeignKey("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", "IdPessoaJuridica")
                        .HasConstraintName("fk_pessoas_pessoas_juridicas_id_pessoa_juridica")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Usuario", "Usuario")
                        .WithOne("Pessoa")
                        .HasForeignKey("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", "IdUsuario")
                        .HasConstraintName("fk_pessoas_usuarios_id_usuario")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisica", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisicaFiscal", "Fiscal")
                        .WithOne("Pessoa")
                        .HasForeignKey("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisica", "IdPessoaFisicaFiscal")
                        .HasConstraintName("fk_pessoas_fisicas_pessoas_fisicas_fiscal_id_pessoa_fisica_fis~")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisicaSaude", "Saude")
                        .WithOne("Pessoa")
                        .HasForeignKey("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisica", "IdPessoaFisicaSaude")
                        .HasConstraintName("fk_pessoas_fisicas_pessoas_fisicas_saudes_id_pessoa_fisica_sau~")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaFisicaFiscal", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Profissao", "Profissao")
                        .WithMany("PessoasFisicasFiscal")
                        .HasForeignKey("IdProfissao")
                        .HasConstraintName("fk_pessoas_fisicas_fiscal_profissoes_id_profissao")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.PessoaRedeSocial", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", "Pessoa")
                        .WithMany("PessoasRedesSociais")
                        .HasForeignKey("IdPessoa")
                        .HasConstraintName("fk_pessoas_redes_sociais_pessoas_id_pessoa")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.RedeSocial", "RedeSocial")
                        .WithMany("PessoasRedeSociais")
                        .HasForeignKey("IdRedeSocial")
                        .HasConstraintName("fk_pessoas_redes_sociais_redes_sociais_id_rede_social")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("OmniWallet.Database.Contracts.Persistence.Domain.Telefone", b =>
                {
                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Pais", "Pais")
                        .WithMany("Telefones")
                        .HasForeignKey("IdPais")
                        .HasConstraintName("fk_telefones_paises_id_pais")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("OmniWallet.Database.Contracts.Persistence.Domain.Pessoa", "Pessoa")
                        .WithMany("Telefones")
                        .HasForeignKey("IdPessoa")
                        .HasConstraintName("fk_telefones_pessoas_id_pessoa")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
