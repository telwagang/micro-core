using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Microcore.Migrations
{
    public partial class ReportModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dropdown",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dropdown", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LoanFee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Fee = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanFee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanFee_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Entity_page",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Entity_page", x => new { x.PageId, x.EntityId });
                    table.UniqueConstraint("AK_tbl_Entity_page_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Entity_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Entity_Type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Field_Value",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateValue = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DecimalValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    FieldId = table.Column<int>(type: "int", nullable: false),
                    Selectvalue = table.Column<int>(type: "int", nullable: true),
                    StringValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    VerisonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Field_Value", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ArithmeticType = table.Column<int>(type: "int", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_pages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_report_pages",
                columns: table => new
                {
                    PageId = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_report_pages", x => new { x.PageId, x.ReportId });
                    table.UniqueConstraint("AK_tbl_report_pages_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_role", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "DropdownValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DropDownId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropdownValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DropdownValues_Dropdown_DropDownId",
                        column: x => x.DropDownId,
                        principalTable: "Dropdown",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Fields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnityId1 = table.Column<int>(type: "int", nullable: true),
                    EntityId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Required = table.Column<bool>(type: "bit", nullable: false),
                    System = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Fields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_Fields_tbl_Entity_Type_EnityId1",
                        column: x => x.EnityId1,
                        principalTable: "tbl_Entity_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Fields_tbl_Entity_Type_EntityId",
                        column: x => x.EntityId,
                        principalTable: "tbl_Entity_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_page_version",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_page_version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_page_version_tbl_pages_PageId",
                        column: x => x.PageId,
                        principalTable: "tbl_pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_report_dependency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Dependant = table.Column<int>(type: "int", nullable: false),
                    DependencyId = table.Column<int>(type: "int", nullable: false),
                    DependentType = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_report_dependency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_report_dependency_tbl_reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "tbl_reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_report_version",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_report_version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_report_version_tbl_reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "tbl_reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Right = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleRights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleRights_tbl_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tbl_roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DropdownValues_DropDownId",
                table: "DropdownValues",
                column: "DropDownId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanFee_LoanId",
                table: "LoanFee",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleRights_RoleId",
                table: "RoleRights",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Fields_EnityId1",
                table: "tbl_Fields",
                column: "EnityId1");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Fields_EntityId",
                table: "tbl_Fields",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_page_version_PageId",
                table: "tbl_page_version",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_report_dependency_ReportId",
                table: "tbl_report_dependency",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_report_version_ReportId",
                table: "tbl_report_version",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DropdownValues");

            migrationBuilder.DropTable(
                name: "LoanFee");

            migrationBuilder.DropTable(
                name: "RoleRights");

            migrationBuilder.DropTable(
                name: "tbl_Entity_page");

            migrationBuilder.DropTable(
                name: "tbl_Field_Value");

            migrationBuilder.DropTable(
                name: "tbl_Fields");

            migrationBuilder.DropTable(
                name: "tbl_page_version");

            migrationBuilder.DropTable(
                name: "tbl_report_dependency");

            migrationBuilder.DropTable(
                name: "tbl_report_pages");

            migrationBuilder.DropTable(
                name: "tbl_report_version");

            migrationBuilder.DropTable(
                name: "tbl_user_role");

            migrationBuilder.DropTable(
                name: "Dropdown");

            migrationBuilder.DropTable(
                name: "tbl_roles");

            migrationBuilder.DropTable(
                name: "tbl_Entity_Type");

            migrationBuilder.DropTable(
                name: "tbl_pages");

            migrationBuilder.DropTable(
                name: "tbl_reports");
        }
    }
}
