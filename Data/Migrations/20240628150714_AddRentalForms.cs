using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zaliczenia.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRentalForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    PickupDate = table.Column<DateTime>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: false),
                    Consent = table.Column<bool>(nullable: false),
                    CarId = table.Column<int>(nullable: false)
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalForms_CarId",
                table: "RentalForms",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalForms");
        }
    }
}
