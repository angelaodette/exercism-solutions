static class LogLine
{
    
    public static string Message(string logLine)
    {
        var separator = "]: ";
        int index = logLine.IndexOf(separator);
    
        return logLine.Substring(index + separator.Length).Trim();
    }

    public static string LogLevel(string logLine)
    {
        var separator = "]: ";
        int index = logLine.IndexOf(separator);

        return logLine.Substring(1, index - 1).ToLower();
    }

    public static string Reformat(string logLine) => $"{LogLine.Message(logLine)} ({LogLine.LogLevel(logLine)})";
}
