using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class initializing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "titre",
                table: "TaskList",
                newName: "Titre");

            migrationBuilder.RenameColumn(
                name: "statut",
                table: "TaskList",
                newName: "Statut");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "TaskList",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "identifiant",
                table: "TaskList",
                newName: "Identifiant");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "TaskList",
                newName: "titre");

            migrationBuilder.RenameColumn(
                name: "Statut",
                table: "TaskList",
                newName: "statut");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TaskList",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Identifiant",
                table: "TaskList",
                newName: "identifiant");
        }
    }
}
