using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentMgtSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class added_new_columns_in_comments_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedById",
                table: "tbl_IncidentComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "tbl_IncidentComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "tbl_IncidentComments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "tbl_IncidentComments");
        }
    }
}
