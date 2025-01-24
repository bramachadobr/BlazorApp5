﻿// <auto-generated />
using System;
using BlazorApp5;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorApp5.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20250120160740_inicio2")]
    partial class inicio2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorApp5.Classes.Cidade", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("BlazorApp5.Classes.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ_CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inscricao_Municipal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inscricao_estadual")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("RasaoSocial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("BlazorApp5.Classes.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CNPJ_CPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inscricao_Municipal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inscricao_estadual")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("RasaoSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fornecedore");
                });

            modelBuilder.Entity("BlazorApp5.Classes.NotaFiscal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("AliquotaIss")
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodigoValidacao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DataEmissao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataExercicio")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Desconto")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("DescricaoDoServico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FornecedorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Numero")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Numero"));

                    b.Property<string>("NumeroNF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValorIss")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("NotaFiscals");
                });

            modelBuilder.Entity("BlazorApp5.Classes.NotaFiscal", b =>
                {
                    b.HasOne("BlazorApp5.Classes.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("BlazorApp5.Classes.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId");

                    b.Navigation("Cliente");

                    b.Navigation("Fornecedor");
                });
#pragma warning restore 612, 618
        }
    }
}
