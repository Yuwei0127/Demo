using Demo.Repository.Models;
using Demo.Service.Models;

namespace Demo.Service.Interface;

public interface IMemberService
{
    /// <summary>
    /// 取得所有員工資料
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<EmployeesDataModel>> GetAllMemberInfoAsync();

    /// <summary>
    /// 用 Id 取的特定員工資料
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<EmployeesDataModel> GetMemberInfoAsync(int id);
}