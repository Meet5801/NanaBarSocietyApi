using System.Text.Json.Serialization;

namespace NanabarSamaj.Data.Entities
{
    public class Lookup_Country
    {
        public Guid id { get; set; } 
        public string? name { get; set; }
        public string? image { get; set; }
        public string? code { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; } 
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; } 
        public DateTime? updated_on { get; set; } 
    }
}
