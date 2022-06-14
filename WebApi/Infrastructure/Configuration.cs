using WebApi.Repository;
using WebApi.Services;

namespace WebApi.Infrastructure; 

public static class Configuration {
    public static void ConfigurationService(IServiceCollection services) {
        // Repository
        services.AddTransient<IncidentRepository>();
        services.AddTransient<AccountRepository>();
        services.AddTransient<ContactRepository>();
        
        // Services
        services.AddTransient<IncidentService>();;
        services.AddTransient<AccountService>();;
        services.AddTransient<ContactService>();;
    }
}