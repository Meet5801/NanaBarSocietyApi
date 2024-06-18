using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanabarSamaj.Repository.Interfaces
{
    public interface IUserRepository : IRepository<Users>
    {
        Task<Guid> UpdateUser(UsersUpdateViewModel model);
        Task<Users> GetByEmailPhone(string email, string mobile_number);
        Task<Users> GetByPhone(string mobile_number);
        Task<Users> AdminGetByEmail(string email);
        Task<string> AdminGetById(Guid id);
    }
}