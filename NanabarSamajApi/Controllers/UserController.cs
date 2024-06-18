using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NanabarSamaj.API.ViewModels;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Service;
using NanabarSamaj.Service.Interfaces;

namespace NanabarSamajApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ResponseData responseData = new ResponseData();
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetAll()
        {
            try
            {
                var eventTypes = await _userService.GetAll();
                responseData.success = true;
                responseData.message = "Get All Users succesfully";
                responseData.data = eventTypes;
                responseData.code = 200;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetById(Guid id)
        {
            try
            {
                var eventTypes = await _userService.GetById(id);
                responseData.success = true;
                responseData.message = "Get User succesfully";
                responseData.data = eventTypes;
                responseData.code = 200;
                if (responseData.data == null)
                {
                    responseData.code = 404;
                    responseData.message = "User Not Found!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }

        [Authorize]
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ResponseData>> Update(UsersUpdateViewModel entity)
        {
            try
            {
                var eventTypes = await _userService.Update(entity);
                if (eventTypes)
                {
                    responseData.success = true;
                    responseData.message = "User Update Successfully";
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "User not updatd Successfully !! ";
                }
                responseData.data = eventTypes;
                responseData.code = 200;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Authorize]
        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> Delete(Guid id)
        {
            try
            {
                var isUserdeleted = await _userService.Delete(id);
                if (isUserdeleted == true)
                {
                    responseData.success = true;
                    responseData.message = " User Deleted Successfully !!!";
                }
                else
                {
                    responseData.success = false;
                    responseData.message = " User is not found !!!";
                }
                responseData.data = isUserdeleted;
                responseData.code = 200;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }

    }
}

