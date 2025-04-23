namespace SeaPort.Models;

public class Ship
{
    public string Name { get; set; }
    public Cargo Cargo { get; set; }

    public Ship(string name, Cargo cargo)
    {
        Name = name;
        Cargo = cargo;
    }
}
