public enum LogLevel
    {
    Trace,
    Debug,
    Info,
    Warning,
    Error,
    Fatal,
    Unknown
    }
    
static class LogLine
{   
    public static LogLevel ParseLogLevel(string logLine)
    {
        if (logLine.StartsWith("[TRC]")) return LogLevel.Trace;
        if (logLine.StartsWith("[DBG]")) return LogLevel.Debug;
        if (logLine.StartsWith("[INF]")) return LogLevel.Info;
        if (logLine.StartsWith("[WRN]")) return LogLevel.Warning;
        if (logLine.StartsWith("[ERR]")) return LogLevel.Error;
        if (logLine.StartsWith("[FTL]")) return LogLevel.Fatal;
        return LogLevel.Unknown;
    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
         int logLevelNumber = logLevel switch
            {
                LogLevel.Trace => 1,
                LogLevel.Debug => 2,
                LogLevel.Info => 4,
                LogLevel.Warning => 5,
                LogLevel.Error => 6,
                LogLevel.Fatal => 42,
                _ => 0
            };
        return ($"{logLevelNumber}:{message}");
    }
}
