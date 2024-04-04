namespace LegacyApp;

public class NameValidator
{
    public static bool IsNameNotEmptyNorNull(string firstName, string lastName)
    {
        return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
    }
}