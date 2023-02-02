using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class migrationsaddedrollen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "gebruikers",
                keyColumn: "UserID",
                keyValue: 9);

            migrationBuilder.AddColumn<string>(
                name: "rolId",
                table: "gebruikers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    roleid = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "shows",
                keyColumn: "Shownr",
                keyValue: 1,
                columns: new[] { "BeginTijd", "EindTijd" },
                values: new object[] { new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3802), new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "shows",
                keyColumn: "Shownr",
                keyValue: 2,
                columns: new[] { "BeginTijd", "EindTijd" },
                values: new object[] { new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3863), new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3866) });

            migrationBuilder.UpdateData(
                table: "shows",
                keyColumn: "Shownr",
                keyValue: 3,
                columns: new[] { "BeginTijd", "EindTijd" },
                values: new object[] { new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3870), new DateTime(2023, 1, 29, 13, 26, 34, 167, DateTimeKind.Local).AddTicks(3873) });

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 11,
                column: "Aantal_stoelen",
                value: 20);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 12,
                column: "Aantal_stoelen",
                value: 100);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 13,
                column: "Aantal_stoelen",
                value: 120);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 21,
                column: "Aantal_stoelen",
                value: 2);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 22,
                column: "Aantal_stoelen",
                value: 160);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 31,
                column: "Aantal_stoelen",
                value: 10);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 32,
                column: "Aantal_stoelen",
                value: 80);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 41,
                column: "Aantal_stoelen",
                value: 40);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 42,
                column: "Aantal_stoelen",
                value: 200);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 43,
                column: "Aantal_stoelen",
                value: 200);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 1,
                column: "Aantal_stoelen",
                value: 240);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 2,
                column: "Aantal_stoelen",
                value: 180);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 3,
                column: "Aantal_stoelen",
                value: 90);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 4,
                column: "Aantal_stoelen",
                value: 440);

            migrationBuilder.CreateIndex(
                name: "IX_gebruikers_rolId",
                table: "gebruikers",
                column: "rolId");

            migrationBuilder.AddForeignKey(
                name: "FK_gebruikers_Role_rolId",
                table: "gebruikers",
                column: "rolId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gebruikers_Role_rolId",
                table: "gebruikers");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropIndex(
                name: "IX_gebruikers_rolId",
                table: "gebruikers");

            migrationBuilder.DropColumn(
                name: "rolId",
                table: "gebruikers");

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
                    { 5, "Artiest", "artiestmail1@email.com", null, "Artiest1", "Artiest1", "Test1", null },
                    { 6, "Artiest", "artiestmail2@email.com", null, "Artiest2", "Artiest2", "Test2", null },
                    { 7, "Artiest", "artiestmail3@email.com", null, "Artiest3", "Artiest3", "Test3", null },
                    { 8, "Artiest", "artiestmail4@email.com", null, "Artiest4", "Artiest4", "Test4", null },
                    { 9, "Artiest", "artiestmail5@email.com", null, "Artiest5", "Artiest5", "Test5", null }
                });

            migrationBuilder.UpdateData(
                table: "shows",
                keyColumn: "Shownr",
                keyValue: 1,
                columns: new[] { "BeginTijd", "EindTijd" },
                values: new object[] { new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8545), new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8599) });

            migrationBuilder.UpdateData(
                table: "shows",
                keyColumn: "Shownr",
                keyValue: 2,
                columns: new[] { "BeginTijd", "EindTijd" },
                values: new object[] { new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8605), new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8607) });

            migrationBuilder.UpdateData(
                table: "shows",
                keyColumn: "Shownr",
                keyValue: 3,
                columns: new[] { "BeginTijd", "EindTijd" },
                values: new object[] { new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8612), new DateTime(2023, 1, 25, 20, 38, 8, 585, DateTimeKind.Local).AddTicks(8615) });

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 11,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 12,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 13,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 21,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 22,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 31,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 32,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 41,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 42,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "stoelrijen",
                keyColumn: "rijid",
                keyValue: 43,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 1,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 2,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 3,
                column: "Aantal_stoelen",
                value: 0);

            migrationBuilder.UpdateData(
                table: "zalen",
                keyColumn: "Zaalnr",
                keyValue: 4,
                column: "Aantal_stoelen",
                value: 0);
        }
    }
}
