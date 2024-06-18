using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.ViewModels
{
    public class InquiryViewModel
    {
        [JsonIgnore]
        public Guid id { get; set; }
        [Required(ErrorMessage = "Please enter Phonenumber")]
        public string? phone_number { get; set; }
        [Required(ErrorMessage = "Please enter Title")]
        public string? title { get; set; }
        [Required(ErrorMessage = "Please enter Messege")]
        public string? message { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
    }
}
