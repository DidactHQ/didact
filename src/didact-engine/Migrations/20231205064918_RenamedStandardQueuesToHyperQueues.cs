using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class RenamedStandardQueuesToHyperQueues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardQueueInbound");

            migrationBuilder.DropTable(
                name: "StandardQueue");

            migrationBuilder.CreateTable(
                name: "HyperQueue",
                columns: table => new
                {
                    HyperQueueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperQueue", x => x.HyperQueueId);
                    table.ForeignKey(
                        name: "FK_HyperQueue_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HyperQueueInbound",
                columns: table => new
                {
                    HyperQueueInboundId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    HyperQueueId = table.Column<int>(type: "int", nullable: false),
                    FlowId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperQueueInbound", x => x.HyperQueueInboundId);
                    table.ForeignKey(
                        name: "FK_HyperQueueInbound_$HyperQueue",
                        column: x => x.HyperQueueId,
                        principalTable: "HyperQueue",
                        principalColumn: "HyperQueueId");
                    table.ForeignKey(
                        name: "FK_HyperQueueInbound_Flow",
                        column: x => x.FlowId,
                        principalTable: "Flow",
                        principalColumn: "FlowId");
                    table.ForeignKey(
                        name: "FK_HyperQueueInbound_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HyperQueue_OrganizationId",
                table: "HyperQueue",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperQueueInbound_FlowId",
                table: "HyperQueueInbound",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperQueueInbound_HyperQueueId",
                table: "HyperQueueInbound",
                column: "HyperQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperQueueInbound_OrganizationId",
                table: "HyperQueueInbound",
                column: "OrganizationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HyperQueueInbound");

            migrationBuilder.DropTable(
                name: "HyperQueue");

            migrationBuilder.CreateTable(
                name: "StandardQueue",
                columns: table => new
                {
                    StandardQueueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardQueue", x => x.StandardQueueId);
                    table.ForeignKey(
                        name: "FK_StandardQueue_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardQueueInbound",
                columns: table => new
                {
                    StandardQueueInboundId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlowId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    StandardQueueId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardQueueInbound", x => x.StandardQueueInboundId);
                    table.ForeignKey(
                        name: "FK_StandardQueueInbound_Flow",
                        column: x => x.FlowId,
                        principalTable: "Flow",
                        principalColumn: "FlowId");
                    table.ForeignKey(
                        name: "FK_StandardQueueInbound_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId");
                    table.ForeignKey(
                        name: "FK_StandardQueueInbound_StandardQueue",
                        column: x => x.StandardQueueId,
                        principalTable: "StandardQueue",
                        principalColumn: "StandardQueueId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardQueue_OrganizationId",
                table: "StandardQueue",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardQueueInbound_FlowId",
                table: "StandardQueueInbound",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardQueueInbound_OrganizationId",
                table: "StandardQueueInbound",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardQueueInbound_StandardQueueId",
                table: "StandardQueueInbound",
                column: "StandardQueueId");
        }
    }
}
