using System.ComponentModel.DataAnnotations;

namespace NanabarSamaj.Data.ViewModels
{
    public class UsersViewModel
    {
        public Guid id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string? name { get; set; }
        [Required(ErrorMessage = "Please enter Father Name")]
        public string? father_name { get; set; }
        [Required(ErrorMessage = "Please enter SurName")]
        public string? surname { get; set; }
        [Required(ErrorMessage = "Please enter a phone number")]
        [RegularExpression(@"^\+[1-9]\d{1,3}\d{10}$", ErrorMessage = "Please enter a valid phone number in the format '+[country code][phone number]'")]
        public string? mobile_number { get; set; }
        [Required(ErrorMessage = "Please enter EmailAddress")]
        [EmailAddress(ErrorMessage ="Enter Valid EmailAddress")]
        public string? email { get; set; }
        [Required(ErrorMessage = "Please enter Gender")]
        public string? gender { get; set; }
        [Required(ErrorMessage ="Please Enter address")]
        public string? address { get; set; }
        public Guid lookup_city_id { get; set; }
        public Guid lookup_state_id { get; set; }
        public Guid lookup_country_id { get; set; }
        [Required(ErrorMessage = "Please enter Pincode")]
        public string? pincode { get; set; }
        public Guid lookup_sakh_id { get; set; }
        
        [Required(ErrorMessage = "Please enter password")]
        [MinLength(6, ErrorMessage = "Password must be 6 character long")]
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
        public string? token { get; set; }
    }
    public class GetAllUsersViewModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string father_name { get; set; }
        public string surname { get; set; }
        public string mobile_number { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        
        public string city_name { get; set; }
        public Guid lookup_city_id { get; set; }
        
        public string state_name { get; set; }
        public Guid lookup_state_id { get; set; }
      
        public string country_name { get; set; }
        public Guid lookup_country_id { get; set; }
        public string pincode { get; set; }
      
        public string sakh_name { get; set; }
        public Guid lookup_sakh_id { get; set; }
        public string password { get; set; }
        public bool is_terms { get; set; }
        public string image { get; set; }
        public bool is_active { get; set; }
        public bool is_verify { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
        
        public string role_name { get; set; }
        public Guid? lookup_role_id { get; set; }
    }

    public class UserResponse
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string father_name { get; set; }
        public string surname { get; set; }
        public string mobile_number { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string address { get; set; }

        public string city_name { get; set; }
        public Guid? lookup_city_id { get; set; }

        public string state_name { get; set; }
        public Guid? lookup_state_id { get; set; }

        public string country_name { get; set; }
        public Guid? lookup_country_id { get; set; }
        public string pincode { get; set; }

        public string sakh_name { get; set; }
        public Guid lookup_sakh_id { get; set; }
        public string password { get; set; }
        public bool is_terms { get; set; }
        public string image { get; set; }
        public bool is_active { get; set; }
        public bool is_verify { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }

        public string role_name { get; set; }
        public Guid? lookup_role_id { get; set; }
    }

    public class UsersUpdateViewModel
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

        // added here 
        public DateTime? dob { get; set; }
        public Guid lookup_marital_id { get; set; }
        public string? religion { get; set; }
        public string? mother_tongue { get; set; }
        public string? community { get; set; }
        public string? diet_preferences { get; set; }
        public double? annual_income { get; set; }
        public string? collage_name { get; set; }
        public List<string>? hobbies { get; set; }   // to here

        public bool is_active { get; set; }
        public bool is_verify { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
        public Guid? lookup_role_id { get; set; }
        public string? token { get; set; }
    }
}
