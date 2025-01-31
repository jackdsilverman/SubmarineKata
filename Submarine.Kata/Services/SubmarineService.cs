using Submarine.Kata.Models;

namespace Subamrine.Kata.Services;

public interface ISubmarineService
{
    public void Dive(int dive); 
    public void Rise(int rise);
    public void Forward(int forward);

    public int GetDepth();
    public int GetDistance();
    public int GetDistanceTraveled();

}

public class SubmarineService : ISubmarineService
{
    readonly Sub sub;
    public SubmarineService()
    {
        sub = new Sub();
    }
    public void Dive(int dive) => sub.Depth += dive;
    public void Rise(int rise)
    {
        if(sub.Depth - rise <=0) sub.Depth=0;
        else sub.Depth -= rise;
    }

    public void Forward(int forward) => sub.Distance += forward;

    public int GetDepth() => sub.Depth;

    public int GetDistance() => sub.Distance;

    public int GetDistanceTraveled() => Math.Abs(sub.Depth * sub.Distance);
}
