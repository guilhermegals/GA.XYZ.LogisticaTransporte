﻿// <auto-generated />
using GA.XYZ.LeT.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GA.XYZ.LeT.Infra.Data.Migrations
{
    [DbContext(typeof(LeTContext))]
    [Migration("20180428000930_Correcoes")]
    partial class Correcoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GA.XYZ.LeT.Domain.Fornecedores.Contato", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(16)
                        .IsUnicode(true);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<Guid>("IdFornecedor")
                        .HasMaxLength(16);

                    b.Property<string>("Nome")
                        .HasMaxLength(150);

                    b.Property<string>("Telefone")
                        .HasMaxLength(18);

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("GA.XYZ.LeT.Domain.Fornecedores.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(16)
                        .IsUnicode(true);

                    b.Property<bool>("Ativo");

                    b.Property<string>("Cidade")
                        .HasMaxLength(50);

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime?>("PeriodoVigenciaFim")
                        .HasMaxLength(8);

                    b.Property<DateTime>("PeriodoVigenciaInicio")
                        .HasMaxLength(8);

                    b.Property<decimal>("ValorMaxDemanda")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("GA.XYZ.LeT.Domain.Fornecedores.Contato", b =>
                {
                    b.HasOne("GA.XYZ.LeT.Domain.Fornecedores.Fornecedor", "Fornecedor")
                        .WithMany("Contatos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
