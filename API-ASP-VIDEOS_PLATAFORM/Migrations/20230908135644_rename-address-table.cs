using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_ASP_VIDEOS_PLATAFORM.Migrations
{
    /// <inheritdoc />
    public partial class renameaddresstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
             name: "addresses",
             newName: "address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
