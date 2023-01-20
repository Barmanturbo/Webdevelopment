﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230120121826_Migrations_2")]
    partial class Migrations_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.11");

            modelBuilder.Entity("Band", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Afbeelding")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("bands");
                });

            modelBuilder.Entity("Gebruiker", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.ToTable("gebruikers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Gebruiker");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "test1@email.com",
                            Naam = "Jan1",
                            Wachtwoord = "Test1"
                        },
                        new
                        {
                            UserID = 2,
                            Email = "test2@email.com",
                            Naam = "Jan2",
                            Wachtwoord = "Test2"
                        },
                        new
                        {
                            UserID = 3,
                            Email = "test3@email.com",
                            Naam = "Jan3",
                            Wachtwoord = "Test3"
                        },
                        new
                        {
                            UserID = 4,
                            Email = "test4@email.com",
                            Naam = "Jan4",
                            Wachtwoord = "Test4"
                        });
                });

            modelBuilder.Entity("Huren", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("TEXT");

                    b.Property<string>("VerhuurdeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("reserveringen");
                });

            modelBuilder.Entity("Leden", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("BandId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("leden");
                });

            modelBuilder.Entity("Ruimte", b =>
                {
                    b.Property<int>("RuimteNr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Capaciteit")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("RuimteNr");

                    b.ToTable("ruimtes");
                });

            modelBuilder.Entity("Show", b =>
                {
                    b.Property<int>("Shownr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Afbeelding")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("BeginTijd")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EindTijd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Leeftijdsgroep")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Shownr");

                    b.ToTable("shows");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GebruikerUserID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("stoelNr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TicketID");

                    b.HasIndex("GebruikerUserID");

                    b.ToTable("tickets");
                });

            modelBuilder.Entity("Zaal", b =>
                {
                    b.Property<int>("Zaalnr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Aantal_stoelen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Zaalnr");

                    b.ToTable("zalen");
                });

            modelBuilder.Entity("Artiest", b =>
                {
                    b.HasBaseType("Gebruiker");

                    b.Property<string>("LedenId")
                        .HasColumnType("TEXT");

                    b.Property<string>("artiest_naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasIndex("LedenId");

                    b.HasDiscriminator().HasValue("Artiest");
                });

            modelBuilder.Entity("Donateur", b =>
                {
                    b.HasBaseType("Gebruiker");

                    b.Property<int>("TotaleDonatie")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Donateur");
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.HasOne("Gebruiker", null)
                        .WithMany("tickets")
                        .HasForeignKey("GebruikerUserID");
                });

            modelBuilder.Entity("Artiest", b =>
                {
                    b.HasOne("Leden", null)
                        .WithMany("artiesten")
                        .HasForeignKey("LedenId");
                });

            modelBuilder.Entity("Gebruiker", b =>
                {
                    b.Navigation("tickets");
                });

            modelBuilder.Entity("Leden", b =>
                {
                    b.Navigation("artiesten");
                });
#pragma warning restore 612, 618
        }
    }
}