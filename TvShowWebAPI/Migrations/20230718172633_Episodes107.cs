using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvShowWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Episodes107 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "GuestStars");

            migrationBuilder.AddColumn<string>(
                name: "username",
                table: "EpisodesWatched",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "username",
                table: "EpisodesWatched");

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<bool>(type: "bit", nullable: true),
                    credit_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: true),
                    job = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    known_for_department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    original_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    popularity = table.Column<double>(type: "float", nullable: true),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GuestStars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adult = table.Column<bool>(type: "bit", nullable: true),
                    character = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    credit_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<int>(type: "int", nullable: true),
                    known_for_department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    order = table.Column<int>(type: "int", nullable: true),
                    original_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    popularity = table.Column<double>(type: "float", nullable: true),
                    profile_path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestStars", x => x.id);
                });
        }
    }
}
