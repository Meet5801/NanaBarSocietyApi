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
    public class BusinessController : ControllerBase
    {
        private ResponseData responseData = new ResponseData();
        private readonly IBusinessService _businessService;
        private readonly IConfiguration _configuration;

        public BusinessController(IBusinessService businessservice, IConfiguration configuration)
        {
            _businessService = businessservice;
            _configuration = configuration;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Add(BusinessViewModel model)
        {
            try
            {
                var eventTypes = await _businessService.Add(model);
                responseData.success = true;
                responseData.message = "Add Business succesfully";
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
        public async Task<ActionResult<ResponseData>> Update(Business entity)
        {
            try
            {
                var eventTypes = await _businessService.Update(entity);
                responseData.success = true;
                responseData.message = "Update Business succesfully";
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
        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetAll()
        {
            try
            {
                var eventTypes = await _businessService.GetAll();
                responseData.success = true;
                responseData.message = "GetAll Business succesfully";
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
                var eventTypes = await _businessService.GetById(id);
                responseData.success = true;
                responseData.message = "Get Business succesfully";
                responseData.data = eventTypes;
                responseData.code = 200;
                if(responseData.data == null)
                {
                    responseData.data = "user is Now not active";
                }
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
                var eventTypes = await _businessService.Delete(id);
                responseData.success = true;
                responseData.message = "Delete Business succesfully";
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
    }
}
