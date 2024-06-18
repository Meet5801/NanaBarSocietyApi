using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NanabarSamaj.API.ViewModels;
using NanabarSamaj.Data.Helpers;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NanabarSamajApi.Controllers.Admin
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private ResponseData responseData = new ResponseData();
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ResponseData>> Login(AdminLoginViewModel model)
        {
            try
            {
                var userLP = await _userService.AdminLogin(model);
                if (userLP != null)
                {
                    userLP.token = GenerateAuthToken(userLP);
                    responseData.success = true;
                    responseData.message = "Admin login successfully";
                    responseData.data = userLP;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "You are not Admin";
                }
                responseData.code = (int)ResponseCodes.SUCCESS;
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = "invalid data enetred : " + ex.Message;
                return new JsonResult(responseData);
            }
        }

        #region private methods
        private string GenerateAuthToken(LoginResponseModel user)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["ApplicationSettings:TokenSecret"].ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}
