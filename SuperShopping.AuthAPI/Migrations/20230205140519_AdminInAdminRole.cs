using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperShopping.AuthAPI.Migrations
{
    /// <inheritdoc />
    public partial class AdminInAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "72a49daf-1f4d-4e56-81a1-6c9e83999d24");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "7fc5bf49-34fe-4623-8e0e-002b297ee2cc");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40e0f362-0991-440c-bbd0-5b2a04b71174", "AQAAAAIAAYagAAAAEBv8p5TiYjOkkGgNAFOhdvuN6Mq4QjZBoT7tt9V3zNrB0NZDAA1wUESOc3qwPAY8gg==", "94edc144-8b8e-4013-8b68-a17134c182d1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "445d4358-38c1-44ca-beb2-70391d0f9ad4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5028f177-3e02-45b6-a625-fcc53c793c85");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc28fa8d-8297-49cb-aab4-5ad6fce4f1ba", "AQAAAAIAAYagAAAAEH635JHjNX9WF6dXwCjPVvZLn3LwN9aa/74ufrjzHuBkfMV6Brod19T4XgC75K4rtg==", "55496345-72f9-4b6f-98fa-2ede26f4e45e" });
        }
    }
}
