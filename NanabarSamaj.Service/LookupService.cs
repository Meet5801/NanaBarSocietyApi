using AutoMapper.Execution;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository.Interfaces;
using NanabarSamaj.Service.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Dapper.SqlMapper;

namespace NanabarSamaj.Service
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _lookupRepository;
        private readonly IHostingEnvironment _env;

        public LookupService(ILookupRepository lookupRepository, IHostingEnvironment env)
        {
            _lookupRepository = lookupRepository;
            _env = env;
        }
        public async Task<IEnumerable<Lookup_City>> GetCities()
        {
            return await _lookupRepository.GetCities();
        }
        public async Task<IEnumerable<Lookup_Country>> GetCountries()
        {
            return await _lookupRepository.GetCountries();
        }
        public async Task<IEnumerable<Lookup_Sakh>> GetSakh()
        {
            return await _lookupRepository.GetSakh();
        }
        public async Task<IEnumerable<Lookup_State>> GetState()
        {
            return await _lookupRepository.GetState();
        }
        public async Task<IEnumerable<Lookup_Village>> GetVillage()
        {
            return await _lookupRepository.GetVillage();
        }
        public async Task<IEnumerable<Lookup_Besnu>> GetBesnu()
        {
            return await _lookupRepository.GetBesnu();
        }
        public async Task<IEnumerable<Lookup_Blood_Group>> GetBloodGroup()
        {
            return await _lookupRepository.GetBloodGroup();
        }
        public async Task<IEnumerable<Lookup_Business_Category>> GetBusinesses()
        {
            return await _lookupRepository.GetBusinesses();
        }
        public async Task<IEnumerable<Lookup_Education_Type>> GetEducationTypes()
        {
            return await _lookupRepository.GetEducationTypes();
        }
        public async Task<IEnumerable<Lookup_Education_Sub_Type>> GetEducationSubTypes()
        {
            return await _lookupRepository.GetEducationSubTypes();
        }
        public async Task<IEnumerable<Lookup_Marital_Type>> GetMaritalTypes()
        {
            return await _lookupRepository.GetMaritalTypes();
        }
        public async Task<IEnumerable<Lookup_News>> GetNews()
        {
            return await _lookupRepository.GetNews();
        }
        public async Task<IEnumerable<Lookup_Occupation>> GetOccupations()
        {
            return await _lookupRepository.GetOccupations();
        }
        public async Task<IEnumerable<Lookup_Position>> GetPositions()
        {
            return await _lookupRepository.GetPositions();
        }
        public async Task<IEnumerable<Lookup_Pragatimandal>> GetPragatimandals()
        {
            return await _lookupRepository.GetPragatimandals();
        }
        public async Task<IEnumerable<Lookup_Relation_Type>> GetRelationTypes()
        {
            return await _lookupRepository.GetRelationTypes();
        }
        #region Lookup_delete
        public async Task<bool> DeleteSakh(Guid id)
        {
           return await _lookupRepository.DeleteSakh(id);
        }

        public async Task<bool> DeleteVillage(Guid id)
        {
            return await _lookupRepository.DeleteVillage(id);
        }

       

        public async Task<bool> DeleteBloodgroup(Guid id)
        {
            return await _lookupRepository.DeleteBloodgroup(id);
        }

        public async Task<bool> DeleteBusinessCategory(Guid id)
        {
            return await _lookupRepository.DeleteBusinessCategory(id);
        }

        public async Task<bool> DeleteEducationType(Guid id)
        {
            return await _lookupRepository.DeleteEducationType(id);
        }

        public async  Task<bool> DeleteEducationSubType(Guid id)
        {
            return await _lookupRepository.DeleteEducationSubType(id);
        }

        public async Task<bool> DeleteMaritalType(Guid id)
        {
            return await _lookupRepository.DeleteMaritalType(id);
        }

       

        public async Task<bool> DeleteOccupation(Guid id)
        {
            return await _lookupRepository.DeleteOccupation(id);
        }

        public async Task<bool> DeletePosition(Guid id)
        {
            return await _lookupRepository.DeletePosition(id);
        }

        public async  Task<bool> DeletePragatimandal(Guid id)
        {
            return await _lookupRepository.DeletePragatimandal(id);
        }

        public async Task<bool> DeleteRelationtype(Guid id)
        {
            return await _lookupRepository.DeleteRelationtype(id);
        }

        public async Task<bool> DeleteRole(Guid id)
        {
            return await _lookupRepository.DeleteRole(id);
        }
        #endregion
        #region City
        public async Task<bool> Add(lookup_CityViewModel lookup_CityViewModel)
        {
            Lookup_City lookup_City = new Lookup_City
            {
                id = Guid.NewGuid(),
                name = lookup_CityViewModel.name,
                is_active = true,
                lookup_state_id = lookup_CityViewModel.lookup_state_id,
                created_by_id = Guid.NewGuid(),
                created_on = DateTime.Now,
            };
            var data = await _lookupRepository.Add(lookup_City);
            if(data != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCity(Guid id)
        {
            return await _lookupRepository.DeleteCity(id);
        }
        public async Task<bool> Update(lookup_CityViewModel lookup_CityViewModel)
        {
            Lookup_City lookup_City = new Lookup_City
            {
                id = lookup_CityViewModel.id,
                name = lookup_CityViewModel.name,
                is_active = true,
                lookup_state_id = lookup_CityViewModel.lookup_state_id,
                updated_by_id = Guid.NewGuid(),
                updated_on = DateTime.Now,
            };
            var data = await _lookupRepository.Update(lookup_City);
            if (data != null)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Country
        public async Task<bool> Add(lookup_CountryViewModel country)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(country.image))
            {
                fileName = ConvertImageSaveForCountry(country.image);
            }
            Lookup_Country lookup_Country = new Lookup_Country
            {
                id = Guid.NewGuid(),
                name = country.name,
                image = fileName,
                code = country.code,
                is_active = true,
                created_by_id = Guid.NewGuid(),
                created_on = DateTime.Now,
            };
            var data = await _lookupRepository.Add(lookup_Country);
            if(data != null)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteCountry(Guid id)
        {
            return await _lookupRepository.DeleteCountry(id);
        }
        public async Task<bool> Update(lookup_CountryViewModel country)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(country.image))
            {
                fileName = ConvertImageSaveForCountry(country.image);
            }
            Lookup_Country lookup_Country = new Lookup_Country
            {
                id = country.id,
                name = country.name,
                image = fileName,
                is_active = true,
                code = country.code,
                updated_by_id = Guid.NewGuid(),
                updated_on = DateTime.Now,
            };
            var data = await _lookupRepository.Update(lookup_Country);
            if(data != null)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region State
        public async Task<bool> Add(lookup_StateViewModel state)
        {
            Lookup_State lookup_State = new Lookup_State
            {
                id = Guid.NewGuid(),
                name = state.name,
                is_active = true,
                lookup_country_id = state.lookup_country_id,
                created_by_id = Guid.NewGuid(),
            };
            var data = await _lookupRepository.Add(lookup_State);
            if(data  != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteState(Guid id)
        {
            return await _lookupRepository.DeleteState(id);
        }

        public async Task<bool> Update(lookup_StateViewModel state)
        {
            Lookup_State lookup_State = new Lookup_State
            {
                id = state.id,
                name = state.name,
                is_active = true,
                lookup_country_id = state.lookup_country_id,
                updated_by_id = Guid.NewGuid()
            };
            var data = await _lookupRepository.Update(lookup_State);
            if (data != null)
            {
                return true;
            }
            return false;
        }



        #endregion

        #region Besnu
            public async Task<Lookup_Besnu> AddBesnu(BesnuViewModel model)
            {
                string fileName = string.Empty;
                if (!string.IsNullOrEmpty(model.image))
                {
                    fileName = ConvertImageSaveForBesnu(model.image);
                }
            Lookup_Besnu besnu = new Lookup_Besnu()
            {
                id = Guid.NewGuid(),
                name = model.name,
                lookup_village_id = model.lookup_village_id,
                death_date = model.death_date,
                besnu_date = model.death_date,
                address = model.address,
                start_time = model.start_time,
                end_time = model.end_time,
                relative_name = model.relative_name,
                image = fileName,
                village = model.village,
                age = model.age,
                is_active = model.is_active,
                created_by_id = Guid.NewGuid()
                };
                return await _lookupRepository.AddBesnu(besnu);
            }

        public async Task<Lookup_Besnu> UpdateBesnu(BesnuViewModel model)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(model.image))
            {
                fileName = ConvertImageSaveForBesnu(model.image);
            }
            Lookup_Besnu besnu = new Lookup_Besnu()
            {
                id = model.id,
                name = model.name,
                lookup_village_id = model.lookup_village_id,
                death_date = model.death_date,
                besnu_date = model.besnu_date,
                address = model.address,
                start_time = model.start_time,
                end_time = model.end_time,
                relative_name = model.relative_name,
                image = fileName,
                village = model.village,
                age = model.age,
                is_active = model.is_active,
                updated_by_id = Guid.NewGuid(), 
                updated_on = DateTime.Now
            };

            return await _lookupRepository.UpdateBesnu(besnu);
        }
        public async Task<bool> DeleteBesnu(Guid id)
        {
            return await _lookupRepository.DeleteBesnu(id);
        }

        #endregion

        #region News
        public async Task<Lookup_News> AddNews(NewsViewModel model)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(model.image))
            {
                fileName = ConvertImageSaveForNews(model.image);
            }
            Lookup_News news = new Lookup_News()
                {
                    id = Guid.NewGuid(),
                    title = model.title,
                    description = model.description,
                    image = fileName,
                    village = model.village,
                    dateTime = model.dateTime,
                    is_active = model.is_active,
                    created_by_id = Guid.NewGuid(),
                    created_on = DateTime.Now
                };

                return await _lookupRepository.AddNews(news);
        }


        public async Task<Lookup_News> UpdateNews(NewsViewModel model)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(model.image))
            {
                fileName = ConvertImageSaveForNews(model.image);
            }
            Lookup_News news = new Lookup_News()
            {
                id = model.id,
                title = model.title,
                description = model.description,
                image = fileName,
                village = model.village,
                dateTime = model.dateTime,
                is_active = model.is_active,
                updated_by_id = Guid.NewGuid(),
                updated_on = DateTime.Now
            };

            return await _lookupRepository.UpdateNews(news);
        }
        public async Task<bool> DeleteNews(Guid id)
        {
            return await _lookupRepository.DeleteNews(id);
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

        private string ConvertImageSaveForCountry(string imageUrl)
        {
            string targetFolderPath = Path.Combine(_env.ContentRootPath, "Uploads", "Countries");

            string fileName = SaveImageFromUrl(imageUrl, targetFolderPath);

            string relativePath = Path.Combine("Uploads", "Countries", fileName);

            return relativePath;
        } 
        private string ConvertImageSaveForBesnu(string imageUrl)
        {
            string targetFolderPath = Path.Combine(_env.ContentRootPath, "Uploads", "Besnu");

            string fileName = SaveImageFromUrl(imageUrl, targetFolderPath);

            string relativePath = Path.Combine("Uploads", "Besnu", fileName);

            return relativePath;
        }
        private string ConvertImageSaveForNews(string imageUrl)
        {
            string targetFolderPath = Path.Combine(_env.ContentRootPath, "Uploads", "News");

            string fileName = SaveImageFromUrl(imageUrl, targetFolderPath);

            string relativePath = Path.Combine("Uploads", "News", fileName);

            return relativePath;
        }


        #endregion
    }
}
