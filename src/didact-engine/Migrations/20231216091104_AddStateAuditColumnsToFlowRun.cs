using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddStateAuditColumnsToFlowRun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StateLastUpdated",
                table: "FlowRun",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StateLastUpdatedBy",
                table: "FlowRun",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateLastUpdated",
                table: "FlowRun");

            migrationBuilder.DropColumn(
                name: "StateLastUpdatedBy",
                table: "FlowRun");
        }
    }
}
