using Submarine.Kata.Models;

namespace Subamrine.Kata.Services;

public interface ISubmarineService
{
    public void HandleDown(int dive); 
    public void HandleUp(int rise);
    public void HandleForward(int forward);

    public int GetDepth();
    public int GetHorizontalPosition();
    public int GetChecksum();
    public int GetAim();
}

public class SubmarineService : ISubmarineService
{
    readonly Sub sub;
    public SubmarineService()
    {
        sub = new Sub();
    }
    public void HandleDown(int down) => sub.Aim += down;
    public void HandleUp(int up) => sub.Aim -= up;

    public void HandleForward(int forward){
        sub.HorizontalPosition += forward;
        sub.Depth += sub.Aim * forward;
    }

    public int GetDepth() => sub.Depth;

    public int GetHorizontalPosition() => sub.HorizontalPosition;

    public int GetAim() => sub.Aim;
    public int GetChecksum() =>sub.Depth * sub.HorizontalPosition;
}
