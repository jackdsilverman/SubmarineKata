using Subamrine.Kata.Services;

namespace Submarine.Kata.Tests.ServiceTests;

public class SubmarineServiceTests
{
    [Test]
    public void Dive_Go_Deeper()
    {
        //arrange
        int dive = 15;
        ISubmarineService submarineService = new SubmarineService();
        //act
        submarineService.Dive(dive);
        //assert
        Assert.That(submarineService.GetDepth(), Is.EqualTo(dive));
    }
    [Test]
    public void Rise_Go_Up()
    {
        //arrange
        int dive = 15;
        int rise = 5;
        ISubmarineService submarineService = new SubmarineService();
        //act
        submarineService.Dive(dive);
        submarineService.Rise(rise);
        //assert
        Assert.That(submarineService.GetDepth(), Is.EqualTo(dive-rise));
    }
    [Test]
    public void Rise_Stay_At_The_Top()
    {
        //arrange
        int rise = 5;
        ISubmarineService submarineService = new SubmarineService();
        //act
        submarineService.Rise(rise);
        //assert
        Assert.That(submarineService.GetDepth(), Is.EqualTo(-5));
    }
    [Test]
    public void Forward_Go_Forward()
    {
        //arrange
        int forward = 10;
        ISubmarineService submarineService = new SubmarineService();
        //act
        submarineService.Forward(forward);
        //assert
        Assert.That(submarineService.GetDistance(), Is.EqualTo(forward));
    }
    [Test]
    public void Get_Distance_Traveled()
    {
        //arrange
        int forward = 19;
        int dive = 2;
        ISubmarineService submarineService = new SubmarineService();
        //act
        submarineService.Forward(forward);
        submarineService.Dive(2);
        //assert
        Assert.That(submarineService.GetDistanceTraveled(), Is.EqualTo(forward*dive));
    }
}
