using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBaseEntity0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Wallets",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Transactions",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Roles",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Orders",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "OrderDetails",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "OrchidsMutations",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "OrchidsCategories",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Orchids",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Mutations",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "DealHangers",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "AuctionStates",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "AuctionEvents",
                newName: "DeleteTime");

            migrationBuilder.RenameColumn(
                name: "DeleteDate",
                table: "Accounts",
                newName: "DeleteTime");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "Wallets",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "Transactions",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "Roles",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "Orders",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "OrderDetails",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "OrchidsMutations",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "OrchidsCategories",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "Orchids",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "Mutations",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "DealHangers",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "AuctionStates",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "AuctionEvents",
                newName: "DeleteDate");

            migrationBuilder.RenameColumn(
                name: "DeleteTime",
                table: "Accounts",
                newName: "DeleteDate");
        }
    }
}
