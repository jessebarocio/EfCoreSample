using Microsoft.EntityFrameworkCore.Migrations;

namespace EfCoreSample.Migrations
{
    public partial class OrderStatusLookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Create a lookup table for the OrderStatus enum
            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                }
            );
            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new string[] { "Id", "Name", "Description" },
                values: new object[,] {
                    { 1, "New", "The order has been placed and is awaiting processing" },
                    { 2, "Processing", "The order is processing" },
                    { 3, "Shipped", "The order has been shipped" },
                    { 4, "Complete", "The order has been received by the customer" },
                }
            );

            // Create a foreign key for the Order Status field
            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStatuses_Status",
                table: "Orders",
                column: "Status", 
                principalTable: "OrderStatuses", 
                principalColumn: "Id"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("FK_Orders_OrderStatuses_Status", "Orders");
            migrationBuilder.DropTable("OrderStatuses");
        }
    }
}
