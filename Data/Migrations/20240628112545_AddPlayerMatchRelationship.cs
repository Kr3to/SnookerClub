using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class AddPlayerMatchRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Player1Name",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Player2Name",
                table: "Matches");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4284bdfc-2192-4f2b-aa0f-e55b09a05dce", "4284bdfc-2192-4f2b-aa0f-e55b09a05dce", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c6cad21-41ab-4f0a-94fc-672f343d5ccb", "5c6cad21-41ab-4f0a-94fc-672f343d5ccb", "user", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "466e6dde-6952-4f28-be8f-8dc0ddd5a444", 0, "0ab8417d-2f53-430e-985b-162e2976478c", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN", "AQAAAAEAACcQAAAAEHoaR8m0sZGBHattYBe6eQqXg1NKS2BY4eUbk5OYGKOOPd9xtIGo9yzd9Drk9qHtbg==", null, false, "cffd4c53-fe29-4d84-bfa7-e1d5bce10ff8", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b7677d24-5b38-482c-847f-7d9689e229ff", 0, "54cd6ab3-6528-415d-a9f2-c84991cde575", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USEREXAMPLE", "AQAAAAEAACcQAAAAEJh5RBzr9vhRD7g9FG78Uq5fyyO/38ubExmlp4uXzWANYvu7NyI6szzRNp1NEn1ozA==", null, false, "91c44367-b3ea-4789-9429-b7b68b1f2d15", false, "userexample" });

            migrationBuilder.UpdateData(
                table: "HallOfFame",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 45);

            migrationBuilder.UpdateData(
                table: "HallOfFame",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 52);

            migrationBuilder.UpdateData(
                table: "HallOfFame",
                keyColumn: "Id",
                keyValue: 3,
                column: "Age",
                value: 63);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4284bdfc-2192-4f2b-aa0f-e55b09a05dce", "466e6dde-6952-4f28-be8f-8dc0ddd5a444" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5c6cad21-41ab-4f0a-94fc-672f343d5ccb", "b7677d24-5b38-482c-847f-7d9689e229ff" });

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player1Id",
                table: "Matches",
                column: "Player1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Player2Id",
                table: "Matches",
                column: "Player2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_Player1Id",
                table: "Matches",
                column: "Player1Id",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_Player2Id",
                table: "Matches",
                column: "Player2Id",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_Player1Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_Player2Id",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Player1Id",
                table: "Matches");

            migrationBuilder.DropIndex(
                name: "IX_Matches_Player2Id",
                table: "Matches");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4284bdfc-2192-4f2b-aa0f-e55b09a05dce", "466e6dde-6952-4f28-be8f-8dc0ddd5a444" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5c6cad21-41ab-4f0a-94fc-672f343d5ccb", "b7677d24-5b38-482c-847f-7d9689e229ff" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4284bdfc-2192-4f2b-aa0f-e55b09a05dce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c6cad21-41ab-4f0a-94fc-672f343d5ccb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "466e6dde-6952-4f28-be8f-8dc0ddd5a444");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7677d24-5b38-482c-847f-7d9689e229ff");

            migrationBuilder.AddColumn<string>(
                name: "Player1Name",
                table: "Matches",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Player2Name",
                table: "Matches",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.UpdateData(
                table: "HallOfFame",
                keyColumn: "Id",
                keyValue: 1,
                column: "Age",
                value: 48);

            migrationBuilder.UpdateData(
                table: "HallOfFame",
                keyColumn: "Id",
                keyValue: 2,
                column: "Age",
                value: 55);

            migrationBuilder.UpdateData(
                table: "HallOfFame",
                keyColumn: "Id",
                keyValue: 3,
                column: "Age",
                value: 66);

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "211618d4-9667-41fa-b7de-a9b116b52204", "b383738e-fe4f-4311-8983-d24faf4467c0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6ee166fa-23be-4094-9452-b3e338610627", "ebf63353-9517-462c-ad10-a7c153ccc075" });
        }
    }
}
