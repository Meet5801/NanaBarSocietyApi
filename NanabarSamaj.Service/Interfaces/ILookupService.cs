using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Service.Interfaces
{
    public interface ILookupService
    {
        Task<IEnumerable<Lookup_Country>> GetCountries();
        Task<IEnumerable<Lookup_City>> GetCities();
        Task<IEnumerable<Lookup_State>> GetState();
        Task<IEnumerable<Lookup_Sakh>> GetSakh();
        Task<IEnumerable<Lookup_Village>> GetVillage();
        Task<IEnumerable<Lookup_Besnu>> GetBesnu();
        Task<IEnumerable<Lookup_Blood_Group>> GetBloodGroup();
        Task<IEnumerable<Lookup_Business_Category>> GetBusinesses();
        Task<IEnumerable<Lookup_Education_Type>> GetEducationTypes();
        Task<IEnumerable<Lookup_Education_Sub_Type>> GetEducationSubTypes();
        Task<IEnumerable<Lookup_Marital_Type>> GetMaritalTypes();
        Task<IEnumerable<Lookup_News>> GetNews();
        Task<IEnumerable<Lookup_Occupation>> GetOccupations();
        Task<IEnumerable<Lookup_Position>> GetPositions();
        Task<IEnumerable<Lookup_Pragatimandal>> GetPragatimandals();
        Task<IEnumerable<Lookup_Relation_Type>> GetRelationTypes();

        #region Lookup_delete
        Task<bool> DeleteSakh(Guid id);
        Task<bool> DeleteVillage(Guid id);
        Task<bool> DeleteBloodgroup(Guid id);
        Task<bool> DeleteBusinessCategory(Guid id);
        Task<bool> DeleteEducationType(Guid id);
        Task<bool> DeleteEducationSubType(Guid id);
        Task<bool> DeleteMaritalType(Guid id);
        Task<bool> DeleteOccupation(Guid id);
        Task<bool> DeletePosition(Guid id);
        Task<bool> DeletePragatimandal(Guid id);
        Task<bool> DeleteRelationtype(Guid id);
        Task<bool> DeleteRole(Guid id);
        #endregion
        #region Besnu
        Task<Lookup_Besnu> AddBesnu(BesnuViewModel model);
        Task<Lookup_Besnu> UpdateBesnu(BesnuViewModel entity);
        Task<bool> DeleteBesnu(Guid id);

        #endregion
        #region City
        Task<bool> Add(lookup_CityViewModel lookup_CityViewModel);
        Task<bool> Update(lookup_CityViewModel lookup_CityViewModel);
        Task<bool> DeleteCity(Guid id);
        #endregion
        #region Country
        Task<bool> Add(lookup_CountryViewModel country);
        Task<bool> Update(lookup_CountryViewModel country);
        Task<bool> DeleteCountry(Guid id);
        #endregion
        #region State
        Task<bool> Add(lookup_StateViewModel state);
        Task<bool> Update(lookup_StateViewModel state);
        Task<bool> DeleteState(Guid id);
        #endregion
        #region News
        Task<Lookup_News> AddNews(NewsViewModel model);
        Task<Lookup_News> UpdateNews(NewsViewModel model);
        Task<bool> DeleteNews(Guid id);
        #endregion
    }
}
