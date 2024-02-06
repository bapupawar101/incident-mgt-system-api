using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IncidentMgtSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class innitial_database_creation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_CountryMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CountryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_RoleMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_RoleMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_TenantMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_TenantMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_StateMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_StateMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_StateMaster_tbl_CountryMaster_CountryId",
                        column: x => x.CountryId,
                        principalTable: "tbl_CountryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_IncidentMasterJson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Json = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_IncidentMasterJson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentMasterJson_tbl_User_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LastLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserLogin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_UserLogin_tbl_User_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CityMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CityMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_CityMaster_tbl_StateMaster_StateId",
                        column: x => x.StateId,
                        principalTable: "tbl_StateMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_IncidentMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequesterId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Urgency = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_IncidentMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentMaster_tbl_CityMaster_CityId",
                        column: x => x.CityId,
                        principalTable: "tbl_CityMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentMaster_tbl_TenantMaster_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tbl_TenantMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentMaster_tbl_User_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "tbl_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_IncidentComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_IncidentComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_IncidentComments_tbl_IncidentMaster_IncId",
                        column: x => x.IncId,
                        principalTable: "tbl_IncidentMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_CityMaster_StateId",
                table: "tbl_CityMaster",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentComments_IncId",
                table: "tbl_IncidentComments",
                column: "IncId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentMaster_CityId",
                table: "tbl_IncidentMaster",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentMaster_RequesterId",
                table: "tbl_IncidentMaster",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentMaster_TenantId",
                table: "tbl_IncidentMaster",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_IncidentMasterJson_RequesterId",
                table: "tbl_IncidentMasterJson",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_StateMaster_CountryId",
                table: "tbl_StateMaster",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserLogin_UserId",
                table: "tbl_UserLogin",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_IncidentComments");

            migrationBuilder.DropTable(
                name: "tbl_IncidentMasterJson");

            migrationBuilder.DropTable(
                name: "tbl_RoleMaster");

            migrationBuilder.DropTable(
                name: "tbl_UserLogin");

            migrationBuilder.DropTable(
                name: "tbl_UserRoles");

            migrationBuilder.DropTable(
                name: "tbl_IncidentMaster");

            migrationBuilder.DropTable(
                name: "tbl_CityMaster");

            migrationBuilder.DropTable(
                name: "tbl_TenantMaster");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "tbl_StateMaster");

            migrationBuilder.DropTable(
                name: "tbl_CountryMaster");
        }
    }
}
