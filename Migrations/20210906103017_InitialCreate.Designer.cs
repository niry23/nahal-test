﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NahalTest.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NahalTest.Migrations
{
    [DbContext(typeof(EntrepriseContext))]
    [Migration("20210906103017_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("NahalTest.Models.Entreprise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CodeNaf")
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Impot")
                        .HasColumnType("integer");

                    b.Property<string>("NomCommercial")
                        .HasColumnType("text");

                    b.Property<string>("Siret")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entreprises");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Entreprise");
                });

            modelBuilder.Entity("NahalTest.Models.Individuelle", b =>
                {
                    b.HasBaseType("NahalTest.Models.Entreprise");

                    b.Property<string>("Nom")
                        .HasColumnType("text");

                    b.Property<string>("Prenom")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Individuelle");
                });

            modelBuilder.Entity("NahalTest.Models.Societe", b =>
                {
                    b.HasBaseType("NahalTest.Models.Entreprise");

                    b.Property<int>("CapitalSocial")
                        .HasColumnType("integer");

                    b.Property<int>("FormeJuridique")
                        .HasColumnType("integer");

                    b.Property<int>("NombreParts")
                        .HasColumnType("integer");

                    b.Property<string>("RaisonSocial")
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("Societe");
                });
#pragma warning restore 612, 618
        }
    }
}