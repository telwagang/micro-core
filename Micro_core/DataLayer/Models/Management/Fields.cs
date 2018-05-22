using System.ComponentModel;
using Micro_core.DataLayer.Models.Emuns;

namespace Micro_core.DataLayer.Models.Management
{
    public class Fields
    {
        public int Id { get; set; }

        public MicroFieldType Control_Type { get; set; }

        public string DisplayName { get; set; }

        public string Type { get; set; }
        public string Key { get; set; }
        public bool Required { get; set; }
        public bool System {get; set; }
        public int Order { get; set; }
        [DefaultValue(false)]
        public bool Deleted { get; set; }
    }
}