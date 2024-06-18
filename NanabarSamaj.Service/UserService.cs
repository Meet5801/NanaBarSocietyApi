using AutoMapper;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NanabarSamaj.API.Common;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.Helpers;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository;
using NanabarSamaj.Repository.Interfaces;
using NanabarSamaj.Service.Interfaces;
using System.Net;
using System.Reflection;

using System.Security.Claims;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using static Dapper.SqlMapper;

namespace NanabarSamaj.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;

        public UserService(IUserRepository userRepository, IConfiguration configuration, IHostingEnvironment env)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _env = env;
        }

        public async Task<Users> GetUserByPhoneEmail(string email, string mobile_number)
        {
            return await _userRepository.GetByEmailPhone(email, mobile_number);
        }

        public async Task<LoginResponseModel> Login(LoginViewModel model)
        {
            var user = await _userRepository.GetByPhone(model.mobile_number);

            if (user != null)
            {
                //if (!Bcrypt.CheckPassword(model.password, user.password))
                //{
                //    return null;
                //}
                user.password = string.Empty;
            }
            else
            {
                return null;
            }
            return new LoginResponseModel
            {
                id = user.id,
                username = user.name,
                email = user.email,
                mobile_number = user.mobile_number
            };
        }



        public async Task<RegistrationResponse> Register(UsersViewModel model)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(model.image))
            {
                fileName = ConvertImageSave(model.image);
            }

            Users user = new Users
            {
                id = Guid.NewGuid(),
                name = model.name,
                father_name = model.father_name,
                surname = model.surname,
                mobile_number = model.mobile_number,
                email = model.email,
                gender = model.gender,
                address = model.address,
                lookup_city_id = model.lookup_city_id,
                lookup_state_id = model.lookup_state_id,
                lookup_country_id = model.lookup_country_id,
                pincode = model.pincode,
                lookup_sakh_id = model.lookup_sakh_id,
                password = Bcrypt.HashPassword(model.password, Bcrypt.GenerateSalt()),
                is_terms = model.is_terms,
                image = fileName,
                is_active = model.is_active,
                is_verify = model.is_verify,
                created_by_id = Guid.NewGuid(),
                lookup_role_id = new Guid("ee39a387-a982-4e89-8178-4a8fc57402f3")
            };

            await _userRepository.Add(user);

            RegistrationResponse response = new RegistrationResponse
            {
                id = user.id,
                username = user.name,
                father_name = user.father_name,
                surname = user.surname,
                mobile_number = user.mobile_number,
                email = user.email,
                gender = user.gender,
                address = user.address,
                lookup_city_id = user.lookup_city_id,
                lookup_state_id = user.lookup_state_id,
                lookup_country_id = user.lookup_country_id,
                pincode = user.pincode,
                lookup_sakh_id = user.lookup_sakh_id,
                is_terms = user.is_terms,
                image = user.image,
                is_active = user.is_active,
                is_verify = user.is_verify,
                created_by_id = user.created_by_id,
                lookup_role_id = user.lookup_role_id
            };

            return response;
        }


        public async Task<bool> OTPVerification(OTPVerificationRequestViewModel otpReq)
        {
            try
            {
                if (otpReq.otp == "1234")
                {
                    var user = await _userRepository.GetByPhone(otpReq.phone_number);
                    if (user != null)
                    {
                        return true;
                    }
                    return false;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(UsersUpdateViewModel entity)
        {
            string hashedPassword = Bcrypt.HashPassword(entity.password, Bcrypt.GenerateSalt());
            entity.password = hashedPassword;
            string fileName = string.Empty;
            {
                fileName = ConvertImageSave(entity.image);
            }
            var isUpdateUser = await _userRepository.UpdateUser(entity);
            if (isUpdateUser != null)
            {
                return true;
            }
            return false;
        }

        public async Task<UserResponse> GetById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            if (user == null)
            {
                return null;
            }

            return MapToUserResponse(user);
        }

        public async Task<List<UserResponse>> GetAll()
        {
            var users = await _userRepository.GetAll();
            return users.Select(MapToUserResponse).ToList();
        }


        public async Task<LoginResponseModel> AdminLogin(AdminLoginViewModel model)
        {
            var user = await _userRepository.AdminGetByEmail(model.email);
            if (user == null)
            {
                return null;
            }
            var rolses = user.lookup_role_id.Value;
            string role = await _userRepository.AdminGetById(user.lookup_role_id.Value);
            if (!string.IsNullOrEmpty(model.password) && role == "Admin")
            {
                if (!Bcrypt.CheckPassword(model.password, user.password))
                {
                    return null;
                }
                user.password = string.Empty;
            }
            else
            {
                return null;
            }
            return new LoginResponseModel
            {
                email = user.email,
            };
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        #region UserResponse
        private UserResponse MapToUserResponse(GetAllUsersViewModel user)
        {
            return new UserResponse
            {
                id = user.id,
                username = user.name,
                father_name = user.father_name,
                surname = user.surname,
                mobile_number = user.mobile_number,
                email = user.email,
                gender = user.gender,
                address = user.address,
                city_name = user.city_name,
                lookup_city_id = user.lookup_city_id,
                state_name = user.state_name,
                lookup_state_id = user.lookup_state_id,
                country_name = user.country_name,
                lookup_country_id = user.lookup_country_id,
                pincode = user.pincode,
                sakh_name = user.sakh_name,
                lookup_sakh_id = user.lookup_sakh_id,
                password = user.password,
                is_terms = user.is_terms,
                image = user.image,
                is_active = user.is_active,
                is_verify = user.is_verify,
                created_by_id = user.created_by_id,
                created_on = user.created_on,
                updated_by_id = user.updated_by_id,
                updated_on = user.updated_on,
                role_name = user.role_name,
                lookup_role_id = user.lookup_role_id
            };
        }
        #endregion

        #region private
        private string SaveImageFromUrl(string imageUrl, string targetFolderPath)
        {
            byte[] imageData;
            using (var client = new WebClient())
            {
                imageData = client.DownloadData(imageUrl);
            }

            string originalFileName = Path.GetFileName(new Uri(imageUrl).LocalPath);

            string fileName = originalFileName;

            string imagePath = Path.Combine(targetFolderPath, fileName);

            File.WriteAllBytes(imagePath, imageData);

            return fileName;
        }

        private string ConvertImageSave(string imageUrl)
        {
            string targetFolderPath = Path.Combine(_env.ContentRootPath, "Uploads", "Users");

            string fileName = SaveImageFromUrl(imageUrl, targetFolderPath);

            string relativePath = Path.Combine("Uploads", "Users", fileName);

            return relativePath;
        }


        #endregion
    }
}