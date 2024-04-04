using System;

namespace LegacyApp;

public class CreditScoreValidator
{
    private readonly IUserCreditService _userCreditService;

    public CreditScoreValidator(IUserCreditService userCreditService)
    {
        _userCreditService = userCreditService;
    }

    public CreditScoreValidator()
    {
        _userCreditService = new UserCreditService();
    }

    public bool IsCreditScoreValid(string lastName, DateTime dateOfBirth, bool hasCreditLimit, Client client)
    {
        if (!hasCreditLimit)
        {
            return true;
        }

        int creditLimit = _userCreditService.GetCreditLimit(lastName, dateOfBirth);

        if (client.Type == "ImportantClient")
        {
            creditLimit *= 2;
        }

        return creditLimit >= 500;
    }
}
