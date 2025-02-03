using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Subamrine.Kata.Services;

namespace Submarine.Kata;

public class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ISubmarineService, SubmarineService>()
            .AddSingleton<IFileSystem, FileSystem>()
            .BuildServiceProvider();

        Pilot pilot = new Pilot(serviceProvider.GetService<ISubmarineService>()!, serviceProvider.GetService<IFileSystem>()!);
        var message = pilot.Drive(args);
        Console.WriteLine(message);
        Console.WriteLine("\nPress enter to exit the sub");
        Console.Read();
    }
}
