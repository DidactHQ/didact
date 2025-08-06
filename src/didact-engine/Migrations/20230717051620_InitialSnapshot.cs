using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class InitialSnapshot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleType",
                columns: table => new
                {
                    ScheduleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_ScheduleType", x => x.ScheduleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_State", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "TriggerType",
                columns: table => new
                {
                    TriggerTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    table.PrimaryKey("PK_TriggerType", x => x.TriggerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FifoQueue",
                columns: table => new
                {
                    FifoQueueId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_FifoQueue", x => x.FifoQueueId);
                    table.ForeignKey(
                        name: "FK_FifoQueue_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Flow",
                columns: table => new
                {
                    FlowId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AssemblyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullyQualifiedTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyLimit = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flow", x => x.FlowId);
                    table.ForeignKey(
                        name: "FK_Flow_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId");
                });

            migrationBuilder.CreateTable(
                name: "StandardQueue",
                columns: table => new
                {
                    StandardQueueId = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_StandardQueue", x => x.StandardQueueId);
                    table.ForeignKey(
                        name: "FK_StandardQueue_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FifoQueueInbound",
                columns: table => new
                {
                    FifoQueueInboundId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    FifoQueueId = table.Column<int>(type: "int", nullable: false),
                    FlowId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FifoQueueInbound", x => x.FifoQueueInboundId);
                    table.ForeignKey(
                        name: "FK_FifoQueueInbound_FifoQueue",
                        column: x => x.FifoQueueId,
                        principalTable: "FifoQueue",
                        principalColumn: "FifoQueueId");
                    table.ForeignKey(
                        name: "FK_FifoQueueInbound_Flow",
                        column: x => x.FlowId,
                        principalTable: "Flow",
                        principalColumn: "FlowId");
                    table.ForeignKey(
                        name: "FK_FifoQueueInbound_Organization",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId");
                });

            migrationBuilder.CreateTable(
                name: "FlowSchedule",
                columns: table => new
                {
                    FlowScheduleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    FlowId = table.Column<long>(type: "bigint", nullable: false),
                    ScheduleTypeId = table.Column<int>(type: "int", nullable: false),
                    CronExpression = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastRunTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NextRunTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowSchedule", x => x.FlowScheduleId);
                    table.ForeignKey(
                        name: "FK_FlowSchedule_Flow_FlowId",
                        column: x => x.FlowId,
                        principalTable: "Flow",
                        principalColumn: "FlowId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowSchedule_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowSchedule_ScheduleType_ScheduleTypeId",
                        column: x => x.ScheduleTypeId,
                        principalTable: "ScheduleType",
                        principalColumn: "ScheduleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardQueueInbound",
                columns: table => new
                {
                    StandardQueueInboundId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    StandardQueueId = table.Column<int>(type: "int", nullable: false),
                    FlowId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "IX_FifoQueue_OrganizationId",
                table: "FifoQueue",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FifoQueueInbound_FifoQueueId",
                table: "FifoQueueInbound",
                column: "FifoQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_FifoQueueInbound_FlowId",
                table: "FifoQueueInbound",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_FifoQueueInbound_OrganizationId",
                table: "FifoQueueInbound",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flow_OrganizationId",
                table: "Flow",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSchedule_FlowId",
                table: "FlowSchedule",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSchedule_OrganizationId",
                table: "FlowSchedule",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSchedule_ScheduleTypeId",
                table: "FlowSchedule",
                column: "ScheduleTypeId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FifoQueueInbound");

            migrationBuilder.DropTable(
                name: "FlowSchedule");

            migrationBuilder.DropTable(
                name: "StandardQueueInbound");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "TriggerType");

            migrationBuilder.DropTable(
                name: "FifoQueue");

            migrationBuilder.DropTable(
                name: "ScheduleType");

            migrationBuilder.DropTable(
                name: "Flow");

            migrationBuilder.DropTable(
                name: "StandardQueue");

            migrationBuilder.DropTable(
                name: "Organization");
        }
    }
}
