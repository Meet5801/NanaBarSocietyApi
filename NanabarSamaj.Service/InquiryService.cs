using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using NanabarSamaj.Repository.Interfaces;
using NanabarSamaj.Service.Interfaces;

namespace NanabarSamaj.Service
{
    public class InquiryService : IInquiryService
    {
        private readonly IInquiryRepository _inquiryRepository;
        public InquiryService(IInquiryRepository inquiryRepository)
        {
            _inquiryRepository = inquiryRepository;
        }
        public async Task<IEnumerable<Inquiry>> GetAll()
        {
            return await _inquiryRepository.GetAll();      
        }
        public async Task<Inquiry> Add(InquiryViewModel model)
        {
            Inquiry inquiry = new Inquiry
            {
                id = Guid.NewGuid(),
                phone_number = model.phone_number,
                title = model.title,
                message = model.message,
                is_active = model.is_active,
                created_by_id = Guid.NewGuid()
            };

            return await _inquiryRepository.Add(inquiry);
        }

        public Task<Guid> Update(Inquiry entity)
        {
            return _inquiryRepository.Update(entity);
        }

        public Task<bool> Delete(Guid id)
        {
            return _inquiryRepository.Delete(id);
        }

        public Task<Inquiry> GetById(Guid id)
        {
            return _inquiryRepository.GetById(id);
        }
    }
}
