using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Repository.Interfaces
{
    public interface IBusinessRepository
    {
        Task<Business> Add(Business entity);
        Task<Guid> Update(Business entity);
        Task<IEnumerable<GetBusinessViewModel>> GetAll();
        Task<GetBusinessViewModel> GetById(Guid id);
        Task<bool> Delete(Guid id);




    }
}
