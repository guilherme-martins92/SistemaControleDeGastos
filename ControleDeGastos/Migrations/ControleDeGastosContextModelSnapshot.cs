﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ControleDeGastos.Migrations
{
    [DbContext(typeof(ControleDeGastosContext))]
    partial class ControleDeGastosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("ControleDeGastos.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("ControleDeGastos.Models.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime");

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int?>("TipoContaId")
                        .HasColumnType("int");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("TipoContaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("ControleDeGastos.Models.TipoConta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("TipoConta");
                });

            modelBuilder.Entity("ControleDeGastos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ControleDeGastos.Models.Conta", b =>
                {
                    b.HasOne("ControleDeGastos.Models.Categoria", "Categoria")
                        .WithMany("contas")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("ControleDeGastos.Models.TipoConta", "TipoConta")
                        .WithMany("contas")
                        .HasForeignKey("TipoContaId");

                    b.HasOne("ControleDeGastos.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Categoria");

                    b.Navigation("TipoConta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ControleDeGastos.Models.Categoria", b =>
                {
                    b.Navigation("contas");
                });

            modelBuilder.Entity("ControleDeGastos.Models.TipoConta", b =>
                {
                    b.Navigation("contas");
                });
#pragma warning restore 612, 618
        }
    }
}
