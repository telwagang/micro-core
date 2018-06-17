using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Micro_core.DataLayer.Models.Emuns;
using Micro_core.DataLayer.Models.Management;
using Micro_core.Models;

namespace Micro_core.DataLayer.Models.akiba
{
    public class AkibaAccount
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        [ForeignKey("Staff")]
        public int StaffId { get; set; }
        public MicroAkibaType TranscationType { get; set; }

        public decimal TranscationAmount { get; set; }

        public decimal Balance { get; set; }

        public DateTime Date { get; set; }

        [DefaultValue(false)]
        public bool Deleted {get; set;}


        public  Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }


        public static AkibaAccount GetByCustomer(string id){
            using (var ctx = new MicroContext())
            {
                return ctx.AkibaAccounts.FirstOrDefault(x=> x.CustomerId == id && x.TranscationType == MicroAkibaType.Start && !x.Deleted); 
            }
        }
    
        public static AkibaAccount GetLastbalance(string id)
        {
            using (var ctx = new MicroContext())
            {
                return ctx.AkibaAccounts.Where(x => x.CustomerId == id && !x.Deleted)
                .OrderByDescending(x => x.Date).FirstOrDefault();
            }
        }
        public static AkibaAccount GetLastbalance(string id, MicroAkibaType type){
            
            using (var ctx = new MicroContext())
            {
                return ctx.AkibaAccounts.Where(x => x.CustomerId == id && x.TranscationType == type && !x.Deleted)
                .OrderByDescending(x => x.Date).FirstOrDefault();
            }
        }
    }
}