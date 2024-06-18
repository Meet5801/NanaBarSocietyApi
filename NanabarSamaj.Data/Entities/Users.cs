using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Data.Entities
{
    public class Users
    {
        public Guid id { get; set; }
        public string? name { get; set; }
        public string? father_name { get; set; }
        public string? surname { get; set; }
        public string? mobile_number { get; set; }
        public string? email { get; set; }
        public string? gender { get; set; }
        public string? address { get; set; }
        public Guid lookup_city_id { get; set; }
        public Guid lookup_state_id { get; set; }
        public Guid lookup_country_id { get; set; }
        public string? pincode { get; set; }
        public Guid lookup_sakh_id { get; set; }
        public string? password { get; set; }
        public bool is_terms { get; set; }
        public string? image { get; set; }
        public bool is_active { get; set; }
        public bool is_verify { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
        public Guid? lookup_role_id { get; set; }
    }
    public class LoginModel
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
