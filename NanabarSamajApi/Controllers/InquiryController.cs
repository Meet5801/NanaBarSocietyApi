using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class InquiryController : ControllerBase
    {
        private ResponseData responseData = new ResponseData();
        private readonly IInquiryService _inquiryService;
        private readonly IConfiguration _configuration;

        public InquiryController(IInquiryService inquiryService, IConfiguration configuration)
        {
            _inquiryService = inquiryService;
            _configuration = configuration;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetAll()
        {
            try
            {
                var eventTypes = await _inquiryService.GetAll();
                responseData.success = true;
                responseData.message = "Get All Inquiries succesfully";
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

        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Add(InquiryViewModel model)
        {
            try
            {
                var eventTypes = await _inquiryService.Add(model);
                responseData.success = true;
                responseData.message = "Add Inquiry succesfully";
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

        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ResponseData>> Update(Inquiry entity)
        {
            try
            {
                var eventTypes = await _inquiryService.Update(entity);
                responseData.success = true;
                responseData.message = "Update Inquiry succesfully";
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

        [Route("Delete")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> Delete(Guid id)
        {
            try
            {
                var eventTypes = await _inquiryService.Delete(id);
                responseData.success = true;
                responseData.message = "Delete Inquiry succesfully";
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
                var eventTypes = await _inquiryService.GetById(id);
                responseData.success = true;
                responseData.message = "Get Inquiry successfully";
                responseData.data = eventTypes;
                responseData.code = 200;
                if(responseData.data == null)
                {
                    responseData.message = "User Is not Active";
                }
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
