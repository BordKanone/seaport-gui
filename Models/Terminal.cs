using System;

namespace SeaPort.Models;

public class Terminal
{
    public event Action<Ship>? ShipArrived;
    

    public void ReceiveShip(Ship ship)
    {
        ShipArrived?.Invoke(ship);
    }
}