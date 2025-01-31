namespace Submarine.Kata.Services;

public interface IFileService
{
    public string GetFileName(string[] args);
    public bool IsFile(string file);
    public List<string> GetDirectionsFromFile(string file);
}

public class FileService : IFileService
{
    public string GetFileName(string[] args)
    {
        if(args.Length == 0) 
        {
            return "Please provide directions for the submarine";
        }
        else if(!File.Exists(args[0]))
        {
            return "Not A valid path";
        }
        return args[0];
    }
    public bool IsFile(string file) => File.Exists(file);
    public List<string> GetDirectionsFromFile(string file)
    {
        try
        {
            Console.WriteLine("Reading Directions...");
            List<string> directions = new List<string>();
            using (StreamReader reader = File.OpenText(file))
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