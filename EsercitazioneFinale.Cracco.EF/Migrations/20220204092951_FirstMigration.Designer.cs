﻿// <auto-generated />
using System;
using EsercitazioneFinale.Cracco.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EsercitazioneFinale.Cracco.EF.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20220204092951_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EsercitazioneFinale.Cracco.Core.Entities.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Menu", (string)null);
                });

            modelBuilder.Entity("EsercitazioneFinale.Cracco.Core.Entities.Piatto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descrizione")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MenuId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("Piatto", (string)null);
                });

            modelBuilder.Entity("EsercitazioneFinale.Cracco.Core.Entities.Piatto", b =>
                {
                    b.HasOne("EsercitazioneFinale.Cracco.Core.Entities.Menu", "Menu")
                        .WithMany("Piatti")
                        .HasForeignKey("MenuId");

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("EsercitazioneFinale.Cracco.Core.Entities.Menu", b =>
                {
                    b.Navigation("Piatti");
                });
#pragma warning restore 612, 618
        }
    }
}