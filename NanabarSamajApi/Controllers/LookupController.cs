using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NanabarSamaj.API.ViewModels;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Service;
using NanabarSamaj.Service.Interfaces;
using System.Linq.Expressions;

namespace NanabarSamajApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private ResponseData responseData = new ResponseData();
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }
        #region Lookup
        [Route("GetCountries")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetCountries()
        {
            try
            {
                var eventTypes = await _lookupService.GetCountries();
                responseData.success = true;
                responseData.message = "get all countries successfully";
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
        [Route("GetCities")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetCities()
        {
            try
            {
                var eventTypes = await _lookupService.GetCities();
                responseData.success = true;
                responseData.message = "Get all cities successfully";
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
        [Route("GetState")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetState()
        {
            try
            {
                var eventTypes = await _lookupService.GetState();
                responseData.success = true;
                responseData.message = "Get all state successfully";
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
        [Route("GetSakh")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetSakh()
        {
            try
            {
                var eventTypes = await _lookupService.GetSakh();
                responseData.success = true;
                responseData.message = "Get all sakh successfully";
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

        [Route("GetVillage")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetVillage()
        {
            try
            {
                var eventTypes = await _lookupService.GetVillage();
                responseData.success = true;
                responseData.message = "Get all village succesfully";
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

        [Route("GetBesnu")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetBesnu()
        {
            try
            {
                var eventTypes = await _lookupService.GetBesnu();
                responseData.success = true;
                responseData.message = "Get Details succesfully";
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

        [Route("GetBloodGroup")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetBloodGroup()
        {
            try
            {
                var eventTypes = await _lookupService.GetBloodGroup();
                responseData.success = true;
                responseData.message = "Get Details succesfully";
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

        [Route("GetBusinesses")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetBusinesses()
        {
            try
            {
                var eventTypes = await _lookupService.GetBusinesses();
                responseData.success = true;
                responseData.message = "Get Businesses Details succesfully";
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

        [Route("GetEducationTypes")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetEducationTypes()
        {
            try
            {
                var eventTypes = await _lookupService.GetEducationTypes();
                responseData.success = true;
                responseData.message = "Get EducationTypes Details succesfully";
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

        [Route("GetEducationSubTypes")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetEducationSubTypes()
        {
            try
            {
                var eventTypes = await _lookupService.GetEducationSubTypes();
                responseData.success = true;
                responseData.message = "Get EducationTypes Details succesfully";
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

        [Route("GetMaritalTypes")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetMaritalTypes()
        {
            try
            {
                var eventTypes = await _lookupService.GetMaritalTypes();
                responseData.success = true;
                responseData.message = "Get MaritalTypes Details succesfully";
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

        [Route("GetNews")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetNews()
        {
            try
            {
                var eventTypes = await _lookupService.GetNews();
                responseData.success = true;
                responseData.message = "Get News Details succesfully";
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

        [Route("GetOccupations")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetOccupations()
        {
            try
            {
                var eventTypes = await _lookupService.GetOccupations();
                responseData.success = true;
                responseData.message = "Get Occupations Details succesfully";
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

        [Route("GetPositions")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetPositions()
        {
            try
            {
                var eventTypes = await _lookupService.GetPositions();
                responseData.success = true;
                responseData.message = "Get Positions Details succesfully";
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

        [Route("GetPragatimandals")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetPragatimandals()
        {
            try
            {
                var eventTypes = await _lookupService.GetPragatimandals();
                responseData.success = true;
                responseData.message = "Get Pragatimandals Details succesfully";
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

        [Route("GetRelationTypes")]
        [HttpGet]
        public async Task<ActionResult<ResponseData>> GetRelationTypes()
        {
            try
            {
                var eventTypes = await _lookupService.GetRelationTypes();
                responseData.success = true;
                responseData.message = "Get RelationTypes Details succesfully";
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
        #endregion
        #region LookupSoftDelete
        [Route("DeleteSakh")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteSakh(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteSakh(id);
                responseData.success = true;
                responseData.message = "Delete Sakh succesfully";
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

        [Route("DeleteVillage")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteVillage(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteVillage(id);
                responseData.success = true;
                responseData.message = "Delete Village succesfully";
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

        

        [Route("DeleteBloodGroup")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteBloodGroup(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteBloodgroup(id);
                responseData.success = true;
                responseData.message = "Delete BloodGroup succesfully";
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

        [Route("DeleteBusinessCategoty")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteBusinessCategory(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteBusinessCategory(id);
                responseData.success = true;
                responseData.message = "Delete Businesscategory succesfully";
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

        [Route("DeleteEducationType")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteEducationType(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteEducationType(id);
                responseData.success = true;
                responseData.message = "Delete EducationType succesfully";
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

        [Route("DeleteEducationSubType")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteEducationSubType(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteEducationSubType(id);
                responseData.success = true;
                responseData.message = "Delete EducationSubType succesfully";
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

        [Route("DeleteMaritalType")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteMaritalType(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteMaritalType(id);
                responseData.success = true;
                responseData.message = "Delete MaritalType succesfully";
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

       

        [Route("DeleteOccupation")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteOccupation(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteOccupation(id);
                responseData.success = true;
                responseData.message = "Delete Occupation succesfully";
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

        [Route("DeletePosition")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeletePosition(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeletePosition(id);
                responseData.success = true;
                responseData.message = "Delete position succesfully";
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

        [Route("DeletePragatimandal")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeletePragatimandal(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeletePragatimandal(id);
                responseData.success = true;
                responseData.message = "Delete Pragatimandal succesfully";
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

        [Route("DeleteRelationtype")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteRelationtype(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteRelationtype(id);
                responseData.success = true;
                responseData.message = "Delete Relationtype succesfully";
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
        
        [Route("DeleteRole")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteRole(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteRole(id);
                responseData.success = true;
                responseData.message = "Delete Role succesfully";
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
        #endregion
        #region City
        [Route("AddCity")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseData>> Add(lookup_CityViewModel lookup_CityViewModel)
        {
            try
            {
                var isAdded = await _lookupService.Add(lookup_CityViewModel);
                if (isAdded)
                {
                    responseData.success = true;
                    responseData.message = "City added successfully";
                    responseData.data = isAdded;
                    responseData.code = 200;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "something went wrong to add the city !!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("UpdateCity")]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ResponseData>> Update(lookup_CityViewModel lookup_CityViewModel)
        {
            try
            {
                var isUpdateCity = await _lookupService.Update(lookup_CityViewModel);
                if (isUpdateCity)
                {
                    responseData.success = true;
                    responseData.message = "City updated successfully";
                    responseData.data = isUpdateCity;
                    responseData.code = 200;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "City not found!!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("DeleteCity")]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ResponseData>> DeleteCity(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteCity(id);
                if (eventTypes == false)
                {
                    responseData.message = "City not found !!!";
                }
                else
                {
                    responseData.message = "City is deleted successfully !!!";
                }
                responseData.code = 200;
                responseData.success = true;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        #endregion

        #region Country
        [Route("AddCountry")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ResponseData>> Add(lookup_CountryViewModel country)
        {
            try
            {
                var isAddCountry = await _lookupService.Add(country);
                if (isAddCountry)
                {
                    responseData.success = true;
                    responseData.message = "Country added successfully";
                    responseData.data = isAddCountry;
                    responseData.code = 200;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "Something went wrong to add the country !!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("UpdateCountry")]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ResponseData>> Update(lookup_CountryViewModel country)
        {
            try
            {
                var isUpdateCountry = await _lookupService.Update(country);
                if (isUpdateCountry)
                {
                    responseData.success = true;
                    responseData.message = "Country updated successfully";
                    responseData.data = isUpdateCountry;
                    responseData.code = 200;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "Country not fount!!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("DeleteCountry")]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ResponseData>> DeleteCountry(Guid id)
        {
            try
            {
                var isDeleteCountry = await _lookupService.DeleteCountry(id);
                if (isDeleteCountry == false)
                {
                    responseData.message = "Country not found !!!";
                }
                else
                {
                    responseData.message = "Country is deleted successfully !!!";
                }
                responseData.code = 200;
                responseData.success = true;
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        #endregion

        #region State
        [Route("AddState")]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Add(lookup_StateViewModel lookup_StateViewModel)
        {
            try
            {
                var isAddState = await _lookupService.Add(lookup_StateViewModel);
                if (isAddState)
                {
                    responseData.success = true;
                    responseData.message = "State added successfully";
                    responseData.data = isAddState;
                    responseData.code = 200;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "Something went wrong to add the state !!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("UpdateState")]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(lookup_StateViewModel lookup_StateViewModel)
        {
            try
            {
                var isUpdatedState = await _lookupService.Update(lookup_StateViewModel);
                if (isUpdatedState)
                {
                    responseData.success = true;
                    responseData.message = "Update State successfully";
                    responseData.data = isUpdatedState;
                    responseData.code = 200;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "State not fount!!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }
        [Route("DeleteState")]
        [HttpDelete]
        [Authorize]
        public async Task<ActionResult<ResponseData>> DeleteState(Guid id)
        {
            try
            {
                var isDeletedState = await _lookupService.DeleteState(id);
                if (isDeletedState)
                {
                    responseData.success = true;
                    responseData.message = "State Deleted successfully";
                    responseData.data = isDeletedState;
                    responseData.code = 200;
                }
                else
                {
                    responseData.success = false;
                    responseData.message = "State not fount!!";
                }
                return Ok(responseData);
            }
            catch (Exception ex)
            {
                responseData.message = ex.Message;
                return Ok(responseData);
            }
        }

        #endregion
        #region Besnu
        [Route("AddBesnu")]
        [HttpPost]
        public async Task<ActionResult> AddBesnu(BesnuViewModel model)
        {
            try
            {
                var eventTypes = await _lookupService.AddBesnu(model);
                responseData.success = true;
                responseData.message = "Besnu Add successfully !!!";
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

        [Route("UpdateBesnu")]
        [HttpPut]
        public async Task<ActionResult> UpdateBesnu(BesnuViewModel model)
        {
            try
            {
                var eventTypes = await _lookupService.UpdateBesnu(model);
                responseData.success = true;
                responseData.message = "Besnu updated successfully !!!";
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
        [Route("DeleteBesnu")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteBesnu(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteBesnu(id);
                responseData.success = true;
                responseData.message = "Delete Besnu succesfully";
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
        #endregion
        #region News
        [Route("AddNews")]
        [HttpPost]
        public async Task<ActionResult> AddNews(NewsViewModel model)
        {
            try
            {
                var eventTypes = await _lookupService.AddNews(model);
                responseData.success = true;
                responseData.message = "News Add successfully !!!";
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

        [Route("UpdateNews")]
        [HttpPut]
        public async Task<ActionResult> UpdateNews(NewsViewModel model)
        {
            try
            {
                var eventTypes = await _lookupService.UpdateNews(model);
                responseData.success = true;
                responseData.message = "News updated successfully !!!";
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
        [Route("DeleteNews")]
        [HttpDelete]
        public async Task<ActionResult<ResponseData>> DeleteNews(Guid id)
        {
            try
            {
                var eventTypes = await _lookupService.DeleteNews(id);
                responseData.success = true;
                responseData.message = "Delete News succesfully";
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
        #endregion
    }
}
