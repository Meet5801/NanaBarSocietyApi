using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Service.Interfaces
{
    public interface IInquiryService
    {
        Task<IEnumerable<Inquiry>> GetAll();
        Task<Inquiry> Add(InquiryViewModel model);
        Task<Guid> Update(Inquiry entity);
        Task<bool> Delete(Guid id);
        Task<Inquiry> GetById(Guid id);


    }
}
