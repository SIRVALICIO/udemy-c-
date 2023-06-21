using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Identity.Migrations
{
    public partial class nuevaMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79ba8e3f-5c28-42cb-a03e-babcfb0b5bd8",
                column: "ConcurrencyStamp",
                value: "64d23dfc-009e-485f-b151-88bdc4ed94d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c26c17c-ffe7-43ad-a3b3-b6d50ca71a63",
                column: "ConcurrencyStamp",
                value: "72cd3a0e-c12d-41c6-9ddf-3296a8db7fd0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9926c17c-ffe7-43ad-a3b3-b6d50ca71a63", "ad7f7156-6567-4dfe-937c-238a80f33999", "prueba", "PRUEBA" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "294d249b-9b57-48c1-9689-11a91abb6447",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "96278be5-8594-4b7a-a2bb-5dff2161b6a1", "AQAAAAEAACcQAAAAELzg+hAeMWcGv6XrmsHkxrD6WtpZkTp6MDEcr8JQaVU9FYXHGWCCEMVcoXUiArQslQ==", "230fdc58-7dc2-4a32-a207-7bf9706bf0f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f284b3fd-f2cf-476e-a9b6-6560689cc48c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8767766b-1bcf-4854-bb16-d362e9a56644", "AQAAAAEAACcQAAAAEJIxdoQcfk/I/7XBddVWZvX1aM04LTcp0un9CsX2c/CmI5K0wXiZ4t1U0Aty9kIf/A==", "b17a8a35-a8d6-449a-bcce-d03ae3623bcd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9926c17c-ffe7-43ad-a3b3-b6d50ca71a63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "79ba8e3f-5c28-42cb-a03e-babcfb0b5bd8",
                column: "ConcurrencyStamp",
                value: "af66e885-a884-4487-8cf1-193bb3d7246b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c26c17c-ffe7-43ad-a3b3-b6d50ca71a63",
                column: "ConcurrencyStamp",
                value: "476abfdf-9007-429e-ad9c-41e5e464f13c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "294d249b-9b57-48c1-9689-11a91abb6447",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24f6e7bf-1fb8-471a-a80c-9a5548c7ac37", "AQAAAAEAACcQAAAAEPoY1NL8nfyIDPWjpv7Qsvt/GmltN5fvLoz3LEdB8EnSLJrX2C7F4typ4u6B1Jo18A==", "4bdfd5da-f264-493c-b718-662ab0415459" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f284b3fd-f2cf-476e-a9b6-6560689cc48c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e53003f-72cd-44ef-a53c-19a30ed0aa15", "AQAAAAEAACcQAAAAENWtdrn6GOb1rjLWPIwP2qHmJR+FPwXhAKlpL8c7WnhrHwR19aE4kGV2B04r+NAelQ==", "ba36f476-a51b-42b9-ae3e-f9d56a02cec3" });
        }
    }
}
