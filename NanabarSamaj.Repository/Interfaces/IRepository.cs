
using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;

namespace NanabarSamaj.Repository.Interfaces
{
    public interface IRepository<T>
    {
        Task<GetAllUsersViewModel> GetById(Guid id);
        Task<T> Add(T entity);
        Task<Guid> Update(T entity);
        Task<bool> Delete(Guid id);
        Task<List<GetAllUsersViewModel>> GetAll();
    }
}
