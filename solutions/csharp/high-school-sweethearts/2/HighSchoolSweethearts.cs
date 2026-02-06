using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        const int TotalWidth = 61;
    
        string content = $"{studentA} ♡ {studentB}";
    
        if (content.Length >= TotalWidth)
            return content;
    
        int remaining = TotalWidth - content.Length;
        int leftPadding = Math.Max(0, (remaining / 2) - 1);
        int rightPadding = TotalWidth - content.Length - leftPadding;
    
        return $"{new string(' ', leftPadding)}{content}{new string(' ', rightPadding)}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return $@"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA} +  {studentB}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    }

    public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours) => string.Format(new CultureInfo("de-DE"), "{0} and {1} have been dating since {2:d} - that's {3:n2} hours", studentA, studentB, start, hours);
}
