using Serilog;

namespace LoggerManager
{
    public class SerilogConfig
    {
        public static ILogger CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            return new LoggerConfiguration().CreateLogger();
        }
    }
}