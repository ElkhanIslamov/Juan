using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Juan.Migrations
{
    public partial class AddProductCreatedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DeletedTime",
                table: "Products",
                newName: "CreatedTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedTime",
                table: "Products",
                newName: "DeletedTime");
        }
    }
}
