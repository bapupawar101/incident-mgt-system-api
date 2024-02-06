using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentMgtSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class added_new_columns_in_comments_table_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_IncidentComments_tbl_User_AddedById",
                table: "tbl_IncidentComments");

            migrationBuilder.DropIndex(
                name: "IX_tbl_IncidentComments_AddedById",
                table: "tbl_IncidentComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentComments_AddedById",
                table: "tbl_IncidentComments",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_IncidentComments_tbl_User_AddedById",
                table: "tbl_IncidentComments",
                column: "AddedById",
                principalTable: "tbl_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
