using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Micro_core.Models.akiba;

namespace Micro_core.Models
{
    public class Akiba
    {
        public Akiba()
        {
            AkibaCT = new List<AkibaCT>();
            AkibaDT = new List<AkibaDT>();
        }
        
        public int ID { get; set; }
        [Key,ForeignKey("StartAkiba")]
        public string AkibaId { get; set; }
      
        public int Amount { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }

        public  StartAkiba StartAkiba { get; set; }
        public virtual ICollection<AkibaCT> AkibaCT { get; set; }
        public virtual ICollection<AkibaDT> AkibaDT { get; set; }

        
    }
}