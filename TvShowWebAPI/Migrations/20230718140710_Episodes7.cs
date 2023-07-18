using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TvShowWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Episodes7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    air_date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    episode_number = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    overview = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    production_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    runtime = table.Column<int>(type: "int", nullable: true),
                    season_number = table.Column<int>(type: "int", nullable: true),
                    show_id = table.Column<int>(type: "int", nullable: true),
                    still_path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vote_average = table.Column<double>(type: "float", nullable: true),
                    vote_count = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.id);
                });

           





        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Episode");

            migrationBuilder.DropTable(
                name: "GuestStars");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Episodes");
        }
    }
}
