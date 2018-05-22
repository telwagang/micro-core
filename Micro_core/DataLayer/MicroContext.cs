using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Micro_core.DataLayer.Models.akiba;
using Micro_core.DataLayer.Models.Auth;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models;
using Micro_core.Models.akiba;
using Micro_core.Models.Hisa;
using Micro_core.Models.Loan;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Micro_core.DataLayer
{
    public class MicroContext : DbContext
    {
        public MicroContext()
        {
            //Create();
        }
        public MicroContext (DbContextOptions<MicroContext> options) : base(options){

        }
        

       /*  public MicroContext Create(){
            var environmentName = Environment.GetEnvironmentVariable("Hosting:Environment");
            var basePath = Environment.CurrentDirectory;

            var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            //.AddJsonFile($"appsettings.{environmentName}.json", true)
            ;

            var config = builder.Build();
            var connstr = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connstr);
            return new MicroContext(optionsBuilder.Options);
        } */

       public DbSet<MicroUser> User { get; set; }
    
       public DbSet<AkibaAccount> AkibaAccounts { get; set; }
       public DbSet<Staff> Staff { get; set; }
       public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<MicroEmail> Email {get; set;}

        public DbSet<Loan> Loan { get; set; }
        public DbSet<LoanBalance> loanBalance { get; set; }
        public DbSet<LoanApplicantion> LoanApplication { get; set; }
        public DbSet<LoanLimit> LoanLimit { get; set; }
        public DbSet<LoanStatus> LoanStatus { get; set; }
        public DbSet<Payment> LoanPayment { get; set; }
        public DbSet<Interest> Interest { get; set; }
        public DbSet<LoanDone> LoanDone { get; set; }


        public DbSet<MainHisa> Mainhisa { get; set; }
        public DbSet<HisaHistory> HisaHistory { get; set; }
        public DbSet<HisaLimit> HisaLimit { get; set; }


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


        }

    }
}