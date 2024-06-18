using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NanabarSamaj.API.ViewModels;
using NanabarSamaj.Common.OtpService;
using NanabarSamaj.Data.Helpers;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace NanabarSamajApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ResponseData responseData = new ResponseData();
        private readonly IUserService _userService;
        private readonly IOtpService _otpService;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;


        public AuthController(IUserService userService, IOtpService otpService, IConfiguration configuration, IWebHostEnvironment env)
        {
            _userService = userService;
            _otpService = otpService;
            _configuration = configuration;
            _env = env;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ResponseData>> Register(UsersViewModel model)
        {
            try
            {
                var usereWithEmail = await _userService.GetUserByPhoneEmail(model.email, model.mobile_number);
                if (usereWithEmail != null)
                {
                    responseData.message = "user already exist with email!!";
                    return new JsonResult(responseData);
                }
                var userVM = await _userService.Register(model);
                if (userVM != null)
                {
                    responseData.code = (int)ResponseCodes.SUCCESS;
                    responseData.data = userVM;
                    responseData.message = "Register user successfully";
                    responseData.success = true;
                }
                else
                {
                    responseData.message = "problem while registering user!!";
                }
                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = "invalid data enetred" + ex.Message;
                return new JsonResult(responseData);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ResponseData>> Login(LoginViewModel model)
        {
            try
            {
                var userLP = await _userService.Login(model);
                if (userLP != null)
                {
                    userLP.token = GenerateAuthToken(userLP);
                    responseData.success = true;
                    responseData.message = "login successfully";
                    responseData.data = userLP;
                    responseData.code = (int)ResponseCodes.SUCCESS;
                }
                else
                {
                    responseData.message = "The provided mobile number does not match any user in our records!";
                    responseData.code = 404;
                }

                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = "invalid data enetred : " + ex.Message;
                return new JsonResult(responseData);
            }
        }

        [AllowAnonymous]
        [Route("OTPVerification")]
        [HttpPost]
        public async Task<ActionResult<ResponseData>> OTPVerification(OTPVerificationRequestViewModel model)
        {
            try
            {
                bool isOTPVerf = await _userService.OTPVerification(model);
                if (isOTPVerf)
                {
                    responseData.success = true;
                    responseData.code = 200;
                    responseData.data = isOTPVerf;
                    responseData.message = "OTP verified successfully";
                }
                else
                {
                    responseData.message = "OTP not valid ";
                }

                return new JsonResult(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = "invalid data enetred" + ex.Message;
                return new JsonResult(responseData);
            }
        }
        [HttpPost("SendOtp")]
        public async Task<ActionResult<ResponseData>> SendOtp(string phoneNumber)
        {
            try
            {
                var verificationResource = await _otpService.SendOTP(phoneNumber);

                if (verificationResource.Status == "pending")
                {
                    return new ResponseData
                    {
                        success = true,
                        code = 200,
                        data = true,
                        message = "OTP sent successfully"
                    };
                }
                else
                {
                    return new ResponseData
                    {
                        success = false,
                        code = 400,
                        data = false,
                        message = "Failed to send OTP"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData
                {
                    success = false,
                    code = 500,
                    data = null,
                    message = "An error occurred: " + ex.Message
                };
            }
        }

        [HttpPost("VerifyOtp")]
        public async Task<ActionResult<ResponseData>> VerifyOtp(string phoneNumber, string otp)
        {
            try
            {
                var verificationCheckResource = await _otpService.VerifiyOTP(phoneNumber, otp);

                if (verificationCheckResource.Status == "approved")
                {
                    return new ResponseData
                    {
                        success = true,
                        code = 200,
                        data = true,
                        message = "OTP verification successful"
                    };
                }
                else
                {
                    return new ResponseData
                    {
                        success = false,
                        code = 400,
                        data = false,
                        message = "OTP verification failed"
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResponseData
                {
                    success = false,
                    code = 500,
                    data = null,
                    message = "An error occurred: " + ex.Message
                };
            }
        }

        [HttpGet("{imageName}")]
        public IActionResult GetImage(string imageName)
        {
            string paths = Path.Combine(_env.ContentRootPath, "Uploads", "Members", imageName);
            if (System.IO.File.Exists(paths))
            {
                var image = System.IO.File.OpenRead(paths);
                return File(image, "image/jpeg");
            }
            else
            {
                string pathsMember = Path.Combine(_env.ContentRootPath, "Uploads", "Users", imageName);
                if (System.IO.File.Exists(pathsMember))
                {
                    var image = System.IO.File.OpenRead(pathsMember);
                    return File(image, "image/jpeg");
                }
                else
                {
                    string pathsBesnu = Path.Combine(_env.ContentRootPath, "Uploads", "Besnu", imageName);
                    if (System.IO.File.Exists(pathsBesnu))
                    {
                        var image = System.IO.File.OpenRead(pathsBesnu);
                        return File(image, "image/jpeg");
                    }
                    else
                    {
                        string pathsNews = Path.Combine(_env.ContentRootPath, "Uploads", "News", imageName);
                        if (System.IO.File.Exists(pathsNews))
                        {
                            var image = System.IO.File.OpenRead(pathsNews);
                            return File(image, "image/jpeg");
                        }
                        else
                        {
                            string pathsCountries = Path.Combine(_env.ContentRootPath, "Uploads", "Countries", imageName);
                            if (System.IO.File.Exists(pathsCountries))
                            {
                                var image = System.IO.File.OpenRead(pathsCountries);
                                return File(image, "image/jpeg");
                            }
                            else
                            {
                                string pathsBusinesses = Path.Combine(_env.ContentRootPath, "Uploads", "Businesses", imageName);
                                if (System.IO.File.Exists(pathsBusinesses))
                                {
                                    var image = System.IO.File.OpenRead(pathsBusinesses);
                                    return File(image, "image/jpeg");
                                }
                                else
                                {
                                    return NotFound("Image not found");
                                }
                            }
                        }
                    }
                }
            }
        }

        #region private methods
        private string GenerateAuthToken(LoginResponseModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["ApplicationSettings:TokenSecret"].ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                     new Claim(ClaimTypes.Name, user.id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Audience = _configuration["ApplicationSettings:Audience"],
                Issuer = _configuration["ApplicationSettings:Issuer"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion

    }
}

