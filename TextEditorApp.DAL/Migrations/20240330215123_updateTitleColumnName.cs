using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextEditorApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateTitleColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tile",
                table: "Documents",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Documents",
                newName: "Tile");
        }
    }
}
