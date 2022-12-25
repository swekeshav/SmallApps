using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTodoItemTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "TodoItems",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TodoItems",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Completed",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "TodoItems");
        }
    }
}
