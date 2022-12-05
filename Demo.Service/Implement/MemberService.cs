using Demo.Repository.Interface;
using Demo.Repository.Models;
using Demo.Service.Interface;
using Demo.Service.Models;
using MapsterMapper;

namespace Demo.Service.Implement;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }

    public async Task<IEnumerable<EmployeesDataModel>> GetAllMemberInfoAsync()
    {
        var memberData =await _memberRepository.GetAllAsync();
        
        return memberData;
    }

    public async Task<EmployeesDataModel> GetMemberInfoAsync(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException("id 小於等於 0",nameof(id));
        }
        
        var memberData = await _memberRepository.GetAsync(id);

        if (memberData.City == "台北市")
        {
            return new EmployeesDataModel();
        }
        
        return memberData;
    }
}
