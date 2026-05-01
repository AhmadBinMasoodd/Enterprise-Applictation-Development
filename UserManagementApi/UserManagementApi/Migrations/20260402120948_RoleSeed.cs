using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagementApi.Migrations
{
    /// <inheritdoc />
    public partial class RoleSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "49145a4c-5cd6-4a8e-8f4f-2b51e6fb606d", "3c8b96ee-0064-4613-ae94-99e334a1fea8", "Admin", "Admin" },
                    { "7e5ff430-700c-4dd0-a7c1-a8eab9626141", "cb2b30ae-c597-461f-9978-2b6a3177b982", "HR", "HR" },
                    { "f03e315e-bae9-4699-bf4a-962d833f6e8f", "187481e9-a3be-481e-8ad4-7213aeaf84d0", "User", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "49145a4c-5cd6-4a8e-8f4f-2b51e6fb606d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e5ff430-700c-4dd0-a7c1-a8eab9626141");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f03e315e-bae9-4699-bf4a-962d833f6e8f");
        }
    }
}
