using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerRegistration",
                table: "CustomerRegistration");

            migrationBuilder.RenameTable(
                name: "CustomerRegistration",
                newName: "CustReg");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustReg",
                table: "CustReg",
                column: "id");

            migrationBuilder.CreateTable(
                name: "CreditDesc",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customerId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditDesc", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditDesc");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustReg",
                table: "CustReg");

            migrationBuilder.RenameTable(
                name: "CustReg",
                newName: "CustomerRegistration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerRegistration",
                table: "CustomerRegistration",
                column: "id");
        }
    }
}
