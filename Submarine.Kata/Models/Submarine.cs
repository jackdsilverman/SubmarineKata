namespace Submarine.Kata.Models;

public class Sub
{
    public Sub()
    {
        Depth = 0;
        HorizontalPosition = 0;
    }
    public int Depth { get; set; }
    public int HorizontalPosition { get; set; }
    public int Aim { get; set; }
}