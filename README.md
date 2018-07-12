# Miki.Logging
[![](https://img.shields.io/nuget/dt/Miki.Logging.svg?style=for-the-badge)](https://www.nuget.org/packages/Miki.Logging)
[![](https://img.shields.io/discord/259343729586864139.svg?style=for-the-badge&logo=discord)](https://discord.gg/XpG4kwE)

Logging library.

## Getting started
```cs
using Miki.Logging;

class MyLoggingExample 
{
    public static Main(string[] args)
    {
        // add a log provider
        Log.OnLog += Console.WriteLine;

        // set up colors :sparkles: 
        Log.Theme.SetColor(LogLevel.Error, new LogColor()
        {
            Foreground = ConsoleColor.Red,
            // optional, but to provide clarity.
            Background = null
        });

        // a multitude of log types
        Log.Message("This is a normal message!");
        Log.Error(new Exception());
    }
}
```
