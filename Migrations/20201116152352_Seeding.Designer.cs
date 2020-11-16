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
    [Migration("20201116152352_Seeding")]
    partial class Seeding
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("PsiConsulta.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profissao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PsicologoId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

            modelBuilder.Entity("PsiConsulta.Models.Paciente", b =>
                {
                    b.HasOne("PsiConsulta.Models.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.HasOne("PsiConsulta.Models.Psicologo", "Psicologo")
                        .WithMany("Pacientes")
                        .HasForeignKey("PsicologoId");

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
