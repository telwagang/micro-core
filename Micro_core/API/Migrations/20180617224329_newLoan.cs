using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Microcore.Migrations
{
    public partial class newLoan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanLimit_Company_CompanyId",
                table: "LoanLimit");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayment_Loan_LoanId",
                table: "LoanPayment");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanPayment_Staff_StaffId",
                table: "LoanPayment");

            migrationBuilder.DropTable(
                name: "LoanApplication");

            migrationBuilder.DropTable(
                name: "loanBalance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanPayment",
                table: "LoanPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanLimit",
                table: "LoanLimit");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "LoanLimit");

            migrationBuilder.RenameTable(
                name: "LoanPayment",
                newName: "Payment");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayment_StaffId",
                table: "Payment",
                newName: "IX_Payment_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_LoanPayment_LoanId",
                table: "Payment",
                newName: "IX_Payment_LoanId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Monthly",
                table: "LoanStatus",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "paid",
                table: "LoanStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "LimitAmount",
                table: "LoanLimit",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LoanLimit",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "InterestId",
                table: "LoanLimit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "ReturnAmount",
                table: "Loan",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Loan",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "ParentId",
                table: "Loan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Loan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "Interest",
                type: "decimal(18, 2)",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "loanLimitId",
                table: "Company",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Payment",
                table: "Payment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanLimit",
                table: "LoanLimit",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LoanLimit_InterestId",
                table: "LoanLimit",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_loanLimitId",
                table: "Company",
                column: "loanLimitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_LoanLimit_loanLimitId",
                table: "Company",
                column: "loanLimitId",
                principalTable: "LoanLimit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanLimit_Interest_InterestId",
                table: "LoanLimit",
                column: "InterestId",
                principalTable: "Interest",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Loan_LoanId",
                table: "Payment",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "LoanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Staff_StaffId",
                table: "Payment",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_LoanLimit_loanLimitId",
                table: "Company");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanLimit_Interest_InterestId",
                table: "LoanLimit");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Loan_LoanId",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Staff_StaffId",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Payment",
                table: "Payment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoanLimit",
                table: "LoanLimit");

            migrationBuilder.DropIndex(
                name: "IX_LoanLimit_InterestId",
                table: "LoanLimit");

            migrationBuilder.DropIndex(
                name: "IX_Company_loanLimitId",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "paid",
                table: "LoanStatus");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LoanLimit");

            migrationBuilder.DropColumn(
                name: "InterestId",
                table: "LoanLimit");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "loanLimitId",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Payment",
                newName: "LoanPayment");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_StaffId",
                table: "LoanPayment",
                newName: "IX_LoanPayment_StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_LoanId",
                table: "LoanPayment",
                newName: "IX_LoanPayment_LoanId");

            migrationBuilder.AlterColumn<int>(
                name: "Monthly",
                table: "LoanStatus",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "LimitAmount",
                table: "LoanLimit",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "LoanLimit",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ReturnAmount",
                table: "Loan",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Loan",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AlterColumn<double>(
                name: "Rate",
                table: "Interest",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 2)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanPayment",
                table: "LoanPayment",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoanLimit",
                table: "LoanLimit",
                column: "CompanyId");

            migrationBuilder.CreateTable(
                name: "LoanApplication",
                columns: table => new
                {
                    LoanId = table.Column<string>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplication", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_LoanApplication_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "loanBalance",
                columns: table => new
                {
                    LoanId = table.Column<string>(nullable: false),
                    Balance = table.Column<int>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loanBalance", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_loanBalance_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_LoanLimit_Company_CompanyId",
                table: "LoanLimit",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayment_Loan_LoanId",
                table: "LoanPayment",
                column: "LoanId",
                principalTable: "Loan",
                principalColumn: "LoanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanPayment_Staff_StaffId",
                table: "LoanPayment",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
