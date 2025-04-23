namespace SeaPort.Models;

public class Port
{
    public Terminal Terminal { get; } = new();
    public Warehouse Warehouse { get; } = new();

    public Port()
    {
        Terminal.ShipArrived += Warehouse.OnShipArrived;
    }

    public void AddShip(Ship ship)
    {
        Terminal.ReceiveShip(ship);
    }
}