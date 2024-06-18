using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NanabarSamaj.Data.ViewModels
{
    public class AuthViewModel
    {
        [JsonIgnore]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string username { get; set; }

        [Required(ErrorMessage = "Please enter father name")]
        public string father_name { get; set; }

        [Required(ErrorMessage = "Please enter surname")]
        public string surname { get; set; }

        [Required(ErrorMessage = "Please enter a phone number")]
        [RegularExpression(@"^\+[1-9]\d{1,3}\d{10}$", ErrorMessage = "Please enter a valid phone number in the format '+[country code][phone number]'")]
        public string mobile_number { get; set; }

        [Required(ErrorMessage = "Please enter an email")]
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        public string email { get; set; }

        [Required(ErrorMessage = "Please enter gender")]
        public string gender { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string address { get; set; }

        [Required(ErrorMessage = "Please enter city")]
        public string? city { get; set; }
        [Required(ErrorMessage = "Please enter state")]
        public string? state { get; set; }
        [Required(ErrorMessage = "Please enter country")]
        public string? country { get; set; }

        [Required(ErrorMessage = "Please enter pincode")]
        public string? pincode { get; set; }

        public string? sakh_name { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [MinLength(6, ErrorMessage = "Password must be 6 character long")]
        public string password { get; set; }

        public string? image { get; set; }
        public bool is_terms { get; set; }
        public bool is_active { get; set; }
        public bool is_verify { get; set; }
        public Guid? created_by_id { get; set; } = Guid.NewGuid();
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; } = Guid.Empty;
        public DateTime? updated_on { get; set; }  = DateTime.MinValue;
    }
    public class LoginViewModel
    {
        public string mobile_number { get; set; }
        //public string? password { get; set; }
    }
    public class AdminLoginViewModel
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class LoginResponseModel
    {
        public Guid? id { get; set; }
        public string? type { get; set; }
        //public string? first_name { get; set; }
        //public string? last_name { get; set; }

        public string? username { get; set; }
        public string? email { get; set; }
        public string? role { get; set; }
        public Guid? school_id { get; set; }
        public string? token { get; set; }
        public string? mobile_number { get; set; }
        public Guid? role_id { get; set; }
    }
    public class RegistrationResponse
    {
        public Guid id { get; set; }
        public string username { get; set; }
        public string father_name { get; set; }
        public string surname { get; set; }
        public string mobile_number{ get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public Guid lookup_city_id{ get; set; }
        public Guid lookup_state_id { get; set; }
        public Guid lookup_country_id { get; set; }
        public string pincode { get; set; }
        public Guid lookup_sakh_id{ get; set; }
        public bool is_terms { get; set; }
        public string image { get; set; }
        public bool is_active { get; set; }
        public bool is_verify { get; set; }
        public Guid? created_by_id { get; set; }
        public Guid? lookup_role_id { get; set; }
    }
    public class OTPVerificationRequestViewModel
    {
        public string phone_number { get; set; }
        public string otp { get; set; }

    }
    public class OtpServiceModelViewModel
    {
        public string phone_number { get; set; }
    }
}
