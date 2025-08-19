using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        bool priorIsDash = false;
        StringBuilder cleanString = new StringBuilder();
        foreach(char character in identifier)
        {
            //Replace whitespace characters with underscores
            if (char.IsWhiteSpace(character))
            {
                cleanString.Append('_');
            }
            //Replace control characters with "CTRL"
            else if (char.IsControl(character))
            {
                cleanString.Append("CTRL");
            }
            //Capitalize Letters after a dash character
            else if (priorIsDash)
            {
                cleanString.Append(char.ToUpper(character));
            }
            //Check that character is a letter and not a lowercase Greek letter
            else if (char.IsLetter(character) && (character < 'α' || character > 'ω'))
            {
                cleanString.Append(character);
            }
            priorIsDash = character.Equals('-');
        }
        return cleanString.ToString();
    }
}
