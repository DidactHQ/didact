using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddBlockRunConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockRun",
                columns: table => new
                {
                    BlockRunId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowRunId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    BlockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    StateLastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateLastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlockRun", x => x.BlockRunId);
                    table.ForeignKey(
                        name: "FK_BlockRun_FlowRun_FlowRunId",
                        column: x => x.FlowRunId,
                        principalTable: "FlowRun",
                        principalColumn: "FlowRunId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockRun_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BlockRun_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlockRun_FlowRunId",
                table: "BlockRun",
                column: "FlowRunId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockRun_OrganizationId",
                table: "BlockRun",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_BlockRun_StateId",
                table: "BlockRun",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockRun");
        }
    }
}
