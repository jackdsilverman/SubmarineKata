using Subamrine.Kata.Services;
using Submarine.Kata.Services;

namespace Submarine.Kata;


public class Pilot(ISubmarineService submarineService, IFileService fileService)
{   
    readonly ISubmarineService _submarineService = submarineService;
    readonly IFileService _fileService = fileService;
    public string Drive(string[] args)
    {
        var file = _fileService.GetFileName(args);
        if(!_fileService.IsFile(file)) return file;

        List<string> directions = _fileService.GetDirectionsFromFile(file);

        if(directions.Count > 0)
        {
            directions.ForEach(d =>
            {
                var distance = Convert.ToInt32(d.Split(' ')[1]);

                if (d.Contains("up")) _submarineService.Rise(distance);
                else if (d.Contains("down")) _submarineService.Dive(distance);
                else if(d.Contains("forward")) _submarineService.Forward(distance);
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
        return $"Distance Traveled: {_submarineService.GetDistance()}\nSubmarine Depth: {_submarineService.GetDepth()}\nTotal Distance Traveled: {_submarineService.GetDistanceTraveled()}";
    }


}