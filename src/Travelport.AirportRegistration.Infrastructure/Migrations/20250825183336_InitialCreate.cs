using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Travelport.AirportRegistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Surname = table.Column<string>(type: "TEXT", nullable: false),
                    PassportNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: true),
                    AirportId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Airports_AirportId",
                        column: x => x.AirportId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "MAD", "Adolfo Suárez Madrid–Barajas Airport" },
                    { 2, "BCN", "Barcelona–El Prat Airport" },
                    { 3, "AGP", "Málaga Airport" },
                    { 4, "PMI", "Palma de Mallorca Airport" },
                    { 5, "ALC", "Alicante–Elche Airport" },
                    { 6, "LPA", "Gran Canaria Airport" },
                    { 7, "TFS", "Tenerife South Airport" },
                    { 8, "VLC", "Valencia Airport" },
                    { 9, "SVQ", "Seville Airport" },
                    { 10, "BIO", "Bilbao Airport" },
                    { 11, "IBZ", "Ibiza Airport" },
                    { 12, "MAH", "Menorca Airport" },
                    { 13, "SCQ", "Santiago de Compostela Airport" },
                    { 14, "OVD", "Asturias Airport" },
                    { 15, "GRO", "Girona–Costa Brava Airport" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_AirportId",
                table: "People",
                column: "AirportId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
