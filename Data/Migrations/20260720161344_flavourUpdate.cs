using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCrud.Data.Migrations
{
    /// <inheritdoc />
    public partial class flavourUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Flavour_FlavourId",
                table: "Drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flavour",
                table: "Flavour");

            migrationBuilder.RenameTable(
                name: "Flavour",
                newName: "Flavours");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flavours",
                table: "Flavours",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Flavours_FlavourId",
                table: "Drinks",
                column: "FlavourId",
                principalTable: "Flavours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Flavours_FlavourId",
                table: "Drinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flavours",
                table: "Flavours");

            migrationBuilder.RenameTable(
                name: "Flavours",
                newName: "Flavour");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flavour",
                table: "Flavour",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Flavour_FlavourId",
                table: "Drinks",
                column: "FlavourId",
                principalTable: "Flavour",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
