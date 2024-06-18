using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository;

namespace NanabarSamaj.Service.Interfaces
{
    public interface IUserService
    {
        Task<RegistrationResponse> Register(UsersViewModel model);
        Task<Users> GetUserByPhoneEmail(string email, string mobile_number);
        Task<LoginResponseModel> Login(LoginViewModel model);
        Task<bool> OTPVerification(OTPVerificationRequestViewModel otpReq);
        Task<bool> Update(UsersUpdateViewModel entity);
        Task<UserResponse> GetById(Guid id);
        Task<List<UserResponse>> GetAll();
        Task<LoginResponseModel> AdminLogin(AdminLoginViewModel loginViewModel);
        Task<bool> Delete(Guid id);
    }
}