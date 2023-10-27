using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Books2023.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class moomdifyNameStreetAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreeAddress",
                table: "AspNetUsers",
                newName: "StreetAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "AspNetUsers",
                newName: "StreeAddress");
        }
    }
}
