# Miki.Logging
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
