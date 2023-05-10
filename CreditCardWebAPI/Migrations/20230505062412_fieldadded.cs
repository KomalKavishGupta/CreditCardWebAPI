using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class fieldadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "custUniqueId",
                table: "CustReg",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "customerHash",
                table: "CreditDesc",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "custUniqueId",
                table: "CustReg");

            migrationBuilder.DropColumn(
                name: "customerHash",
                table: "CreditDesc");
        }
    }
}
