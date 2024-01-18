﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TRABALHOELETROPONTO.Data;

#nullable disable

namespace TRABALHOELETROPONTO.Migrations.Produto
{
    [DbContext(typeof(ProdutoContext))]
    [Migration("20231216175437_mig4")]
    partial class mig4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TRABALHOELETROPONTO.Models.Produto", b =>
                {
                    b.Property<int>("ID_PRODUTO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("DESCRICAO")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ESTOQUE")
                        .HasColumnType("int");

                    b.Property<string>("NOME_PRODUTO")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float?>("PRECO")
                        .HasColumnType("float");

                    b.HasKey("ID_PRODUTO");

                    b.ToTable("Produto");
                });
#pragma warning restore 612, 618
        }
    }
}