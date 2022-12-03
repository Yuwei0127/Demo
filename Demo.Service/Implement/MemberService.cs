using Demo.Repository.Interface;
using Demo.Repository.Models;
using Demo.Service.Interface;
using Demo.Service.Models;
using MapsterMapper;

namespace Demo.Service.Implement;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;
    private readonly IMapper _mapper;

    public MemberService(IMemberRepository memberRepository, 
                         IMapper mapper)
    {
        _memberRepository = memberRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MemberDto>> GetMemberInfoAsync()
    {
        var memberData =await _memberRepository.GetAllAsync();

        var result = _mapper.Map<IEnumerable<MemberDto>>(memberData);
        
        return result;
    }
}
