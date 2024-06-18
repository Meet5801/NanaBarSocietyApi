using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NanabarSamaj.Data.ViewModels
{
    public class MemberViewModel
    {
        public Guid id { get; set; }
        [Required(ErrorMessage ="Please enter RelationType")]
        public Guid lookup_relation_type_id { get; set; }
        [Required(ErrorMessage ="Please enter surname")]
        public string? surname { get; set; }
        [Required(ErrorMessage ="Please enter name")]
        public string? name { get; set; }
        [ValidateFatherOrHusbandName(ErrorMessage = "Father or husband name does not match with user's name or father's name")]
        [Required(ErrorMessage ="Please enter father or husband name")]
        public string? father_or_husband_name { get; set; }
        [Required(ErrorMessage ="Please enter gender")]
        public string? gender { get; set; }
        [Required(ErrorMessage ="Please enter phone number")]
        public string? phone_number { get; set; }
        [Required(ErrorMessage ="Please enter email")]
        public string? email { get; set; }
        [Required(ErrorMessage ="Please enter date of birth")]
        public DateTime dob { get; set; }
        [Required(ErrorMessage ="Please enter age")]
        public int age { get; set; }
        [Required(ErrorMessage ="Please enter village")]
        public Guid lookup_village_id { get; set; }
        [Required(ErrorMessage ="Please enter sakh")]
        public Guid lookup_sakh_id { get; set; }
        [Required(ErrorMessage ="Please enter address")]
        public string? address { get; set; }
        [Required(ErrorMessage ="Please enter city")]
        public Guid lookup_city_id { get; set; }
        [Required(ErrorMessage ="Please enter country")]
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


    public class GetMemberViewModel
    {   
        public Guid id { get; set; }
        public string? relation_type { get; set; }
        public string? surname { get; set; }
        public string? name { get; set; }
        public string? father_or_husband_name { get; set; }
        public string? gender { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public DateTime? dob { get; set; }
        public int? age { get; set; }
        public string? village{ get; set; }
        public string? sakh { get; set; }
        public string? address { get; set; }
        public string? city { get; set; }
        public string? country { get; set; }
        public string? marital_type { get; set; }
        public string? education_type { get; set; }
        public string? education_sub_type{ get; set; }
        public string? occupation { get; set; }
        public string? designation { get; set; }
        public string? company { get; set; }
        public string? occupation_address { get; set; }
        public string? mama_name { get; set; }
        public string? blood_group { get; set; }
        public string? pragatimandal{ get; set; }
        public string? height_foot { get; set; }
        public string? height_inch { get; set; }
        public string? weight { get; set; }
        public string? image { get; set; }
        public bool? interested_matrimonial { get; set; }
        public bool? interested_blood_donate { get; set; }
        public string? about_me { get; set; }
        public bool? is_active { get; set; }
        public Guid? created_by_id { get; set; }
        public DateTime? created_on { get; set; }
        public Guid? updated_by_id { get; set; }
        public DateTime? updated_on { get; set; }
        public bool you_live_abroad { get; set; }
       // public string? user_id { get; set; }
    }
    public class GetMemberRequestViewModel
    {
       // [JsonIgnore]
        public Guid? user_id { get; set; }
        public int? page_number { get; set; }
        public int? page_size { get; set; }
        public int? age { get; set; }
        public string? education { get; set; }
        public string? occupation { get; set; }
        public string? gender { get; set; }
        public bool? you_live_abroad { get; set; }
        public string? marital { get; set; }
        public string? height { get; set; }
        public string? weight { get; set; }
        public bool? interested_matrimonial { get; set; }
    }

    public class ValidateFatherOrHusbandNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var memberViewModel = (MemberViewModel)validationContext.ObjectInstance;
            var fatherOrHusbandName = (string)value;

            if (fatherOrHusbandName != memberViewModel.name && fatherOrHusbandName != memberViewModel.father_or_husband_name)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}