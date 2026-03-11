using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFOwned.Migrations
{
    /// <inheritdoc />
    public partial class UserAddressesSingleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    home_street = table.Column<string>(type: "TEXT", nullable: false),
                    home_city = table.Column<string>(type: "TEXT", nullable: false),
                    work_street = table.Column<string>(type: "TEXT", nullable: false),
                    work_city = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
