using System;
using System.Collections.Generic;
using System.Text;

namespace Miki.Logging
{
    public class LogBuilder
    {
        List<LogEvent> logEvents = new List<LogEvent>();
        List<LogException> exceptionEvents = new List<LogException>();

        LogHeaderFactory builder = (x) => "";
        LogTheme theme;

        public LogBuilder AddLogEvent(LogEvent @event)
        {
            logEvents.Add(@event);
            return this;
        }

        public LogBuilder AddExceptionEvent(LogException @event)
        {
            exceptionEvents.Add(@event);
            return this;
        }

        /// <summary>
        /// Applies the current state of the factory, and locks the Log for further configuration.
        /// </summary>
        public void Apply()
        {
            if(Log._locked)
            {
                throw new UnauthorizedAccessException("The log is already set up.");
            }

            foreach(var ev in logEvents)
            {
                Log.OnLog += ev;
            }

            foreach(var ev in exceptionEvents)
            {
                Log.OnException += ev;
            }

            Log._theme = theme;
            Log._createHeader = builder;
            Log._locked = true;
        }

        public LogBuilder SetTheme(LogTheme theme)
        {
            this.theme = theme;
            return this;
        }

        public LogBuilder SetLogHeader(LogHeaderFactory builder)
        {
            this.builder = builder;
            return this;
        }
    }
}
