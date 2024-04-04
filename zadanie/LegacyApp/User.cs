using System;

namespace LegacyApp
{
    public class User
    {
        public DateTime DateOfBirth { get; internal init; }
        public string LastName { get; init; }
        public bool HasCreditLimit { get; internal init; }
        public int CreditLimit { get; internal set; }
    }
}