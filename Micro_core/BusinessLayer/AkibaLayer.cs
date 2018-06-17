using System;
using System.Collections.Generic;
using System.Net;
using Micro_core.DataLayer;
using Micro_core.DataLayer.Attributes;
using Micro_core.DataLayer.Models;
using Micro_core.DataLayer.Models.akiba;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.IBusinessLayer;
using Micro_core.Models;
using Micro_core.Models.akiba;

namespace Micro_core.BusinessLayer
{
    public class AkibaLayer: IAkibaLayer
    {
        private static readonly object locker = new object(); 
        public void StartSavingAccount(akibaViewModel avm)
        {

            using (var ctx = new MicroContext())
            {
                using (var trans = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (AkibaAccount.GetByCustomer(avm.customerId) != null)
                            throw new MicroException(" User has a saving account already");

                        var sa = new AkibaAccount();
                        sa.CustomerId = avm.customerId;
                        sa.StaffId = avm.staffId;
                        sa.Balance = avm.Amount;
                        sa.TranscationAmount = avm.Amount;
                        sa.Date = avm.createdDate ?? DateTime.Now;
                        sa.TranscationType = MicroAkibaType.Start;

                        ctx.AkibaAccounts.Add(sa);
                        ctx.SaveChanges();
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new MicroException(HttpStatusCode.NoContent, ex.Message);
                    }
                }

            }

        }

        public void UpdateSavingAccount(akibaViewModel avm)
        {
            
            var lastTransaction = AkibaAccount.GetLastbalance(avm.customerId);


            using (var ctx = new MicroContext())
            {
                using (var trans = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        if (lastTransaction == null) throw new MicroException("User has no saving account yet");

                        lock (locker)
                        {
                            switch (avm.ctORdt)
                            {
                                case MicroAkibaType.Deposit:
                                    {
                                        lastTransaction.Balance += avm.Amount;
                                        lastTransaction.TranscationAmount = avm.Amount;

                                        break;
                                    }
                                case MicroAkibaType.Withdraw:
                                    {
                                        if (lastTransaction.Balance < avm.Amount)
                                            throw new MicroException("User doesnt have sufficient balance to complete this oparation");

                                        lastTransaction.Balance -= avm.Amount;
                                        // minimum ammount required in account.  
                                        if (lastTransaction.Balance < 10000)
                                            throw new MicroException("User cannot witdraw this amount, exceeds minimum account required ");


                                        break;
                                    }
                                default:
                                    throw new MicroException("invailed operation");
                            }
                        }
                        lastTransaction.Id = 0;
                        lastTransaction.TranscationType = avm.ctORdt;
                        lastTransaction.Date = DateTime.Now;

                        ctx.AkibaAccounts.Add(lastTransaction);
                        ctx.SaveChanges();
                        trans.Commit();
                    }

                    catch (Exception ex)
                    {
                        trans.Rollback();
                        throw new MicroException(HttpStatusCode.NoContent, ex.Message);
                    }
                }

            }
        }

        public List<AkibaMultipleViewModel> GetAkibaHistory(int companyId){
            if(companyId == 0) throw new MicroException("Company id not passed"); 

           var listofcontent = new List<AkibaMultipleViewModel>(); 

           var customers = Customer.GetCustomers(); 
          
          foreach (var customer in customers)
          {
              var balance = AkibaAccount.GetLastbalance(customer.CustomerId); 
              
              var ld = AkibaAccount.GetLastbalance(customer.CustomerId, MicroAkibaType.Deposit);
              var lw = AkibaAccount.GetLastbalance(customer.CustomerId, MicroAkibaType.Withdraw); 

              listofcontent.Add( new AkibaMultipleViewModel{
                  CustomerId = customer.CustomerId,
                  Name = $" {customer.First_Name} {customer.Last_Name}" ,
                  Balance = balance?.Balance ?? 0 ,
                  WitdrawDate = lw?.Date ?? default(DateTime?),
                  withdrawAmount = lw?.TranscationAmount ?? default(Decimal?) ,
                  DepositDate = ld?.Date ?? default(DateTime?),
                  DepositAmount = ld?.TranscationAmount ?? default(Decimal?)
              }); 

          }
           
           return listofcontent; 
        }
    }
}