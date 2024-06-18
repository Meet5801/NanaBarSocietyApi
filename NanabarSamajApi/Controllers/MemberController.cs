using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NanabarSamaj.API.ViewModels;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Service.Interfaces;
using Org.BouncyCastle.Bcpg;
using System.ComponentModel.DataAnnotations;

namespace NanabarSamajApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private ResponseData responseData = new ResponseData();
        private readonly IMemberService _memberService;
        private readonly ILogger<MemberController> _logger;

        public MemberController(IMemberService memberService, ILogger<MemberController> logger)
        {
            _memberService = memberService;
            _logger = logger;
        }

        [Route("GetAll")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<List<GetMemberViewModel>>> GetAll(GetMemberRequestViewModel getMemberRequestViewModel)
        {
            try
            {
                //if(!User.Identity.IsAuthenticated)
                //{
                //    return BadRequest("You are not authenticated !! ");
                //}

                //var uid = User.Identity.Name;
                //if(uid == null)
                //{
                //    return BadRequest("Your Token is not generated so that's why you don't have userId my brother !!");
                //}
                //Guid userId = Guid.Parse(uid);

                //getMemberRequestViewModel.user_id = userId;

                //_logger.LogInformation($"User ID: {userId}");

                var data = await _memberService.GetAll(getMemberRequestViewModel);
                if (data.Count == 0)
                {
                    responseData.message = " Data is not found according your requirements !!!";
                }
                else
                {
                    responseData.message = " All Members are loaded !!!";
                }
                responseData.success = true;
                responseData.data = data;
                responseData.code = 200;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");

                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }

        [Route("GetByID")]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<GetMemberViewModel>> GetMemberByID(Guid id)
        {
            try
            {
                var data = await _memberService.GetById(id);
                responseData.success = true;
                responseData.message = " Members By Id !!!";
                responseData.data = data;
                responseData.code = 200;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("Add")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add(MemberViewModel memberViewModel)
        {
            try
            {
                var data = await _memberService.Add(memberViewModel);
                responseData.success = true;
                responseData.message = " Members Added Successfully !!!";
                responseData.data = data;
                responseData.code = 200;
                return Ok(responseData);
            }
            catch (ValidationException vex)
            {
                responseData.message = vex.Message;
                return BadRequest(responseData); // Return a BadRequest response with the validation error message
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("Update")]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(MemberViewModel memberViewModel)
        {
            try
            {
                var data = await _memberService.Update(memberViewModel);
                responseData.success = true;
                responseData.message = " Members Updated Successfully !!!";
                responseData.data = data;
                responseData.code = 200;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("Delete")]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var isMemberdeleted = await _memberService.Delete(id);
                if (isMemberdeleted  == true)
                {
                    responseData.success = true;
                    responseData.message = " Members Deleted Successfully !!!";
                }
                else
                {
                    responseData.success = false;
                    responseData.message = " Members is not found !!!";
                }
                responseData.data = isMemberdeleted;
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