using System.Collections.Generic;

namespace SeaPort.Models;

public class Warehouse
{
    public Dictionary<string, int> Goods { get; } = new();

    public void OnShipArrived(Ship ship)
    {
        Goods.TryAdd(ship.Cargo.Type, 0);

        Goods[ship.Cargo.Type] += ship.Cargo.Amount;
    }
}