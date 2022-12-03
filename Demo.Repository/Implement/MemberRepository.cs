using Demo.Repository.Interface;
using Dapper;
using Demo.Repository.Models;
using Microsoft.Data.SqlClient;

namespace Demo.Repository.Implement;

public class MemberRepository:IMemberRepository
{
    /// <summary>
    /// 連線字串
    /// </summary>
    private readonly string _connectString = 
        @"Server=(LocalDB)\MSSQLLOCALDB;Initial Catalog=Northwind;User ID=sa;Password=sa;TrustServerCertificate=true;";
    public async Task<IEnumerable<EmployeesDataModel>> GetAllAsync()
    {
        using (var conn = new SqlConnection(_connectString))
        {
            var result = await conn.QueryAsync<EmployeesDataModel>("select * from Employees");
            return result;
        }
    }
}