using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CvMatcher.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSomeAdditionalColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmbeddingVector",
                table: "Cvs",
                type: "TEXT",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<double>(
                name: "MatchScore",
                table: "Cvs",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmbeddingVector",
                table: "Cvs");

            migrationBuilder.DropColumn(
                name: "MatchScore",
                table: "Cvs");
        }
    }
}
