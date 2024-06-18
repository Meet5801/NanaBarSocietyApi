using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.Entities
{
    public class Inquiry
    {
        public Guid id {  get; set; }
        public string? phone_number {  get; set; }
        public string? title {  get; set; }
        public string? message {  get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
    }
}
