using Demo.Repository.Implement;
using Demo.Repository.Interface;
using Demo.Repository.Models;
using Demo.Service.Implement;
using Demo.Service.Interface;
using Demo.Service.Models;
using Mapster;
using MapsterMapper;

namespace Demo.Controllers.Implement;

public static class DependencyInjectionExtension
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddService();
        services.AddRepository();
        
        var config = new TypeAdapterConfig();
        config.NewConfig<EmployeesDataModel, MemberDto>().TwoWays();
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        
        
        return services;
    }

    private static IServiceCollection AddService(this IServiceCollection services)
    {
        services.AddScoped<IMemberService, MemberService>();
        return services;
    }

    private static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IMemberRepository,MemberRepository>();
        return services;
    }
    
    
}