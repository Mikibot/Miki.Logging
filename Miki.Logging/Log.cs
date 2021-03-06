﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Miki.Logging
{
    /// <summary>
    /// Log event delegate, will handle log prints.
    /// </summary>
    /// <param name="message">The message content</param>
    /// <param name="level">The content level depth</param>
    public delegate void LogEvent(string message, LogLevel level);

    /// <summary>
    /// Log event delegate, will handle log exceptions.
    /// </summary>
    /// <param name="exception">The exception being thrown</param>
    /// <param name="level">The level of the exception</param>
    public delegate void LogException(Exception exception, LogLevel level);

    /// <summary>
    /// Creates your log header whenever a new message has been sent.
    /// </summary>
    /// <param name="level">The content level depth</param>
    /// <returns>The processed message</returns>
    public delegate string LogHeaderFactory(LogLevel level);

	public static class Log
	{
		internal static event LogEvent OnLog;
        internal static event LogException OnException;

        internal static LogHeaderFactory _createHeader = (lv) => $"[{lv.ToString()}]";

        internal static bool _locked;

        internal static LogTheme _theme = new LogTheme();

        /// <summary>
        /// Display a debug message
        /// </summary>
        /// <param name="message">information about the action</param>
        public static void Debug(string message)
		{
			WriteToLog(message, LogLevel.Debug);
		}

		/// <summary>
		/// Display a error message.
		/// </summary>
		/// <param name="message">information about the action</param>
		public static void Error(string message)
		{
            WriteToLog(message, LogLevel.Error);
        }
        public static void Error(Exception exception)
		{
            OnException?.Invoke(exception, LogLevel.Error);
			Error(exception.ToString());
		}

		/// <summary>
		/// Display a standard message.
		/// </summary>
		/// <param name="message">information about the action</param>
		public static void Message(string message)
		{
            WriteToLog(message, LogLevel.Information);
		}

		/// <summary>
		/// Display a trace message
		/// </summary>
		/// <param name="message">information about the action</param>
		public static void Trace(string message)
		{
            WriteToLog(message, LogLevel.Verbose);
		}

		/// <summary>
		/// Display a warning message.
		/// </summary>
		/// <param name="message">information about the action</param>
		public static void Warning(string message)
		{
            WriteToLog(message, LogLevel.Warning);
        }

		private static void WriteToLog(string message, LogLevel level)
		{
			LogColor color = _theme?.GetColor(level) 
                ?? new LogColor();

			Console.ForegroundColor = color.Foreground 
                ?? ConsoleColor.White;
			Console.BackgroundColor = color.Background 
                ?? ConsoleColor.Black;

			OnLog?.Invoke($"{_createHeader(level)} {message}", level);

            Console.ResetColor();
		}
	}
}