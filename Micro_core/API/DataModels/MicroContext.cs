using System;
using API.DataModels.akiba;
using API.DataModels.Auth;
using API.DataModels.Hisa;
using API.DataModels.Loan;
using API.DataModels.Management;
using API.DataModels.reports;
using Micro_core.Models.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.DataModels
{
    internal class MicroContext : DbContext
    {
        public MicroContext()
        {
            //Create();
        }
        public MicroContext(DbContextOptions<MicroContext> options) : base(options)
        {

        }

        public DbSet<MicroUser> User { get; set; }

        public DbSet<AkibaAccount> AkibaAccounts { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<MicroEmail> Email { get; set; }
        public DbSet<Dropdown> Dropdown { get; set; }
        public DbSet<DropdownValues> DropdownValues { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<RoleRights> RoleRights { get; set; }

        public DbSet<Loans> Loan { get; set; }
        public DbSet<LoanLimit> LoanLimit { get; set; }
        public DbSet<LoanStatus> LoanStatus { get; set; }
        public DbSet<LoanFee> LoanFee { get; set; }
        public DbSet<Interest> Interest { get; set; }


        public DbSet<MainHisa> Mainhisa { get; set; }
        public DbSet<HisaHistory> HisaHistory { get; set; }
        public DbSet<HisaLimit> HisaLimit { get; set; }


        public DbSet<Reports> Report { get; set; }
        public DbSet<ReportPages> ReportPage { get; set; }
        public DbSet<ReportDependency> ReportDependency { get; set; }
        public DbSet<ReportVersion> ReportVersion { get; set; }
        public DbSet<Pages> Page { get; set; }
        public DbSet<PageVersion> PageVersion { get; set; }
        public DbSet<EntityPages> EntityPage { get; set; }
        public DbSet<EntityType> EntityType { get; set; }
        public DbSet<Fields> Field { get; set; }
        public DbSet<FieldValue> FieldValue { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
            var basePath = Environment.CurrentDirectory;

            var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            //.AddJsonFile($"appsettings.{environmentName}.json", true)
            ;

            var config = builder.Build();
            var connstr = config.GetConnectionString("DefaultConnection");


            optionsBuilder.UseSqlServer(connstr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder Conventions.Remove<PluralizingTableNameConvention>();


            //   modelBuilder.Entity<IdentityUserClaim>().ToTable("webpages_claims");

            // modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<UserRoles>()
            .HasKey(x => new { x.RoleId, x.UserId });

            modelBuilder.Entity<Roles>()
            .HasMany(x => x.RoleRights)
            .WithOne()
            .HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<RoleRights>()
            .HasIndex(x => x.RoleId);

            modelBuilder.Entity<ReportPages>()
            .HasKey(x => new { x.PageId, x.ReportId });

            modelBuilder.Entity<EntityPages>()
            .HasKey(s => new { s.PageId, s.EntityId });

            modelBuilder.Entity<EntityPages>()
    .HasOne(sc => sc.EntityTypes)
    .WithMany(s => s.Entitypages)
    .HasForeignKey(sc => sc.EntityId);


            modelBuilder.Entity<EntityPages>()
                .HasOne(sc => sc.Pages)
                .WithMany(s => s.EntityPages)
                .HasForeignKey(sc => sc.PageId);

            modelBuilder.Entity<EntityType>()
            .HasMany(x => x.Fields)
            .WithOne()
            .HasForeignKey(x => x.EntityId);

            modelBuilder.Entity<Pages>()
            .HasMany(x => x.PageVersions)
            .WithOne()
            .HasForeignKey(x => x.PageId);

            modelBuilder.Entity<Reports>()
            .HasMany(x => x.ReportVersion)
            .WithOne()
            .HasForeignKey(x => x.ReportId);

            modelBuilder.Entity<Reports>()
            .HasMany(x => x.ReportDependency)
            .WithOne()
            .HasForeignKey(x => x.ReportId);

            modelBuilder.Entity<Dropdown>()
            .HasMany(x => x.DropdownValues)
            .WithOne()
            .HasForeignKey(x => x.DropDownId);
        }

    }
}