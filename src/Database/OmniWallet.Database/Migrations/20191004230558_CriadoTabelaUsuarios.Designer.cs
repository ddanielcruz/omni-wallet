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
    [Migration("20191004230558_CriadoTabelaUsuarios")]
    partial class CriadoTabelaUsuarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

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
#pragma warning restore 612, 618
        }
    }
}
