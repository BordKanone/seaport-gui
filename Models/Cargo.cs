namespace SeaPort.Models;

public class Cargo
{
    public string Type { get; set; }
    public int Amount { get; set; }

    public Cargo(string type, int amount)
    {
        Type = type;
        Amount = amount;
    }
}