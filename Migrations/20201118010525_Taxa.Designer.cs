﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PsiConsulta.Context;

namespace PsiConsulta.Migrations
{
    [DbContext(typeof(PsiContext))]
    [Migration("20201118010525_Taxa")]
    partial class Taxa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("PsiConsulta.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Horario")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("PsicologoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Taxa")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.HasIndex("PsicologoId");

                    b.ToTable("Consulta");
                });

            modelBuilder.Entity("PsiConsulta.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("PsiConsulta.Models.Financiero.Carteira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Carteira");
                });

            modelBuilder.Entity("PsiConsulta.Models.Financiero.Movimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CarteiraId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.ToTable("Movimento");
                });

            modelBuilder.Entity("PsiConsulta.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PsicologoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("PsicologoId");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("PsiConsulta.Models.Prontuario", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("EvolucaoClinica")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HipoteseDiagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HistoricoClinico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PsicologoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PsicologoId");

                    b.ToTable("Prontuario");
                });

            modelBuilder.Entity("PsiConsulta.Models.Psicologo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("CarteiraId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CarteiraId");

                    b.ToTable("Psicologo");
                });

            modelBuilder.Entity("PsiConsulta.Models.Consulta", b =>
                {
                    b.HasOne("PsiConsulta.Models.Paciente", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId");

                    b.HasOne("PsiConsulta.Models.Psicologo", "Psicologo")
                        .WithMany("Consultas")
                        .HasForeignKey("PsicologoId");

                    b.Navigation("Paciente");

                    b.Navigation("Psicologo");
                });

            modelBuilder.Entity("PsiConsulta.Models.Financiero.Movimento", b =>
                {
                    b.HasOne("PsiConsulta.Models.Financiero.Carteira", "Carteira")
                        .WithMany("Movimentos")
                        .HasForeignKey("CarteiraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carteira");
                });

            modelBuilder.Entity("PsiConsulta.Models.Paciente", b =>
                {
                    b.HasOne("PsiConsulta.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("PsiConsulta.Models.Psicologo", "Psicologo")
                        .WithMany("Pacientes")
                        .HasForeignKey("PsicologoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Psicologo");
                });

            modelBuilder.Entity("PsiConsulta.Models.Prontuario", b =>
                {
                    b.HasOne("PsiConsulta.Models.Paciente", "Paciente")
                        .WithOne("Prontuario")
                        .HasForeignKey("PsiConsulta.Models.Prontuario", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PsiConsulta.Models.Psicologo", "Psicologo")
                        .WithMany()
                        .HasForeignKey("PsicologoId");

                    b.Navigation("Paciente");

                    b.Navigation("Psicologo");
                });

            modelBuilder.Entity("PsiConsulta.Models.Psicologo", b =>
                {
                    b.HasOne("PsiConsulta.Models.Financiero.Carteira", "Carteira")
                        .WithMany()
                        .HasForeignKey("CarteiraId");

                    b.Navigation("Carteira");
                });

            modelBuilder.Entity("PsiConsulta.Models.Financiero.Carteira", b =>
                {
                    b.Navigation("Movimentos");
                });

            modelBuilder.Entity("PsiConsulta.Models.Paciente", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Prontuario");
                });

            modelBuilder.Entity("PsiConsulta.Models.Psicologo", b =>
                {
                    b.Navigation("Consultas");

                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
