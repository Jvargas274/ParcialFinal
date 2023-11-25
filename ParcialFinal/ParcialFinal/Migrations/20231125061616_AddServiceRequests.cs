using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcialFinal.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedServiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_Services_SelectedServiceId",
                        column: x => x.SelectedServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_Id",
                table: "ServiceRequest",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_SelectedServiceId",
                table: "ServiceRequest",
                column: "SelectedServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRequest");
        }
    }
}
