﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace backend.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230129122634_migrations_added_rollen")]
    partial class migrationsaddedrollen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Band", b =>
                {
                    b.Property<int>("IdBand")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Afbeelding")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Omschrijving")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IdBand");

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

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("rolId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserID");

                    b.HasIndex("rolId");

                    b.ToTable("gebruikers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Gebruiker");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Huren", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Datum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RuimteNr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VerhuurdeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Zaalnr")
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("TEXT");

                    b.Property<int>("roleid")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Role");
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

                    b.HasData(
                        new
                        {
                            RuimteNr = 1,
                            Capaciteit = 30,
                            Naam = "Ruimte 1"
                        },
                        new
                        {
                            RuimteNr = 2,
                            Capaciteit = 30,
                            Naam = "Ruimte 2"
                        },
                        new
                        {
                            RuimteNr = 3,
                            Capaciteit = 30,
                            Naam = "Ruimte 3"
                        },
                        new
                        {
                            RuimteNr = 4,
                            Capaciteit = 30,
                            Naam = "Ruimte 4"
                        },
                        new
                        {
                            RuimteNr = 5,
                            Capaciteit = 30,
                            Naam = "Ruimte 5"
                        },
                        new
                        {
                            RuimteNr = 6,
                            Capaciteit = 30,
                            Naam = "Ruimte 6"
                        },
                        new
                        {
                            RuimteNr = 7,
                            Capaciteit = 30,
                            Naam = "Ruimte 7"
                        },
                        new
                        {
                            RuimteNr = 8,
                            Capaciteit = 30,
                            Naam = "Ruimte 8"
                        },
                        new
                        {
                            RuimteNr = 9,
                            Capaciteit = 30,
                            Naam = "Ruimte 9"
                        },
                        new
                        {
                            RuimteNr = 10,
                            Capaciteit = 30,
                            Naam = "Ruimte 10"
                        });
                });

            modelBuilder.Entity("Show", b =>
                {
                    b.Property<int>("Shownr")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Afbeelding")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BeginTijd")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EindTijd")
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .HasColumnType("TEXT");

                    b.Property<string>("Leeftijdsgroep")
                        .HasColumnType("TEXT");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("zaal")
                        .HasColumnType("TEXT");

                    b.HasKey("Shownr");

                    b.ToTable("shows");

                    b.HasData(
                        new
                        {
                            Shownr = 1,
                            Afbeelding = "",
                            BeginTijd = new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3802),
                            EindTijd = new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3857),
                            Genre = "Horor",
                            Leeftijdsgroep = "18",
                            Naam = "Show 1",
                            zaal = "zaal 1"
                        },
                        new
                        {
                            Shownr = 2,
                            Afbeelding = "",
                            BeginTijd = new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3863),
                            EindTijd = new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3866),
                            Genre = "Horor",
                            Leeftijdsgroep = "18",
                            Naam = "Show 2",
                            zaal = "zaal 2"
                        },
                        new
                        {
                            Shownr = 3,
                            Afbeelding = "",
                            BeginTijd = new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3870),
                            EindTijd = new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3873),
                            Genre = "Horor",
                            Leeftijdsgroep = "18",
                            Naam = "Show 3",
                            zaal = "zaal 3"
                        });
                });

            modelBuilder.Entity("Stoelrij", b =>
                {
                    b.Property<int>("rijid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Aantal_stoelen")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rangnummer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Zaalnr")
                        .HasColumnType("INTEGER");

                    b.HasKey("rijid");

                    b.ToTable("stoelrijen");

                    b.HasData(
                        new
                        {
                            rijid = 11,
                            Aantalstoelen = 20,
                            Rangnummer = 1,
                            Zaalnr = 1
                        },
                        new
                        {
                            rijid = 12,
                            Aantalstoelen = 100,
                            Rangnummer = 2,
                            Zaalnr = 1
                        },
                        new
                        {
                            rijid = 13,
                            Aantalstoelen = 120,
                            Rangnummer = 3,
                            Zaalnr = 1
                        },
                        new
                        {
                            rijid = 21,
                            Aantalstoelen = 2,
                            Rangnummer = 1,
                            Zaalnr = 2
                        },
                        new
                        {
                            rijid = 22,
                            Aantalstoelen = 160,
                            Rangnummer = 2,
                            Zaalnr = 2
                        },
                        new
                        {
                            rijid = 31,
                            Aantalstoelen = 10,
                            Rangnummer = 1,
                            Zaalnr = 3
                        },
                        new
                        {
                            rijid = 32,
                            Aantalstoelen = 80,
                            Rangnummer = 2,
                            Zaalnr = 3
                        },
                        new
                        {
                            rijid = 41,
                            Aantalstoelen = 40,
                            Rangnummer = 1,
                            Zaalnr = 4
                        },
                        new
                        {
                            rijid = 42,
                            Aantalstoelen = 200,
                            Rangnummer = 2,
                            Zaalnr = 4
                        },
                        new
                        {
                            rijid = 43,
                            Aantalstoelen = 200,
                            Rangnummer = 3,
                            Zaalnr = 4
                        });
                });

            modelBuilder.Entity("Ticket", b =>
                {
                    b.Property<int>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Shownr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("stoelNr")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TicketID");

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

                    b.HasData(
                        new
                        {
                            Zaalnr = 1,
                            Aantalstoelen = 240,
                            Naam = "Zaal 1"
                        },
                        new
                        {
                            Zaalnr = 2,
                            Aantalstoelen = 180,
                            Naam = "Zaal 2"
                        },
                        new
                        {
                            Zaalnr = 3,
                            Aantalstoelen = 90,
                            Naam = "Zaal 3"
                        },
                        new
                        {
                            Zaalnr = 4,
                            Aantalstoelen = 440,
                            Naam = "Zaal 4"
                        });
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

            modelBuilder.Entity("Gebruiker", b =>
                {
                    b.HasOne("Role", "rol")
                        .WithMany()
                        .HasForeignKey("rolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("rol");
                });

            modelBuilder.Entity("Artiest", b =>
                {
                    b.HasOne("Leden", null)
                        .WithMany("artiesten")
                        .HasForeignKey("LedenId");
                });

            modelBuilder.Entity("Leden", b =>
                {
                    b.Navigation("artiesten");
                });
#pragma warning restore 612, 618
        }
    }
}
