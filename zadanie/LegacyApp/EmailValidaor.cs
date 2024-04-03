namespace LegacyApp;

public class EmailValidaor
{
    public bool isEmailFormatOk(string email)
    {


        if (!email.Contains("@") && !email.Contains("."))
        {
            return false;
        }
        return true;
    }
}