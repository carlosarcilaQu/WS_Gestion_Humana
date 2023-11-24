using Business.BLL;
using Business.BLL.BaseBLL;
using Business.BLL.Configuration;
using Business.BLL.Login;
using Business.Interfaces;
using Business.Interfaces.BaseBLL;
using Business.Interfaces.Configuration;
using Business.Interfaces.Login;
using Microsoft.Extensions.DependencyInjection;

namespace Business
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseBLL<,,,>), typeof(BaseBLL<,,,>));
            services.AddScoped<ILoginBLL, LoginBLL>();
            services.AddScoped<ITablaBLL, TablaBLL>();
            services.AddScoped<ITableBLL, TableBLL>();
            return services;
        }
    }
}
