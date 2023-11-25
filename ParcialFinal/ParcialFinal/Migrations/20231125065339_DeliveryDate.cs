using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcialFinal.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceRequest_Id",
                table: "ServiceRequest");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "ServiceRequest",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "ServiceRequest");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_Id",
                table: "ServiceRequest",
                column: "Id");
        }
    }
}
