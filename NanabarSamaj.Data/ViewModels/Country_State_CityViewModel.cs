namespace NanabarSamaj.Data.ViewModels
{
    public class lookup_CountryViewModel
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

    public class lookup_StateViewModel
    {
        public Guid id { get; set; } 
        public string? name { get; set; }
        public Guid lookup_country_id { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
    }

    public class lookup_CityViewModel
    {
        public Guid id { get; set; } 
        public string? name { get; set; }
        public Guid lookup_state_id { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
    }
}
