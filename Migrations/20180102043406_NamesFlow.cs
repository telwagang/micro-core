using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Microcore.Migrations
{
    public partial class NamesFlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "datesumbit",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "occuption",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "Insert_date",
                table: "StartAkiba",
                newName: "Insert_Date");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Staff",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Reference",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Mainhisa",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Mainhisa",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "monthly",
                table: "LoanStatus",
                newName: "Monthly");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "LoanPayment",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "limitAmount",
                table: "LoanLimit",
                newName: "LimitAmount");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "loanBalance",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "LoanApplication",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "returnAmount",
                table: "Loan",
                newName: "ReturnAmount");

            migrationBuilder.RenameColumn(
                name: "rate",
                table: "Interest",
                newName: "Rate");

            migrationBuilder.RenameColumn(
                name: "duration",
                table: "Interest",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "HisaLimit",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "HisaHistory",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "HisaHistory",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Customer",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Company",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Company",
                newName: "Date");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "StartAkiba",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Staff",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "MemberAddmission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Mainhisa",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LoanStatus",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LoanPayment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LoanLimit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LoanDone",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "loanBalance",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "LoanApplication",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date_Sumbit",
                table: "Loan",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Loan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Interest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "HisaLimit",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "HisaHistory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Company",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AkibaDT",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "AkibaCT",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Akiba",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "StartAkiba");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "MemberAddmission");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Mainhisa");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LoanStatus");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LoanPayment");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LoanLimit");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LoanDone");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "loanBalance");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "LoanApplication");

            migrationBuilder.DropColumn(
                name: "Date_Sumbit",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Loan");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Interest");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "HisaLimit");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "HisaHistory");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AkibaDT");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "AkibaCT");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Akiba");

            migrationBuilder.RenameColumn(
                name: "Insert_Date",
                table: "StartAkiba",
                newName: "Insert_date");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Staff",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reference",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Mainhisa",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Mainhisa",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Monthly",
                table: "LoanStatus",
                newName: "monthly");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "LoanPayment",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "LimitAmount",
                table: "LoanLimit",
                newName: "limitAmount");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "loanBalance",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "LoanApplication",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "ReturnAmount",
                table: "Loan",
                newName: "returnAmount");

            migrationBuilder.RenameColumn(
                name: "Rate",
                table: "Interest",
                newName: "rate");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Interest",
                newName: "duration");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "HisaLimit",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "HisaHistory",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "HisaHistory",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Customer",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Company",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Company",
                newName: "date");

            migrationBuilder.AddColumn<DateTime>(
                name: "datesumbit",
                table: "Loan",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "occuption",
                table: "Customer",
                nullable: true);
        }
    }
}
