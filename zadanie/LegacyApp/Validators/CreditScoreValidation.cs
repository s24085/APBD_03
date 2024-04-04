using System;

namespace LegacyApp;

public class CreditScoreValidator
{
    private readonly UserCreditService _userCreditService = new UserCreditService();

    public bool IsCreditScoreValid(string lastName, DateTime dateOfBirth, bool hasCreditLimit, Client client)
    {
        if (!hasCreditLimit)
        {
            return true;
        }

        var creditLimit = _userCreditService.GetCreditLimit(lastName, dateOfBirth);

        if (client.Type == "ImportantClient")
        {
            creditLimit *= 2;
        }

        return creditLimit >= 500;
    }
}
