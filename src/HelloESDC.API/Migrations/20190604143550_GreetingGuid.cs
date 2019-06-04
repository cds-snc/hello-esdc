using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HelloESDC.API.Migrations
{
    public partial class GreetingGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Greetings",
                table: "Greetings");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Greetings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Greetings",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Greetings",
                table: "Greetings",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Greetings_Name",
                table: "Greetings",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Greetings",
                table: "Greetings");

            migrationBuilder.DropIndex(
                name: "IX_Greetings_Name",
                table: "Greetings");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Greetings");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Greetings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Greetings",
                table: "Greetings",
                column: "Name");
        }
    }
}
