using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zaliczenia.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToRentalForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "RentalForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "RentalForms");
        }
    }
}
