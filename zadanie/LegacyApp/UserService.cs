using System;

namespace LegacyApp
{
    public class UserService(IClientRepository clientRepository, IUserCreditService creditService)
    {
        public IUserCreditService CreditService { get; } = creditService;
        private readonly CreditScoreValidator _creditScoreValidator=new CreditScoreValidator();
        [Obsolete("Obsolete")]
        public UserService() : this(new ClientRepository(), new UserCreditService())
        {
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!NameValidator.IsNameNotEmptyNorNull(firstName, lastName) ||
                !EmailValidator.IsEmailFormatOk(email) ||
                !AgeValidator.IsOldEnough(dateOfBirth))
            {
                return false;
            }

            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                DateOfBirth = dateOfBirth,
                LastName = lastName,
                HasCreditLimit = client.Type != "VeryImportantClient"
            };

            if (!_creditScoreValidator.IsCreditScoreValid(user.LastName, user.DateOfBirth, user.HasCreditLimit, client))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
