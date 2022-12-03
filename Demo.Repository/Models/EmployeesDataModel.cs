namespace Demo.Repository.Models;

public class EmployeesDataModel
{
    /// <summary>
    /// 員工編號
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// 員工姓氏
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// 員工名
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// 員工生日
    /// </summary>
    public DateTime BirthDate { get; set; }
    
    /// <summary>
    /// 居住地
    /// </summary>
    public string City { get; set; }
}