using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddTypeRefToFlow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssemblyName",
                table: "Flow");

            migrationBuilder.RenameColumn(
                name: "FullyQualifiedTypeName",
                table: "Flow",
                newName: "FullyQualifiedType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullyQualifiedType",
                table: "Flow",
                newName: "FullyQualifiedTypeName");

            migrationBuilder.AddColumn<string>(
                name: "AssemblyName",
                table: "Flow",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
