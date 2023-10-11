using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RMSystemApi.Migrations
{
    /// <inheritdoc />
    public partial class bookingupdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Property_PropertyId",
                table: "Bookings");

            migrationBuilder.AddColumn<DateTime>(
                name: "ConfirmedDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Property_PropertyId",
                table: "Bookings",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Property_PropertyId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ConfirmedDate",
                table: "Bookings");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Property_PropertyId",
                table: "Bookings",
                column: "PropertyId",
                principalTable: "Property",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
