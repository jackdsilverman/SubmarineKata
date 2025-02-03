using Subamrine.Kata.Services;

namespace Submarine.Kata.Tests.ServiceTests;

public class SubmarineServiceTests
{
    [Test]
    public void Rise_Stay_At_The_Top()
    {
        //arrange
        int rise = 5;
        ISubmarineService submarineService = new SubmarineService();
        //act
        submarineService.HandleUp(rise);
        //assert
        Assert.That(submarineService.GetDepth(), Is.EqualTo(0));
    }
    [Test]
    public void Forward_Go_Forward()
    {
        //arrange
        int forward = 10;
        ISubmarineService submarineService = new SubmarineService();
        //act
        submarineService.HandleForward(forward);
        //assert
        Assert.That(submarineService.GetHorizontalPosition(), Is.EqualTo(forward));
    }
    [Test]
    public void Forward_Calculates_Position()
    {
        int forward = 5;
        ISubmarineService submarineService = new SubmarineService();

        submarineService.HandleForward(forward);

        Assert.That(submarineService.GetHorizontalPosition(), Is.EqualTo(forward));
        Assert.That(submarineService.GetAim(), Is.EqualTo(0));
        Assert.That(submarineService.GetDepth(), Is.EqualTo(0));
    }
    [Test]
    public void Line_30()
    {
        int forward = 5;
        int down = 5;

        ISubmarineService submarineService = new SubmarineService();

        submarineService.HandleForward(forward);
        submarineService.HandleDown(down);

        Assert.That(submarineService.GetHorizontalPosition(), Is.EqualTo(forward));
        Assert.That(submarineService.GetAim(), Is.EqualTo(down));
        Assert.That(submarineService.GetDepth(), Is.EqualTo(0));

    }

    [Test]
    public void Line_31()
    {
        ISubmarineService submarineService = new SubmarineService();

        submarineService.HandleForward(5);
        submarineService.HandleDown(5);
        submarineService.HandleForward(8);

        Assert.That(submarineService.GetHorizontalPosition(), Is.EqualTo(13));
        Assert.That(submarineService.GetAim(), Is.EqualTo(5));
        Assert.That(submarineService.GetDepth(), Is.EqualTo(40));
    }
    [Test]
    public void Line_32()
    {
        ISubmarineService submarineService = new SubmarineService();

        submarineService.HandleForward(5);
        submarineService.HandleDown(5);
        submarineService.HandleForward(8);
        submarineService.HandleUp(3);

        Assert.That(submarineService.GetHorizontalPosition(), Is.EqualTo(13));
        Assert.That(submarineService.GetAim(), Is.EqualTo(2));
        Assert.That(submarineService.GetDepth(), Is.EqualTo(40));
    }

    [Test]
    public void Line_33()
    {
        ISubmarineService submarineService = new SubmarineService();

        submarineService.HandleForward(5);
        submarineService.HandleDown(5);
        submarineService.HandleForward(8);
        submarineService.HandleUp(3);
        submarineService.HandleDown(8);

        Assert.That(submarineService.GetHorizontalPosition(), Is.EqualTo(13));
        Assert.That(submarineService.GetAim(), Is.EqualTo(10));
        Assert.That(submarineService.GetDepth(), Is.EqualTo(40));
    }
    [Test]
    public void Line_34()
    {
        ISubmarineService submarineService = new SubmarineService();

        submarineService.HandleForward(5);
        submarineService.HandleDown(5);
        submarineService.HandleForward(8);
        submarineService.HandleUp(3);
        submarineService.HandleDown(8);
        submarineService.HandleForward(2);

        Assert.That(submarineService.GetHorizontalPosition(), Is.EqualTo(15));
        Assert.That(submarineService.GetAim(), Is.EqualTo(10));
        Assert.That(submarineService.GetDepth(), Is.EqualTo(60));
        Assert.That(submarineService.GetChecksum(), Is.EqualTo(900));
        
    }
}
