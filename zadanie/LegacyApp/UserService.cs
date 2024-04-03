using System;

namespace LegacyApp
{
    public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;
        private NameValidator nameValidator= new NameValidator();
        private EmailValidaor emailValidator=new EmailValidaor();
        private AgeValidator ageValidator= new AgeValidator();

        [Obsolete]
        public UserService()
        {
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
        }
        public UserService(IClientRepository clientRepository, IUserCreditService creditService)
        {
            _clientRepository = clientRepository;
            _userCreditService = creditService;
            
        }
       
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            nameValidator.isNameNotEmptyNorNull(firstName, lastName);
            emailValidator.isEmailFormatOk(email);
            ageValidator.isOldEnough(dateOfBirth);
            
            
            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
              
                {
                    int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
            }

            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
