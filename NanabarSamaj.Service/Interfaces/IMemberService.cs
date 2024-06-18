using NanabarSamaj.Data.Entities;
using NanabarSamaj.Data.ViewModels;

namespace NanabarSamaj.Service.Interfaces
{
    public interface IMemberService
    {
        Task<Members> Add(MemberViewModel member);
        Task<Members> Update(MemberViewModel member);
        Task<bool> Delete(Guid id);
        Task<GetMemberViewModel> GetById(Guid id);
        Task<List<GetMemberViewModel>> GetAll(GetMemberRequestViewModel getMemberRequestViewModel);
    }
}