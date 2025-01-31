using Microsoft.Extensions.DependencyInjection;
using Subamrine.Kata.Services;
using Submarine.Kata.Services;

namespace Submarine.Kata;

public class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ISubmarineService, SubmarineService>()
            .AddSingleton<IFileService, FileService>()
            .BuildServiceProvider();

        Pilot pilot = new Pilot(serviceProvider.GetService<ISubmarineService>()!, serviceProvider.GetService<IFileService>()!);
        var message = pilot.Drive(args);
        Console.WriteLine(message);
    
    }
}
