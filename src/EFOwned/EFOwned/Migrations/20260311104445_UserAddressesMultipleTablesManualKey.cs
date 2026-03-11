using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFOwned.Migrations
{
    /// <inheritdoc />
    public partial class UserAddressesMultipleTablesManualKey : Migration
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
                    name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "home_addresses",
                columns: table => new
                {
                    manual_key = table.Column<int>(type: "INTEGER", nullable: false),
                    home_street = table.Column<string>(type: "TEXT", nullable: false),
                    home_city = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_home_addresses", x => x.manual_key);
                    table.ForeignKey(
                        name: "FK_home_addresses_users_manual_key",
                        column: x => x.manual_key,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "work_addresses",
                columns: table => new
                {
                    manual_key = table.Column<int>(type: "INTEGER", nullable: false),
                    work_street = table.Column<string>(type: "TEXT", nullable: false),
                    work_city = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_addresses", x => x.manual_key);
                    table.ForeignKey(
                        name: "FK_work_addresses_users_manual_key",
                        column: x => x.manual_key,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "home_addresses");

            migrationBuilder.DropTable(
                name: "work_addresses");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
