using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class noorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreModelId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserModelId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Orders_OrderModelId",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "OrderModel");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserModelId",
                table: "OrderModel",
                newName: "IX_OrderModel_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_StoreModelId",
                table: "OrderModel",
                newName: "IX_OrderModel_StoreModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Stores_StoreModelId",
                table: "OrderModel",
                column: "StoreModelId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderModel_Users_UserModelId",
                table: "OrderModel",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_OrderModel_OrderModelId",
                table: "Pizzas",
                column: "OrderModelId",
                principalTable: "OrderModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Stores_StoreModelId",
                table: "OrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderModel_Users_UserModelId",
                table: "OrderModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_OrderModel_OrderModelId",
                table: "Pizzas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModel",
                table: "OrderModel");

            migrationBuilder.RenameTable(
                name: "OrderModel",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_UserModelId",
                table: "Orders",
                newName: "IX_Orders_UserModelId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderModel_StoreModelId",
                table: "Orders",
                newName: "IX_Orders_StoreModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreModelId",
                table: "Orders",
                column: "StoreModelId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserModelId",
                table: "Orders",
                column: "UserModelId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Orders_OrderModelId",
                table: "Pizzas",
                column: "OrderModelId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
