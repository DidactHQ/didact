using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFlowRefsFromQueueInboundConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FifoQueueInbound_Flow",
                table: "FifoQueueInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_HyperQueueInbound_Flow",
                table: "HyperQueueInbound");

            migrationBuilder.DropIndex(
                name: "IX_HyperQueueInbound_FlowId",
                table: "HyperQueueInbound");

            migrationBuilder.DropIndex(
                name: "IX_FifoQueueInbound_FlowId",
                table: "FifoQueueInbound");

            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "HyperQueueInbound");

            migrationBuilder.DropColumn(
                name: "FlowId",
                table: "FifoQueueInbound");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FlowId",
                table: "HyperQueueInbound",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "FlowId",
                table: "FifoQueueInbound",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_HyperQueueInbound_FlowId",
                table: "HyperQueueInbound",
                column: "FlowId");

            migrationBuilder.CreateIndex(
                name: "IX_FifoQueueInbound_FlowId",
                table: "FifoQueueInbound",
                column: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_FifoQueueInbound_Flow",
                table: "FifoQueueInbound",
                column: "FlowId",
                principalTable: "Flow",
                principalColumn: "FlowId");

            migrationBuilder.AddForeignKey(
                name: "FK_HyperQueueInbound_Flow",
                table: "HyperQueueInbound",
                column: "FlowId",
                principalTable: "Flow",
                principalColumn: "FlowId");
        }
    }
}
