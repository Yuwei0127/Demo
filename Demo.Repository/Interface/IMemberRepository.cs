using Demo.Repository.Models;

namespace Demo.Repository.Interface;

public interface IMemberRepository
{
    /// <summary>
    /// 取得所有員工資料
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<EmployeesDataModel>> GetAllAsync();

    /// <summary>
    /// 用 Id 取得特定員工資料
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<EmployeesDataModel> GetAsync(int id);
}