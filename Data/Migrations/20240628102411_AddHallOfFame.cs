using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddHallOfFame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "35a0d0d4-d9f6-4f70-a394-9200cf49aea5", "9df5cc14-23df-4b72-bb84-ec2f3c88f0f7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "369e42c8-a5ea-42bd-9ad4-6ac42b6a7981", "b7b04fd5-ff4d-4f44-81a2-6bcdeca46acb" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35a0d0d4-d9f6-4f70-a394-9200cf49aea5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "369e42c8-a5ea-42bd-9ad4-6ac42b6a7981");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9df5cc14-23df-4b72-bb84-ec2f3c88f0f7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7b04fd5-ff4d-4f44-81a2-6bcdeca46acb");

            migrationBuilder.CreateTable(
                name: "HallOfFame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Titles = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallOfFame", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "211618d4-9667-41fa-b7de-a9b116b52204", "211618d4-9667-41fa-b7de-a9b116b52204", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6ee166fa-23be-4094-9452-b3e338610627", "6ee166fa-23be-4094-9452-b3e338610627", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b383738e-fe4f-4311-8983-d24faf4467c0", 0, "f8f7a891-d573-4b14-9e59-e42590d725a5", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEMYH846qPOzr7F4q8j3DDS/9VC+4jLKaF30KO/nN8bF2AozNwx8T0ytMQpeCUMACBw==", null, false, "e108d22b-3cc1-44df-a80d-7ff515bd58d3", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ebf63353-9517-462c-ad10-a7c153ccc075", 0, "cee102e7-d036-40e1-8f80-9b827216d3be", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USEREXAMPLE", "AQAAAAEAACcQAAAAEJsBkuGddBCfQFniuCgbDo4dWkGyqrhKe7t7+l8mu3Kom71Gu44aUX21BR/0p3MW6g==", null, false, "ea7a30f4-4c0c-4431-9112-c410a9a2e340", false, "userexample" });

            migrationBuilder.InsertData(
                table: "HallOfFame",
                columns: new[] { "Id", "Age", "Name", "Titles" },
                values: new object[] { 1, 48, "Ronnie O'Sullivan", 7 });

            migrationBuilder.InsertData(
                table: "HallOfFame",
                columns: new[] { "Id", "Age", "Name", "Titles" },
                values: new object[] { 2, 55, "Stephen Hendry", 7 });

            migrationBuilder.InsertData(
                table: "HallOfFame",
                columns: new[] { "Id", "Age", "Name", "Titles" },
                values: new object[] { 3, 66, "Steve Davis", 6 });

            migrationBuilder.InsertData(
                table: "HallOfFame",
                columns: new[] { "Id", "Age", "Name", "Titles" },
                values: new object[] { 4, 41, "Mark Selby", 4 });

            migrationBuilder.InsertData(
                table: "HallOfFame",
                columns: new[] { "Id", "Age", "Name", "Titles" },
                values: new object[] { 5, 49, "John Higgins", 4 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "211618d4-9667-41fa-b7de-a9b116b52204", "b383738e-fe4f-4311-8983-d24faf4467c0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ee166fa-23be-4094-9452-b3e338610627", "ebf63353-9517-462c-ad10-a7c153ccc075" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HallOfFame");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "211618d4-9667-41fa-b7de-a9b116b52204", "b383738e-fe4f-4311-8983-d24faf4467c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6ee166fa-23be-4094-9452-b3e338610627", "ebf63353-9517-462c-ad10-a7c153ccc075" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "211618d4-9667-41fa-b7de-a9b116b52204");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee166fa-23be-4094-9452-b3e338610627");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b383738e-fe4f-4311-8983-d24faf4467c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebf63353-9517-462c-ad10-a7c153ccc075");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35a0d0d4-d9f6-4f70-a394-9200cf49aea5", "35a0d0d4-d9f6-4f70-a394-9200cf49aea5", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "369e42c8-a5ea-42bd-9ad4-6ac42b6a7981", "369e42c8-a5ea-42bd-9ad4-6ac42b6a7981", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9df5cc14-23df-4b72-bb84-ec2f3c88f0f7", 0, "0619bbb5-23d6-4410-96c1-82d55f7bbabb", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEKCxZCQf/LgetfR74w716EGNosHktiqbCO1uzJMCvj6Y7w/0IR/HmF/QZHYlGsJQLA==", null, false, "820908bc-178e-4633-a7a6-2c4c69727e70", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b7b04fd5-ff4d-4f44-81a2-6bcdeca46acb", 0, "98fadda7-e506-4b38-8734-11ad0ff49004", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USEREXAMPLE", "AQAAAAEAACcQAAAAEKBDMrxc8W1c/Hn2xjRviU9Ct0U2FVoEyUi7CJhNUtsthxhEtwm0X4lgyki8U1nmXw==", null, false, "3025ecad-6e63-4ef6-9836-5a8828ce417e", false, "userexample" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "35a0d0d4-d9f6-4f70-a394-9200cf49aea5", "9df5cc14-23df-4b72-bb84-ec2f3c88f0f7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "369e42c8-a5ea-42bd-9ad4-6ac42b6a7981", "b7b04fd5-ff4d-4f44-81a2-6bcdeca46acb" });
        }
    }
}
