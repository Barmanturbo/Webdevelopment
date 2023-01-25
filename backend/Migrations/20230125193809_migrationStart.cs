using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class migrationStart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bands",
                columns: table => new
                {
                    IdBand = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Omschrijving = table.Column<string>(type: "TEXT", nullable: false),
                    Afbeelding = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bands", x => x.IdBand);
                });

            migrationBuilder.CreateTable(
                name: "leden",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    BandId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reserveringen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Naam = table.Column<string>(type: "TEXT", nullable: true),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: true),
                    VerhuurdeId = table.Column<string>(type: "TEXT", nullable: false),
                    Zaalnr = table.Column<int>(type: "INTEGER", nullable: true),
                    RuimteNr = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reserveringen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ruimtes",
                columns: table => new
                {
                    RuimteNr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Capaciteit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ruimtes", x => x.RuimteNr);
                });

            migrationBuilder.CreateTable(
                name: "shows",
                columns: table => new
                {
                    Shownr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Afbeelding = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Leeftijdsgroep = table.Column<string>(type: "TEXT", nullable: true),
                    zaal = table.Column<string>(type: "TEXT", nullable: true),
                    BeginTijd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EindTijd = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shows", x => x.Shownr);
                });

            migrationBuilder.CreateTable(
                name: "stoelrijen",
                columns: table => new
                {
                    rijid = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rangnummer = table.Column<int>(type: "INTEGER", nullable: false),
                    Aantalstoelen = table.Column<int>(name: "Aantal_stoelen", type: "INTEGER", nullable: false),
                    Zaalnr = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stoelrijen", x => x.rijid);
                });

            migrationBuilder.CreateTable(
                name: "tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    stoelNr = table.Column<string>(type: "TEXT", nullable: false),
                    Shownr = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tickets", x => x.TicketID);
                });

            migrationBuilder.CreateTable(
                name: "zalen",
                columns: table => new
                {
                    Zaalnr = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", nullable: false),
                    Aantalstoelen = table.Column<int>(name: "Aantal_stoelen", type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zalen", x => x.Zaalnr);
                });

            migrationBuilder.CreateTable(
                name: "gebruikers",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Wachtwoord = table.Column<string>(type: "TEXT", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    artiestnaam = table.Column<string>(name: "artiest_naam", type: "TEXT", nullable: true),
                    LedenId = table.Column<string>(type: "TEXT", nullable: true),
                    TotaleDonatie = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gebruikers", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_gebruikers_leden_LedenId",
                        column: x => x.LedenId,
                        principalTable: "leden",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "gebruikers",
                columns: new[] { "UserID", "Discriminator", "Email", "Naam", "TotaleDonatie", "Username", "Wachtwoord" },
                values: new object[] { 1, "Donateur", "test1@email.com", "Jan1", 1000, "Jan1", "Test1" });

            migrationBuilder.InsertData(
                table: "gebruikers",
                columns: new[] { "UserID", "Discriminator", "Email", "Naam", "Username", "Wachtwoord" },
                values: new object[,]
                {
                    { 2, "Gebruiker", "test2@email.com", "Jan2", "Jan2", "Test2" },
                    { 3, "Gebruiker", "test3@email.com", "Jan3", "Jan3", "Test3" },
                    { 4, "Gebruiker", "test4@email.com", "Jan4", "Jan4", "Test4" }
                });

            migrationBuilder.InsertData(
                table: "gebruikers",
                columns: new[] { "UserID", "Discriminator", "Email", "LedenId", "Naam", "Username", "Wachtwoord", "artiest_naam" },
                values: new object[,]
                {
                    { 5, "Artiest", "artiestmail1@email.com", null, "Artiest1", "Artiest1", "Test1", "Artiest1" },
                    { 6, "Artiest", "artiestmail2@email.com", null, "Artiest2", "Artiest2", "Test2", "Artiest2" },
                    { 7, "Artiest", "artiestmail3@email.com", null, "Artiest3", "Artiest3", "Test3", "Artiest3" },
                    { 8, "Artiest", "artiestmail4@email.com", null, "Artiest4", "Artiest4", "Test4", "Artiest4" },
                    { 9, "Artiest", "artiestmail5@email.com", null, "Artiest5", "Artiest5", "Test5", "Artiest5" }
                });

            migrationBuilder.InsertData(
                table: "ruimtes",
                columns: new[] { "RuimteNr", "Capaciteit", "Naam" },
                values: new object[,]
                {
                    { 1, 30, "Ruimte 1" },
                    { 2, 30, "Ruimte 2" },
                    { 3, 30, "Ruimte 3" },
                    { 4, 30, "Ruimte 4" },
                    { 5, 30, "Ruimte 5" },
                    { 6, 30, "Ruimte 6" },
                    { 7, 30, "Ruimte 7" },
                    { 8, 30, "Ruimte 8" },
                    { 9, 30, "Ruimte 9" },
                    { 10, 30, "Ruimte 10" }
                });

            migrationBuilder.InsertData(
                table: "shows",
                columns: new[] { "Shownr", "Afbeelding", "BeginTijd", "EindTijd", "Genre", "Leeftijdsgroep", "Naam", "zaal" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8545), new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8599), "Horor", "18", "Show 1", "zaal 1" },
                    { 2, "", new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8605), new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8607), "Horor", "18", "Show 2", "zaal 2" },
                    { 3, "", new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8612), new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8615), "Horor", "18", "Show 3", "zaal 3" }
                });

            migrationBuilder.InsertData(
                table: "stoelrijen",
                columns: new[] { "rijid", "Aantal_stoelen", "Rangnummer", "Zaalnr" },
                values: new object[,]
                {
                    { 11, 20, 1, 1 },
                    { 12, 100, 2, 1 },
                    { 13, 120, 3, 1 },
                    { 21, 2, 1, 2 },
                    { 22, 160, 2, 2 },
                    { 31, 10, 1, 3 },
                    { 32, 80, 2, 3 },
                    { 41, 40, 1, 4 },
                    { 42, 200, 2, 4 },
                    { 43, 200, 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "zalen",
                columns: new[] { "Zaalnr", "Aantal_stoelen", "Naam" },
                values: new object[,]
                {
                    { 1, 240, "Zaal 1" },
                    { 2, 180, "Zaal 2" },
                    { 3, 90, "Zaal 3" },
                    { 4, 440, "Zaal 4" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_gebruikers_LedenId",
                table: "gebruikers",
                column: "LedenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bands");

            migrationBuilder.DropTable(
                name: "gebruikers");

            migrationBuilder.DropTable(
                name: "reserveringen");

            migrationBuilder.DropTable(
                name: "ruimtes");

            migrationBuilder.DropTable(
                name: "shows");

            migrationBuilder.DropTable(
                name: "stoelrijen");

            migrationBuilder.DropTable(
                name: "tickets");

            migrationBuilder.DropTable(
                name: "zalen");

            migrationBuilder.DropTable(
                name: "leden");
        }
    }
}
