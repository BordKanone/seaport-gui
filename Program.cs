using Avalonia;
using System;
using Avalonia.ReactiveUI;

namespace SeaPort;

static class Program
{
    
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseReactiveUI() 
            .LogToTrace();
}
