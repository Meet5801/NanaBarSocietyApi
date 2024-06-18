using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.Entities
{
    public class Members
    {
        public Guid id { get; set; }
        public Guid lookup_relation_type_id { get; set; }
        public string? surname { get; set; }
        public string? name { get; set; }
        public string? father_or_husband_name { get; set; }
        public string? gender { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public DateTime dob { get; set; }
        public int age { get; set; }
        public Guid lookup_village_id { get; set; }
        public Guid lookup_sakh_id { get; set; }
        public string? address { get; set; }
        public Guid lookup_city_id { get; set; }
        public Guid lookup_country_id { get; set; }
        public Guid lookup_marital_type_id { get; set; }
        public Guid lookup_education_type_id { get; set; }
        public Guid lookup_education_sub_type_id { get; set; }
        public Guid lookup_occupation_id { get; set; }
        public string? designation { get; set; }
        public string? company { get; set; }
        public string? occupation_address { get; set; }
        public string? mama_name { get; set; }
        public Guid lookup_blood_group_id { get; set; }
        public Guid lookup_pragatimandal_id { get; set; }
        public string? height_foot { get; set; }
        public string? height_inch { get; set; }
        public string? weight { get; set; }
        public string? image { get; set; }
        public bool interested_matrimonial { get; set; }
        public bool interested_blood_donate { get; set; }
        public string? about_me { get; set; }
        public bool is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
        public Guid user_id { get; set; }
        public bool you_live_abroad { get; set; }
    }
}
