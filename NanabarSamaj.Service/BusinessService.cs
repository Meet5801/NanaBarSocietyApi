using Microsoft.AspNetCore.Hosting;
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository.Interfaces;
using NanabarSamaj.Service.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace NanabarSamajApi
{
    public class BusinessService : IBusinessService
    {
        private readonly IBusinessRepository _businessRepository;
        private readonly IHostingEnvironment _env;


        public BusinessService(IBusinessRepository businessRepository, IHostingEnvironment env)
        {
            _businessRepository = businessRepository;
            _env = env;
        }

        public async Task<Business> Add(BusinessViewModel model)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(model.business_image_1))
            {
                fileName = ConvertImageSave(model.business_image_1);
            }
            Business business = new Business()
            {
                id = Guid.NewGuid(),
                concern_name = model.concern_name,
                business_name = model.business_name,
                business_details = model.business_details,
                lookup_business_category_id = model.lookup_business_category_id,
                address = model.address,
                lookup_city_id = model.lookup_city_id,
                lookup_country_id = model.lookup_country_id,
                lookup_state_id = model.lookup_state_id,
                zipcode = model.zipcode,
                contact_number_1 = model.contact_number_1,
                contact_number_2 = model.contact_number_2,
                website = model.website,
                email = model.email,
                facebook_link = model.facebook_link,
                instagram_link = model.instagram_link,
                business_image_1 = fileName,
                is_active = true,
                created_by_id = model.created_by_id,
                user_id = model.user_id
            };

            return await _businessRepository.Add(business);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _businessRepository.Delete(id);
        }

        public async Task<IEnumerable<GetBusinessViewModel>> GetAll()
        {
            return await _businessRepository.GetAll();
        }

        public async Task<GetBusinessViewModel> GetById(Guid id)
        {
            return await _businessRepository.GetById(id);
        }

        public async Task<Guid> Update(Business entity)
        {
            string fileName = string.Empty;
            if (!string.IsNullOrEmpty(entity.business_image_1))
            {
                fileName = ConvertImageSave(entity.business_image_1);
                entity.business_image_1 = fileName;
            }
                
            return await _businessRepository.Update(entity);
        }

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
            string targetFolderPath = Path.Combine(_env.ContentRootPath, "Uploads", "Businesses");

            string fileName = SaveImageFromUrl(imageUrl, targetFolderPath);

            string relativePath = Path.Combine("Uploads", "Businesses", fileName);

            return relativePath;
        }



        #endregion
    }
}
