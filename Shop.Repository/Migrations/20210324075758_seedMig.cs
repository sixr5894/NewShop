using Microsoft.EntityFrameworkCore.Migrations;

namespace Shop.Repository.Migrations
{
    public partial class seedMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AuthModelsList",
                columns: new[] { "Login", "Password" },
                values: new object[] { "user", "user" });

            migrationBuilder.InsertData(
                table: "ProductModelsList",
                columns: new[] { "ID", "ImagePath", "Name", "Price" },
                values: new object[] { "SeedID", "https://theworldtravelguy.com/wp-content/uploads/2018/12/DSCF2631-2.jpg", "SeedProduct", 110 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthModelsList",
                keyColumn: "Login",
                keyValue: "user");

            migrationBuilder.DeleteData(
                table: "ProductModelsList",
                keyColumn: "ID",
                keyValue: "SeedID");
        }
    }
}
