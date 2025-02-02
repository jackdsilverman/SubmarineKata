using System.IO.Abstractions;
using Subamrine.Kata.Services;

namespace Submarine.Kata;


public class Pilot(ISubmarineService submarineService, IFileSystem fileSystem)
{   
    public string Drive(string[] args)
    {
        var file = GetFileName(args);
        if(!IsFile(file)) return file;

        List<string> directions = GetDirectionsFromFile(file);

        if(directions.Count > 0)
        {
            directions.ForEach(d =>
            {
                var distance = Convert.ToInt32(d.Split(' ')[1]);

                if (d.Contains("up")) submarineService.Rise(distance);
                else if (d.Contains("down")) submarineService.Dive(distance);
                else if(d.Contains("forward")) submarineService.Forward(distance);
            });
            return ExposeSubmarinePosition();   
        }
        else
        {
            return "There are no directions";
        } 
    }

    private string ExposeSubmarinePosition()
    {
        return $"Distance Traveled: {submarineService.GetDistance()}\nSubmarine Depth: {submarineService.GetDepth()}\nTotal Distance Traveled: {submarineService.GetDistanceTraveled()}";
    }


    public string GetFileName(string[] args)
    {
        if(args.Length == 0) 
        {
            return "Please provide directions for the submarine";
        }
        else if(!fileSystem.File.Exists(args[0]))
        {
            return "Not a valid file";
        }
        return args[0];
    }
    public bool IsFile(string file) => fileSystem.File.Exists(file);
    public List<string> GetDirectionsFromFile(string file)
    {
        try
        {
            Console.WriteLine("Reading Directions...");
            List<string> directions = new List<string>();
            using (StreamReader reader = fileSystem.File.OpenText(file))
            {
                string line = "";
                while ((line = reader.ReadLine()!) != null)
                {
                    directions.Add(line);
                }
            }
            return directions;
        }
        catch(Exception)
        {
            throw new Exception("Something went wrong while reading directions");
        }
    }

}