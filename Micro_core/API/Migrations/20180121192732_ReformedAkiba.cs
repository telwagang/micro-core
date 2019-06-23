using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Microcore.Migrations
{
    public partial class ReformedAkiba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AkibaCT");

            migrationBuilder.DropTable(
                name: "AkibaDT");

            migrationBuilder.DropTable(
                name: "Akiba");

            migrationBuilder.DropTable(
                name: "StartAkiba");

            migrationBuilder.CreateTable(
                name: "AkibaAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Balance = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    TranscationAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    TranscationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkibaAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AkibaAccounts_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AkibaAccounts_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AkibaAccounts_CustomerId",
                table: "AkibaAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_AkibaAccounts_StaffId",
                table: "AkibaAccounts",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AkibaAccounts");

            migrationBuilder.CreateTable(
                name: "StartAkiba",
                columns: table => new
                {
                    StartAkibaId = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Insert_Date = table.Column<DateTime>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartAkiba", x => x.StartAkibaId);
                    table.ForeignKey(
                        name: "FK_StartAkiba_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StartAkiba_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Akiba",
                columns: table => new
                {
                    AkibaId = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Akiba", x => x.AkibaId);
                    table.ForeignKey(
                        name: "FK_Akiba_StartAkiba_AkibaId",
                        column: x => x.AkibaId,
                        principalTable: "StartAkiba",
                        principalColumn: "StartAkibaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AkibaCT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkibaId = table.Column<string>(nullable: true),
                    CT_Amount = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkibaCT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AkibaCT_Akiba_AkibaId",
                        column: x => x.AkibaId,
                        principalTable: "Akiba",
                        principalColumn: "AkibaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AkibaCT_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AkibaDT",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AkibaId = table.Column<string>(nullable: true),
                    DT_Amount = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AkibaDT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AkibaDT_Akiba_AkibaId",
                        column: x => x.AkibaId,
                        principalTable: "Akiba",
                        principalColumn: "AkibaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AkibaDT_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AkibaCT_AkibaId",
                table: "AkibaCT",
                column: "AkibaId");

            migrationBuilder.CreateIndex(
                name: "IX_AkibaCT_StaffId",
                table: "AkibaCT",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_AkibaDT_AkibaId",
                table: "AkibaDT",
                column: "AkibaId");

            migrationBuilder.CreateIndex(
                name: "IX_AkibaDT_StaffId",
                table: "AkibaDT",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StartAkiba_CustomerId",
                table: "StartAkiba",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_StartAkiba_StaffId",
                table: "StartAkiba",
                column: "StaffId");
        }
    }
}
