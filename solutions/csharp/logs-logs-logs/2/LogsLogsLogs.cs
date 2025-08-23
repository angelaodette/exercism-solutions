public enum LogLevel
    {
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
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
        return ($"{(int)logLevel}:{message}");
    }
}
