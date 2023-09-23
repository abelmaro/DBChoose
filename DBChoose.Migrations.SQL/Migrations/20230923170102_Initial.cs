using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DBChoose.Migrations.SQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProvidersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ProvidersInfo",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "SQL" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidersInfo");
        }
    }
}
