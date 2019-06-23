using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
//using API.DataModels.Management;
using API.Enums;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.DataModels.Loan
{
    public class Loans : IBaseModel
    {
        public Loans()
        {
            LoanStatus = new List<LoanStatus>();
        }

        public int Id
        {
            get;
            set;
        }

        [Key]
        public string LoanId { get; set; }
        public string CustomerId { get; set; }
        public int StaffId { get; set; }
        public int Duration { get; set; }
        public decimal Amount { get; set; }
        public decimal ReturnAmount { get; set; }
        public string ParentId {get;set; }
        public MicroLoanStatus Status { get; set; }
        public MicroLoanType ActionType { get; set; }

        public DateTime Date_Sumbit { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("StaffId")]
        public virtual Staff Staff { get; set; }
        public virtual ICollection<LoanStatus> LoanStatus { get; set; }

       
       
         public void saveStatus(MicroContext ctx, LoanStatus ls){
           
                var old = ctx.LoanStatus.
                AsNoTracking().
                FirstOrDefault(x => x.ID == ls.ID);

                if (old == null)
                {
                    ctx.LoanStatus.Add(ls);
                }
                else
                {
                    ctx.Entry(ls).State = EntityState.Modified;
                }
                ctx.SaveChanges();

       }
       
        public static List<Loans> GetLoanByCompany(string id)
        {
          using(var ctx = new MicroContext()){
              return ctx.Loan.Where(x=> x.LoanId == id && !x.Deleted)
              .ToList(); 
          }
        }
        public static List<LoanPending> GetLoanStatus(){
            using(var ctx = new MicroContext()){
                return (from c in ctx.Loan
                        join s in ctx.Customer on c.CustomerId equals s.CustomerId
                        join ls in ctx.LoanStatus on c.LoanId equals ls.LoanId
                        where c.ActionType != MicroLoanType.Application || 
                        c.ActionType != MicroLoanType.Done  
                        && !c.Deleted  && !ls.Deleted
                        select new LoanPending{
                         customerName = s.First_Name +" "+s.Middle_Name+" "+s.Last_Name,
                         CustomerId = s.CustomerId,
                         DueDate = ls.Nextpayday,
                         Amount = ls.Monthly.ToString(),
                         LoanId = c.LoanId
                        }).ToList();
            }
        }

        internal object GetLastByLoanId(string loanId)
        {
            throw new NotImplementedException();
        }



    }
}