using Moq;
using Subamrine.Kata.Services;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
namespace Submarine.Kata.Tests;

public class PilotTests
{
    MockFileSystem fileSystemMock;
    Mock<ISubmarineService> subServiceMock;
    [SetUp]
    public void Setup()
    {
        subServiceMock = new Mock<ISubmarineService>();
        fileSystemMock = new MockFileSystem(new Dictionary<string, MockFileData>()
        {
            {@"c:/testFile.txt", new MockFileData("up 1\ndown 2\nforward 5\ndown 5\nup 1\nforward 4")}
        });
    }
    [Test]
    public void Drive_No_File()
    {
        //arrange
        var args = new string[]{};
        var expected = "Please provide directions for the submarine";

        Pilot pilot = new Pilot(subServiceMock.Object, fileSystemMock);
        //act
        var message = pilot.Drive(args);
        //assert
        Assert.That(message, Is.EqualTo(expected));
    }

    [Test]
    public void Drive_Not_A_File()
    {
        //arrange
        var args = new string[]{"d:/"};
        var expected = "Not a valid file";

        Pilot pilot = new Pilot(subServiceMock.Object, fileSystemMock);
        //act
        var message = pilot.Drive(args);

        //assert
        Assert.That(message, Is.EqualTo(expected));
    }

    [Test]
    public void Drive_Good_File()
    {
        //arrange
        var args = new string[]{@"c:/testFile.txt"};
        var expected = "\nHorizontal Position: 9\n\nSubmarine Depth: 6\n\nHorizontal Position * Depth: 54";
    
        subServiceMock.Setup(ss => ss.GetDepth()).Returns(6);
        subServiceMock.Setup(ss => ss.GetDistance()).Returns(9);
        subServiceMock.Setup(ss => ss.GetDistanceTraveled()).Returns(54);
        Pilot pilot = new Pilot(subServiceMock.Object, fileSystemMock);
        //act
        var message = pilot.Drive(args);
        //assert
        Assert.That(message, Is.EqualTo(expected));
    }
    [Test]
    public void Drive_Good_File_Bad_Directions()
    {
        //arrange
        var args = new string[]{@"c:/badDirections.txt"};
        var expected = "\nHorizontal Position: 0\n\nSubmarine Depth: 0\n\nHorizontal Position * Depth: 0";
    
        fileSystemMock.AddFile("c:/badDirections.txt", new MockFileData("backwards 2\nstraight 3"));
        Pilot pilot = new Pilot(subServiceMock.Object, fileSystemMock);

        //act
        var message = pilot.Drive(args);
        //assert
        Assert.That(message, Is.EqualTo(expected));
    }
}