using System;

namespace LegacyApp;

public class AgeValidator
{
    public bool isOldEnough(DateTime dateOfBirth)
    {
        var now = DateTime.Now;
        int age = now.Year - dateOfBirth.Year;
        if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

        if (age < 21)
        {
            return false;
        }

        return true;
    }
}