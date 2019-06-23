using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Microcore.Migrations
{
    public partial class entityPageRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "version",
                table: "tbl_report_version",
                newName: "Version");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "tbl_Field_Value",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Entity_page_EntityId",
                table: "tbl_Entity_page",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Entity_page_tbl_Entity_Type_EntityId",
                table: "tbl_Entity_page",
                column: "EntityId",
                principalTable: "tbl_Entity_Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Entity_page_tbl_pages_PageId",
                table: "tbl_Entity_page",
                column: "PageId",
                principalTable: "tbl_pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Entity_page_tbl_Entity_Type_EntityId",
                table: "tbl_Entity_page");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Entity_page_tbl_pages_PageId",
                table: "tbl_Entity_page");

            migrationBuilder.DropIndex(
                name: "IX_tbl_Entity_page_EntityId",
                table: "tbl_Entity_page");

            migrationBuilder.DropColumn(
                name: "PageId",
                table: "tbl_Field_Value");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "tbl_report_version",
                newName: "version");
        }
    }
}
