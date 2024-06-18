using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.ViewModels
{
    public class NewsViewModel
    {
        
        public Guid id { get; set; }
        [Required(ErrorMessage = "Please enter title")]

        public string? title { get; set; }
        [Required(ErrorMessage = "Please enter decription")]

        public string? description { get; set; }
        [Required(ErrorMessage = "Please enter image")]

        public string? image { get; set; }
        [Required(ErrorMessage = "Please enter village")]

        public string? village { get; set; }
        public DateTime? dateTime { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
    }
}
