using Microsoft.EntityFrameworkCore.Migrations;

namespace Blog.Migrations
{
    public partial class PostImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Image",
                "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "Image",
                "Posts");
        }
    }
}