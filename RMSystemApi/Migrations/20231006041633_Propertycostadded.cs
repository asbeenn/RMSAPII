﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class Propertycostadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "RentCost",
                table: "Property",
                type: "decimal(18,2)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RentCost",
                table: "Property");
        }
    }
}
