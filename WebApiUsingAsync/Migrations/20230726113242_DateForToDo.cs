using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiUsingAsync.Migrations
{
    /// <inheritdoc />
    public partial class DateForToDo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "ToDos",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "ToDos");
        }
    }
}
