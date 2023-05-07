using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockCentral.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class PerfumeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VolumeInML",
                table: "Stock",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VolumeInML",
                table: "Stock");
        }
    }
}
