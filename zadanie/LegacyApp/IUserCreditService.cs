using System;

namespace LegacyApp;

public interface IUserCreditService
{
    int GetCreditLimit(string lastname, DateTime dob);
}
