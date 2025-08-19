public static class Identifier
{
    public static string Clean(string identifier)
    {
        bool pascalCase = false;
        string cleanString = "";
        foreach(char character in identifier)
        {
            if (Char.IsWhiteSpace(character))
            {
                cleanString += '_';
            }
            else if (Char.IsControl(character))
            {
                cleanString += "CTRL";
            }
            else if (character == '-')
            {
                pascalCase = true;
            }
            else if (pascalCase == true)
            {
                cleanString += char.ToUpper(character);
                pascalCase = false;
            }
            else if (Char.IsLetter(character) && (character < '\u03B1' || character > '\u03C9'))
            {
                cleanString += character;
            }
        }
        return cleanString;
    }
}
