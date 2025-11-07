using System.Text.RegularExpressions;

public class LogParser
{
    private string[] validLines = ["[TRC]", "[DBG]", "[INF]", "[WRN]", "[ERR]", "[FTL]"];
    
    private static readonly Regex PasswordRegex = new("\"[^\"]*password[^\"]*\"", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex EndOfLineRegex = new(@"end-of-line\d*", RegexOptions.IgnoreCase | RegexOptions.Compiled);

    private static readonly Regex PWRegex =
        new(@"\bpassword\w*\b", RegexOptions.IgnoreCase | RegexOptions.Compiled);
    
    public bool IsValidLine(string text) =>  (validLines.Contains(text.Substring(0,5))) ? true : false;
        
    public string[] SplitLogLine(string text) => Regex.Split(text, "<[\\^*=-]+>");
    
    public int CountQuotedPasswords(string lines) => PasswordRegex.Count(lines);

    public string RemoveEndOfLineText(string line)
    {
        if (string.IsNullOrEmpty(line))
            return line;
    
        return EndOfLineRegex.Replace(line, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var result = new string[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i] ?? string.Empty;
            var matches = PWRegex.Matches(line);

            var offending = matches.FirstOrDefault(m => m.Value.Length > "password".Length);

            if (offending != null)
            {
                result[i] = $"{offending.Value}: {line}";
            }
            else
            {
                result[i] = $"--------: {line}";
            }
        }

        return result;
    }
}
