namespace Flashcards.Api.Configs;

public static class Helper
{
    public static string Capitalize(string word)
    {
        return char.ToUpper(word[0]) + word[1..];
    }
}