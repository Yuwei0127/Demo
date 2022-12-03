using Demo.Repository.Models;

namespace Demo.Repository.Interface;

public interface IMemberRepository
{
    /// <summary>
    /// 取得所有員工資料
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<EmployeesDataModel>> GetAllAsync();
}