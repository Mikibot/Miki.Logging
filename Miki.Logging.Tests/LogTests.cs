using System;
using Xunit;

namespace Miki.Logging.Tests
{
    public class LogTests
    {
        public int logSeconds = 12;
        public string LastMessage = null;

        public LogTests()
        {
            new LogBuilder()
                .AddLogEvent((x, y) => LastMessage = (y > LogLevel.Debug) ? x : null)
                .SetLogHeader((x) => $"[{logSeconds}][{x}]:")              
                .Apply();
        }

        [Fact]
        public void LogTest()
        {
            Log.Debug("test");
            Assert.Null(LastMessage);

            Log.Message("test");
            Assert.NotNull(LastMessage);
            Assert.Equal("[12][Information]: test", LastMessage);
        }
    }
}
