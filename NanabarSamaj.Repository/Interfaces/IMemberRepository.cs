using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;

namespace NanabarSamaj.Repository.Interfaces
{
    public interface IMemberRepository
    {
        Task<Members> Add(Members member);
        Task<Members> Update(Members member);
        Task<bool> Delete(Guid id);
        Task<GetMemberViewModel> GetById(Guid id);
        Task<List<GetMemberViewModel>> GetAll(GetMemberRequestViewModel getMemberRequestViewModel);
    }
}