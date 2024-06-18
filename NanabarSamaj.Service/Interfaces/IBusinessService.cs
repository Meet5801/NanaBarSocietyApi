using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Service.Interfaces
{
    public interface IBusinessService
    {
        Task<Business> Add(BusinessViewModel model);
        Task<Guid> Update(Business entity);
        Task<IEnumerable<GetBusinessViewModel>> GetAll();
        Task<GetBusinessViewModel> GetById(Guid id);
        Task<bool> Delete(Guid id);


    }
}
