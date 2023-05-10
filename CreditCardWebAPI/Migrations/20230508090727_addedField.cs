using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreditCardWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "paidStatus",
                table: "CreditDesc",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "paidStatus",
                table: "CreditDesc");
        }
    }
}
