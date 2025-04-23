using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using System.Reactive;
using Avalonia.Threading;
using Avalonia.ReactiveUI;
using SeaPort.Models; // Добавлено для доступа к RxApp.MainThreadScheduler

public class MainViewModel : ReactiveObject
{
    private readonly Port _port = new();
    public ObservableCollection<string> Logs { get; } = new();

    private string _shipName = "";
    private string _cargoType = "";
    private int _cargoAmount;

    public string ShipName { get => _shipName; set => this.RaiseAndSetIfChanged(ref _shipName, value); }
    public string CargoType { get => _cargoType; set => this.RaiseAndSetIfChanged(ref _cargoType, value); }
    public int CargoAmount { get => _cargoAmount; set => this.RaiseAndSetIfChanged(ref _cargoAmount, value); }

    public ReactiveCommand<Unit, Unit> AddShipCommand { get; }

    public MainViewModel()
    {
        // Команда теперь исполняется в UI-потоке
        AddShipCommand = ReactiveCommand.Create(AddShip, outputScheduler: RxApp.MainThreadScheduler);

        _port.Terminal.ShipArrived += ship =>
        {
            Logs.Add($"Корабль '{ship.Name}' прибыл с грузом: {ship.Cargo.Type} ({ship.Cargo.Amount})");
            Logs.Add($"Склад теперь содержит: {string.Join(", ", _port.Warehouse.Goods.Select(kv => $"{kv.Key}: {kv.Value}"))}");
        };
    }

    private void AddShip()
    {
        var cargo = new Cargo(CargoType, CargoAmount);
        var ship = new Ship(ShipName, cargo);
        _port.AddShip(ship);
    }
}