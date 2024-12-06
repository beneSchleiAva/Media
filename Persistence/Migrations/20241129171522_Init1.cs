using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderEntityId",
                table: "OrderPositions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderPositions_OrderEntityId",
                table: "OrderPositions",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPositions_Orders_OrderEntityId",
                table: "OrderPositions",
                column: "OrderEntityId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPositions_Orders_OrderEntityId",
                table: "OrderPositions");

            migrationBuilder.DropIndex(
                name: "IX_OrderPositions_OrderEntityId",
                table: "OrderPositions");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "OrderPositions");
        }
    }
}
