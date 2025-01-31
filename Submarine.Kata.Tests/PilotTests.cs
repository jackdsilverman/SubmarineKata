using Moq;
using Subamrine.Kata.Services;
using Submarine.Kata.Services;
namespace Submarine.Kata.Tests;

public class PilotTests
{
    [Test]
    public void Drive_Not_A_File()
    {
        //arrange
        var args = new string[]{"file/"};
        var expected = "Not a valid path";

        var subServiceMock = new Mock<ISubmarineService>();
        var fileServiceMock = new Mock<IFileService>();
        fileServiceMock.Setup(fs => fs.GetFileName(It.IsAny<string[]>())).Returns(expected);
        fileServiceMock.Setup(fs => fs.IsFile(It.IsAny<string>())).Returns(false);

        Pilot pilot = new Pilot(subServiceMock.Object, fileServiceMock.Object);
        //act
        var message = pilot.Drive(args);

        //assert
        Assert.That(message, Is.EqualTo(expected));
    }
    [Test]
    public void Drive_No_File()
    {
        var args = new string[]{};
        var expected = "Please provide directions for the submarine";

        var subServiceMock = new Mock<ISubmarineService>();
        var fileServiceMock = new Mock<IFileService>();
        fileServiceMock.Setup(fs => fs.GetFileName(It.IsAny<string[]>())).Returns(expected);
        fileServiceMock.Setup(fs => fs.IsFile(It.IsAny<string>())).Returns(false);
        Pilot pilot = new Pilot(subServiceMock.Object, fileServiceMock.Object);
        //act
        var message = pilot.Drive(args);
        //assert
        Assert.That(message, Is.EqualTo(expected));
    }
    [Test]
    public void Drive_Good_File()
    {
        //arrange
        var args = new string[]{"file.txt"};
        var directions = new List<string> {"up 1","down 2","forward 5","down 5","up 1","forward 4"};
        var expected = $"Distance Traveled: 9\nSubmarine Depth: 6\nTotal Distance Traveled: 54";
    
        var fileServiceMock = new Mock<IFileService>();
        fileServiceMock.Setup(fs => fs.GetFileName(It.IsAny<string[]>())).Returns(args[0]);
        fileServiceMock.Setup(fs => fs.IsFile(It.IsAny<string>())).Returns(true);
        fileServiceMock.Setup(fs => fs.GetDirectionsFromFile(It.IsAny<string>())).Returns(directions);

        var subServiceMock = new Mock<ISubmarineService>();
        subServiceMock.Setup(ss => ss.GetDepth()).Returns(6);
        subServiceMock.Setup(ss => ss.GetDistance()).Returns(9);
        subServiceMock.Setup(ss => ss.GetDistanceTraveled()).Returns(54);
        Pilot pilot = new Pilot(subServiceMock.Object, fileServiceMock.Object);
        //act
        var message = pilot.Drive(args);
        //assert
        Assert.That(message, Is.EqualTo(expected));
    }
}