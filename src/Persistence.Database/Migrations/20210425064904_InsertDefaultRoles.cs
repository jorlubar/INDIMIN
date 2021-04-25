using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Database.Migrations
{
    public partial class InsertDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99588087-3b24-4e65-a794-c36af00a7630", "957c105b-160a-44f6-b927-6e082adb9a31", "ApplicationRole", "Ojo", "Ojo" },
                    { "d42500f8-ceeb-4888-a768-295d679ee2b4", "21bb6c60-5599-47ed-976c-ba9e2c7d5b2a", "ApplicationRole", "Bruja", "Bruja" },
                    { "cd52e489-07f7-4f4b-ba4e-4cf63b232879", "ba1aec25-3bfd-4ff1-adbc-bc2e8b598dad", "ApplicationRole", "Ciudadano", "Ciudadano" },
                    { "789c3ec1-520f-43f6-bac0-7806b2bc2b93", "2767d426-0ca1-4c36-9d9a-a06b2ceb1425", "ApplicationRole", "Administrador", "Administrador" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "789c3ec1-520f-43f6-bac0-7806b2bc2b93");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99588087-3b24-4e65-a794-c36af00a7630");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd52e489-07f7-4f4b-ba4e-4cf63b232879");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d42500f8-ceeb-4888-a768-295d679ee2b4");
        }
    }
}
