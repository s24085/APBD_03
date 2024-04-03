namespace LegacyApp;

public class NameValidator
{
    public bool isNameNotEmptyNorNull(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
        {
            return false;
        }

        return true;
    }
}