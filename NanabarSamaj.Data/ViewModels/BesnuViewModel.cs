using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.ViewModels
{
    public class BesnuViewModel
    {
        
        public Guid id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string? name { get; set; }
        public Guid lookup_village_id { get; set; }
        public DateTime death_date { get; set; }
        public DateTime besnu_date { get; set; }
        [Required(ErrorMessage = "Please enter address")]
        public string? address { get; set; }
        [Required(ErrorMessage = "Please enter startTime")]
        public string? start_time { get; set; }
        [Required(ErrorMessage = "Please enter endTime")]
        public string? end_time { get; set; }
        [Required(ErrorMessage = "Please enter relative Name")]
        public string? relative_name { get; set; }
        [Required(ErrorMessage = "Please enter Image")]
        public string? image { get; set; }
        [Required(ErrorMessage = "Please enter Village")]
        public string? village { get; set; }
        [Required(ErrorMessage = "Please enter Age")]
        public int? age { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
    }
}
