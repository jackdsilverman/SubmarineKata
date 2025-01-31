using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subamrine.Kata.Services;

namespace Subamrine.Kata;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddSingleton<ISubmarineService, SubmarineService>();
    }
}