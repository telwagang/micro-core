﻿// <auto-generated />
using Micro_core.DataLayer;
using Micro_core.DataLayer.Models.Emuns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Microcore.Migrations
{
    [DbContext(typeof(MicroContext))]
    [Migration("20180923121509_entityPageRelation")]
    partial class entityPageRelation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Micro_core.DataLayer.Models.akiba.AkibaAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Balance");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<int>("StaffId");

                    b.Property<decimal>("TranscationAmount");

                    b.Property<int>("TranscationType");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("AkibaAccounts");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Auth.MicroUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccessToken");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("FirstDay");

                    b.Property<DateTime>("LastLogin");

                    b.Property<bool>("LockOut");

                    b.Property<DateTime>("LockOutUntill");

                    b.Property<string>("Password");

                    b.Property<int>("Type");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.Dropdown", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Dropdown");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.DropdownValues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Default");

                    b.Property<bool>("Deleted");

                    b.Property<int>("DropDownId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DropDownId");

                    b.ToTable("DropdownValues");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.MicroEmail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<int>("EmailType");

                    b.Property<bool>("IsSent");

                    b.Property<int>("ObjectId");

                    b.Property<string>("SubJect");

                    b.Property<int>("UserType");

                    b.Property<string>("cc");

                    b.HasKey("Id");

                    b.ToTable("Email");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.RoleRights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Right");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleRights");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.Roles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("tbl_roles");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.Staff", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Middle_Name");

                    b.Property<string>("Mobile_Number");

                    b.Property<string>("Position");

                    b.Property<string>("UserID");

                    b.Property<DateTime>("birthdate");

                    b.Property<string>("email");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.UserRoles", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<string>("UserId");

                    b.Property<int>("Id");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("tbl_user_role");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.EntityPages", b =>
                {
                    b.Property<int>("PageId");

                    b.Property<int>("EntityId");

                    b.Property<int>("Id");

                    b.HasKey("PageId", "EntityId");

                    b.HasAlternateKey("Id");

                    b.HasIndex("EntityId");

                    b.ToTable("tbl_Entity_page");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.EntityType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Delete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("tbl_Entity_Type");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.Fields", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DataType");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DisplayName");

                    b.Property<int?>("EnityId1");

                    b.Property<int>("EntityId");

                    b.Property<string>("Key");

                    b.Property<int>("Order");

                    b.Property<bool>("Required");

                    b.Property<bool>("System");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("EnityId1");

                    b.HasIndex("EntityId");

                    b.ToTable("tbl_Fields");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.FieldValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DateValue");

                    b.Property<decimal?>("DecimalValue");

                    b.Property<bool>("Deleted");

                    b.Property<int>("FieldId");

                    b.Property<int>("PageId");

                    b.Property<int?>("Selectvalue");

                    b.Property<string>("StringValue");

                    b.Property<int>("Type");

                    b.Property<int>("VerisonId");

                    b.HasKey("Id");

                    b.ToTable("tbl_Field_Value");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.Pages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<int>("ArithmeticType");

                    b.Property<bool>("Delete");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("tbl_pages");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.PageVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int>("PageId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("PageId");

                    b.ToTable("tbl_page_version");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.ReportDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<int>("Dependant");

                    b.Property<int>("DependencyId");

                    b.Property<int>("DependentType");

                    b.Property<int>("ReportId");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("tbl_report_dependency");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.ReportPages", b =>
                {
                    b.Property<int>("PageId");

                    b.Property<int>("ReportId");

                    b.Property<bool>("Active");

                    b.Property<int>("Column");

                    b.Property<bool>("Deleted");

                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("PageId", "ReportId");

                    b.HasAlternateKey("Id");

                    b.ToTable("tbl_report_pages");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.Reports", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<bool>("Delete");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("tbl_reports");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.ReportVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<int>("ReportId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("ReportId");

                    b.ToTable("tbl_report_version");
                });

            modelBuilder.Entity("Micro_core.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Email");

                    b.Property<int>("KeyValue");

                    b.Property<string>("Location");

                    b.Property<string>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<int>("Tin_no");

                    b.Property<int?>("loanLimitId");

                    b.HasKey("CompanyId");

                    b.HasIndex("loanLimitId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Micro_core.Models.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Division");

                    b.Property<string>("Email");

                    b.Property<string>("First_Name");

                    b.Property<string>("Last_Name");

                    b.Property<string>("Middle_Name");

                    b.Property<string>("Mobile_Number");

                    b.Property<string>("Nationality");

                    b.Property<string>("Occupation");

                    b.Property<int>("StaffId");

                    b.Property<string>("Street");

                    b.Property<string>("Ward");

                    b.Property<int>("national_id");

                    b.HasKey("CustomerId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StaffId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Micro_core.Models.Hisa.HisaHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<int>("Hisa");

                    b.Property<int>("StaffId");

                    b.Property<string>("hisaId");

                    b.HasKey("ID");

                    b.HasIndex("StaffId");

                    b.HasIndex("hisaId");

                    b.ToTable("HisaHistory");
                });

            modelBuilder.Entity("Micro_core.Models.Hisa.HisaLimit", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("Amount");

                    b.Property<bool>("Deleted");

                    b.Property<int>("Hisa");

                    b.HasKey("CompanyId");

                    b.ToTable("HisaLimit");
                });

            modelBuilder.Entity("Micro_core.Models.Hisa.MainHisa", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<int>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<int>("NoHisa");

                    b.HasKey("CustomerId");

                    b.ToTable("Mainhisa");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.Interest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<bool>("Deleted");

                    b.Property<int>("Duration");

                    b.Property<decimal>("Rate");

                    b.Property<int>("StaffId");

                    b.HasKey("ID");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StaffId");

                    b.ToTable("Interest");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.Loan", b =>
                {
                    b.Property<string>("LoanId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActionType");

                    b.Property<decimal>("Amount");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("Date_Sumbit");

                    b.Property<bool>("Deleted");

                    b.Property<int>("Duration");

                    b.Property<string>("ParentId");

                    b.Property<decimal>("ReturnAmount");

                    b.Property<int>("StaffId");

                    b.Property<int>("Status");

                    b.HasKey("LoanId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffId");

                    b.ToTable("Loan");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanDone", b =>
                {
                    b.Property<string>("LoanId");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("Done");

                    b.HasKey("LoanId");

                    b.ToTable("LoanDone");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<decimal>("Fee");

                    b.Property<string>("LoanId");

                    b.HasKey("Id");

                    b.HasIndex("LoanId");

                    b.ToTable("LoanFee");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanLimit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<int>("InterestId");

                    b.Property<decimal>("LimitAmount");

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.ToTable("LoanLimit");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("LoanId");

                    b.Property<decimal>("Monthly");

                    b.Property<DateTime>("Nextpayday");

                    b.Property<bool>("paid");

                    b.HasKey("ID");

                    b.HasIndex("LoanId");

                    b.ToTable("LoanStatus");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AmountPaid");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("LoanId");

                    b.Property<int>("StaffId");

                    b.HasKey("ID");

                    b.HasIndex("LoanId");

                    b.HasIndex("StaffId");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("Micro_core.Models.Management.MemberAddmission", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<bool>("Deleted");

                    b.HasKey("id");

                    b.HasIndex("CustomerId");

                    b.ToTable("MemberAddmission");
                });

            modelBuilder.Entity("Micro_core.Models.Reference", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("StaffID");

                    b.HasKey("ID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("StaffID");

                    b.ToTable("Reference");
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.akiba.AkibaAccount", b =>
                {
                    b.HasOne("Micro_core.Models.Customer", "Customer")
                        .WithMany("Akiba")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Micro_core.DataLayer.Models.Management.Staff", "Staff")
                        .WithMany("Akiba")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.DropdownValues", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.Management.Dropdown")
                        .WithMany("DropdownValues")
                        .HasForeignKey("DropDownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.RoleRights", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.Management.Roles")
                        .WithMany("RoleRights")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.Management.Staff", b =>
                {
                    b.HasOne("Micro_core.Models.Company", "Company")
                        .WithMany("Staff")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.EntityPages", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.reports.EntityType", "EntityTypes")
                        .WithMany("Entitypages")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Micro_core.DataLayer.Models.reports.Pages", "Pages")
                        .WithMany("EntityPages")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.Fields", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.reports.EntityType", "Enity")
                        .WithMany()
                        .HasForeignKey("EnityId1");

                    b.HasOne("Micro_core.DataLayer.Models.reports.EntityType")
                        .WithMany("Fields")
                        .HasForeignKey("EntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.PageVersion", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.reports.Pages")
                        .WithMany("PageVersions")
                        .HasForeignKey("PageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.ReportDependency", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.reports.Reports")
                        .WithMany("ReportDependency")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.DataLayer.Models.reports.ReportVersion", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.reports.Reports")
                        .WithMany("ReportVersion")
                        .HasForeignKey("ReportId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Company", b =>
                {
                    b.HasOne("Micro_core.Models.Loan.LoanLimit", "loanLimit")
                        .WithMany()
                        .HasForeignKey("loanLimitId");
                });

            modelBuilder.Entity("Micro_core.Models.Customer", b =>
                {
                    b.HasOne("Micro_core.Models.Company", "Company")
                        .WithMany("Customer")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Micro_core.DataLayer.Models.Management.Staff", "Staff")
                        .WithMany("Customer")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Hisa.HisaHistory", b =>
                {
                    b.HasOne("Micro_core.DataLayer.Models.Management.Staff")
                        .WithMany("HisaHistory")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Micro_core.Models.Hisa.MainHisa", "hisa")
                        .WithMany("HisaHistory")
                        .HasForeignKey("hisaId");
                });

            modelBuilder.Entity("Micro_core.Models.Hisa.HisaLimit", b =>
                {
                    b.HasOne("Micro_core.Models.Company", "Company")
                        .WithOne("Hisalimit")
                        .HasForeignKey("Micro_core.Models.Hisa.HisaLimit", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Hisa.MainHisa", b =>
                {
                    b.HasOne("Micro_core.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Loan.Interest", b =>
                {
                    b.HasOne("Micro_core.Models.Company", "Company")
                        .WithMany("Interest")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Micro_core.DataLayer.Models.Management.Staff", "Staff")
                        .WithMany("Interest")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Loan.Loan", b =>
                {
                    b.HasOne("Micro_core.Models.Customer", "Customer")
                        .WithMany("loan")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Micro_core.DataLayer.Models.Management.Staff", "Staff")
                        .WithMany("loan")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanDone", b =>
                {
                    b.HasOne("Micro_core.Models.Loan.Loan", "Loan")
                        .WithOne("LoanDone")
                        .HasForeignKey("Micro_core.Models.Loan.LoanDone", "LoanId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanFee", b =>
                {
                    b.HasOne("Micro_core.Models.Loan.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanLimit", b =>
                {
                    b.HasOne("Micro_core.Models.Loan.Interest", "Interst")
                        .WithMany()
                        .HasForeignKey("InterestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Loan.LoanStatus", b =>
                {
                    b.HasOne("Micro_core.Models.Loan.Loan", "Loan")
                        .WithMany("LoanStatus")
                        .HasForeignKey("LoanId");
                });

            modelBuilder.Entity("Micro_core.Models.Loan.Payment", b =>
                {
                    b.HasOne("Micro_core.Models.Loan.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId");

                    b.HasOne("Micro_core.DataLayer.Models.Management.Staff", "Staff")
                        .WithMany("Payment")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Micro_core.Models.Management.MemberAddmission", b =>
                {
                    b.HasOne("Micro_core.Models.Customer", "customer")
                        .WithMany("memberaddmission")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Micro_core.Models.Reference", b =>
                {
                    b.HasOne("Micro_core.Models.Customer", "Customer")
                        .WithMany("Reference")
                        .HasForeignKey("CustomerId");

                    b.HasOne("Micro_core.DataLayer.Models.Management.Staff")
                        .WithMany("reference")
                        .HasForeignKey("StaffID");
                });
#pragma warning restore 612, 618
        }
    }
}
