using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowRunsConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FlowRunId",
                table: "HyperQueueInbound",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FlowRunId",
                table: "FifoQueueInbound",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FlowRun",
                columns: table => new
                {
                    FlowRunId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    ParentFlowRunId = table.Column<long>(type: "bigint", nullable: true),
                    TriggerTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JsonPayload = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecuteAfter = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeoutSeconds = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ExecutionStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionEnded = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowRun", x => x.FlowRunId);
                    table.ForeignKey(
                        name: "FK_FlowRun_Flow",
                        column: x => x.FlowId,
                        principalTable: "Flow",
                        principalColumn: "FlowId");
                    table.ForeignKey(
                        name: "FK_FlowRun_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId");
                    table.ForeignKey(
                        name: "FK_FlowRun_State",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "StateId");
                    table.ForeignKey(
                        name: "FK_FlowRun_TriggerType",
                        column: x => x.TriggerTypeId,
                        principalTable: "TriggerType",
                        principalColumn: "TriggerTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HyperQueueInbound_FlowRunId",
                table: "HyperQueueInbound",
                column: "FlowRunId");

            migrationBuilder.CreateIndex(
                name: "IX_FifoQueueInbound_FlowRunId",
                table: "FifoQueueInbound",
                column: "FlowRunId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowRun_FlowId",
                table: "FlowRun",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowRun_OrganizationId",
                table: "FlowRun",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowRun_StateId",
                table: "FlowRun",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowRun_TriggerTypeId",
                table: "FlowRun",
                column: "TriggerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FifoQueueInbound_FlowRun_FlowRunId",
                table: "FifoQueueInbound",
                column: "FlowRunId",
                principalTable: "FlowRun",
                principalColumn: "FlowRunId");

            migrationBuilder.AddForeignKey(
                name: "FK_HyperQueueInbound_FlowRun_FlowRunId",
                table: "HyperQueueInbound",
                column: "FlowRunId",
                principalTable: "FlowRun",
                principalColumn: "FlowRunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FifoQueueInbound_FlowRun_FlowRunId",
                table: "FifoQueueInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_HyperQueueInbound_FlowRun_FlowRunId",
                table: "HyperQueueInbound");

            migrationBuilder.DropTable(
                name: "FlowRun");

            migrationBuilder.DropIndex(
                name: "IX_HyperQueueInbound_FlowRunId",
                table: "HyperQueueInbound");

            migrationBuilder.DropIndex(
                name: "IX_FifoQueueInbound_FlowRunId",
                table: "FifoQueueInbound");

            migrationBuilder.DropColumn(
                name: "FlowRunId",
                table: "HyperQueueInbound");

            migrationBuilder.DropColumn(
                name: "FlowRunId",
                table: "FifoQueueInbound");
        }
    }
}
