using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.Models.akiba;
using Micro_core.Models.Management;
using Micro_core.DataLayer;
using System.Linq;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Micro_core.DataLayer.Models.akiba;

namespace Micro_core.Models

{
    public class Customer
    {
        #region Propetaires 

        public Customer() {

            loan = new List<Loan.Loan>();
            Reference = new List<Reference>();
            Akiba = new List<AkibaAccount>();
            memberaddmission = new List<MemberAddmission>();

        }

        [Key]
        public string CustomerId { get; set; }
        public int national_id { get; set; }
        public int StaffId { get; set; }
        public int? CompanyId { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }

        public string Mobile_Number { get; set; }
        public DateTime Birthdate { get; set; }
        public string Occupation { get; set; }
        public string Email { get; set; }
        public string Nationality  { get; set; }
        public string Ward { get; set; }
        public string Division { get; set; }
        public string  Street { get; set; }
        public DateTime Date { get; set; }
        
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
        public virtual ICollection<Loan.Loan> loan { get; set; }
        public  ICollection<AkibaAccount> Akiba { get; set; }
        public virtual ICollection<Reference> Reference { get; set; }
        public virtual ICollection<MemberAddmission> memberaddmission { get; set; }
       
        #endregion

        // public  hisa Hisa { get; set; }
        
        public void save()
        {
            using (var ctx = new MicroContext())
            {
                var old = ctx.Customer.
                AsNoTracking().
                FirstOrDefault(x => x.CustomerId == CustomerId);

                if (old == null)
                {
                    CustomerId =  Guid.NewGuid().ToString("N").Substring(5, 6).ToUpper();
                    ctx.Customer.Add(this);
                }
                else
                {
                    ctx.Entry(this).State = EntityState.Modified;
                }
                ctx.SaveChanges();
            }
        }

        public static Customer GetById(String id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Customer.FirstOrDefault(x=> x.CustomerId == id && !x.Deleted ); 
            }
        }

        public static List<Customer> GetCustomers(){
            using (var ctx = new MicroContext())
            {
              return  ctx.Customer.Where(x=> !x.Deleted).ToList(); 
            }
        }
        public static List<Customer> GetByName(string name)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.Customer.Where(x=> string.Concat(x.First_Name,x.Middle_Name,x.Last_Name).Contains(name) && !x.Deleted).ToList();
            }
        }
    }
}