using Demo.Repository.Models;
using Demo.Service.Models;

namespace Demo.Service.Interface;

public interface IMemberService
{
    /// <summary>
    /// 取得所有員工資料
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<MemberDto>> GetMemberInfoAsync();
}