using Submarine.Kata.Services;

namespace Submarine.Kata.Tests.ServiceTests;

public class FileServiceTests
{
    [Test]
    public void GetFileName_Returns_File_Name()
    {
        //arrange
        string[] args = new string[]{"/Users/jacksilverman/submarine_kata/input.txt"};
        FileService fileService = new FileService();

        //act
        var fileName = fileService.GetFileName(args);

        //assert
        Assert.That(fileName, Is.EqualTo(args[0]));
    }
    [Test]
    public void GetFileName_Invalid_Path()
    {
        //arrange
        string[] args = new string[]{"/Users/jacksilverman/submarine_kata/"};
        FileService fileService = new FileService();

        //act
        var fileName = fileService.GetFileName(args);

        //assert
        Assert.That(fileName, Is.EqualTo("Not A valid path"));
    }
        [Test]
    public void GetFileName_No_Path()
    {
        //arrange
        string[] args = new string[]{};
        FileService fileService = new FileService();

        //act
        var fileName = fileService.GetFileName(args);

        //assert
        Assert.That(fileName, Is.EqualTo("Please provide directions for the submarine"));
    }
    [Test]
    public void IsFile_Returns_True()
    {
        //arrange
        string fileName = "/Users/jacksilverman/submarine_kata/input.txt";
        FileService fileService = new FileService();

        //act
        var isFile = fileService.IsFile(fileName);

        //assert
        Assert.That(isFile, Is.EqualTo(true));
    }
    [Test]
    public void IsFile_Returns_False()
    {
        //arrange
        string fileName = "/Users/jacksilverman/submarine_kata/inpu.txt";
        FileService fileService = new FileService();

        //act
        var isFile = fileService.IsFile(fileName);

        //assert
        Assert.That(isFile, Is.EqualTo(false));
    }
    [Test]
    public void GetDirectionsFromFile_Returns_Directions()
    {
        //arrange
        string fileName = "/Users/jacksilverman/submarine_kata/input.txt";
        FileService fileService = new FileService();

        //act
        var directions = fileService.GetDirectionsFromFile(fileName);

        //assert
        Assert.That(directions.Count, Is.GreaterThan(0));
    }
        [Test]
    public void GetDirectionsFromFile_Throws_Exception()
    {
        //arrange
        string fileName = "/Users/jacksilverman/submarine_kata/inp.txt";
        FileService fileService = new FileService();

        //assert
        Assert.Throws<Exception>(() => fileService.GetDirectionsFromFile(fileName));
    }
}