namespace LegacyApp;

public class EmailValidator
{
    public static bool IsEmailFormatOk(string email)
    {
        return email.Contains('@') || email.Contains('.');
    }
}