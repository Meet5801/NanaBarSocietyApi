using NanabarSamaj.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Repository.Interfaces
{
    public  interface IInquiryRepository
    {
        Task<IEnumerable<Inquiry>> GetAll();
        Task<Inquiry> Add(Inquiry entity);
        Task<Guid> Update(Inquiry entity);
        Task<bool> Delete(Guid id);
        Task<Inquiry> GetById(Guid id);

    }
}
