using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.Entities
{
    public class Business
    {
        public Guid id { get; set; }
        public string? concern_name { get; set; }
        public string? business_name { get; set; }
        public string? business_details { get; set; }
        public Guid? lookup_business_category_id { get; set; }
        public string? address { get; set; }
        public Guid lookup_city_id { get; set; }
        public Guid lookup_country_id { get; set; }
        public Guid lookup_state_id { get; set; }
        public string? zipcode { get; set; }
        public string? contact_number_1 { get; set; }
        public string? contact_number_2 { get; set; }
        public string? website { get; set; }
        public string? email { get; set; }
      //  public string? location_link { get; set; }
      //  public string? youtube_link { get; set; }
        public string? facebook_link { get; set; }
        public string? instagram_link { get; set; }
      //  public string? telegram_link { get; set; }
        public string? business_image_1 { get; set; }
      //  public string? business_image_2 { get; set; }
      //  public string? business_image_3 { get; set; }
      //  public string? business_image_4 { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
        public Guid user_id { get; set; }
    }
}
