using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DidactEngine.Migrations
{
    /// <inheritdoc />
    public partial class AddFlowRunsToQueueInbounds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FifoQueueInbound_FlowRun_FlowRunId",
                table: "FifoQueueInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_HyperQueueInbound_FlowRun_FlowRunId",
                table: "HyperQueueInbound");

            migrationBuilder.AlterColumn<long>(
                name: "FlowRunId",
                table: "HyperQueueInbound",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "FlowRunId",
                table: "FifoQueueInbound",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FifoQueueInbound_FlowRun",
                table: "FifoQueueInbound",
                column: "FlowRunId",
                principalTable: "FlowRun",
                principalColumn: "FlowRunId");

            migrationBuilder.AddForeignKey(
                name: "FK_HyperQueueInbound_FlowRun",
                table: "HyperQueueInbound",
                column: "FlowRunId",
                principalTable: "FlowRun",
                principalColumn: "FlowRunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FifoQueueInbound_FlowRun",
                table: "FifoQueueInbound");

            migrationBuilder.DropForeignKey(
                name: "FK_HyperQueueInbound_FlowRun",
                table: "HyperQueueInbound");

            migrationBuilder.AlterColumn<long>(
                name: "FlowRunId",
                table: "HyperQueueInbound",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "FlowRunId",
                table: "FifoQueueInbound",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}
