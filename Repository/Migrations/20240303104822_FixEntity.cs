using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FixEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionEvents_Accounts_AccountId",
                table: "AuctionEvents");

            migrationBuilder.DropIndex(
                name: "IX_AuctionEvents_AccountId",
                table: "AuctionEvents");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "AuctionEvents");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "AuctionEvents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuctionEvents_StaffId",
                table: "AuctionEvents",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionEvents_Accounts_StaffId",
                table: "AuctionEvents",
                column: "StaffId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionEvents_Accounts_StaffId",
                table: "AuctionEvents");

            migrationBuilder.DropIndex(
                name: "IX_AuctionEvents_StaffId",
                table: "AuctionEvents");

            migrationBuilder.AlterColumn<string>(
                name: "StaffId",
                table: "AuctionEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "AuctionEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionEvents_AccountId",
                table: "AuctionEvents",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionEvents_Accounts_AccountId",
                table: "AuctionEvents",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
