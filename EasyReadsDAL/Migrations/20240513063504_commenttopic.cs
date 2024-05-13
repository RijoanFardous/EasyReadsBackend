using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyReadsDAL.Migrations
{
    /// <inheritdoc />
    public partial class commenttopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopicId",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_TopicId",
                table: "Articles",
                column: "TopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Topics_TopicId",
                table: "Articles",
                column: "TopicId",
                principalTable: "Topics",
                principalColumn: "TopicId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Topics_TopicId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_TopicId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TopicId",
                table: "Articles");
        }
    }
}
