using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.Entities
{
    public class Lookup_Besnu
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public Guid lookup_village_id { get; set; }
        public DateTime death_date { get; set; }
        public DateTime besnu_date { get; set; }
        public string? address { get; set; }
        public string? start_time { get; set; }
        public string? end_time { get; set; }
        public string? relative_name { get; set; }
        public string? image { get; set; }
        public string? village {  get; set; }
        public int? age { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }

    }
}
