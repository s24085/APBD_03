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
        private CreditScoreValidator creditScoreValidator=new CreditScoreValidator();
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
            if (!nameValidator.isNameNotEmptyNorNull(firstName, lastName) ||
                !emailValidator.isEmailFormatOk(email) ||
                !ageValidator.isOldEnough(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName,
                HasCreditLimit = client.Type != "VeryImportantClient"
            };

            if (!creditScoreValidator.IsCreditScoreValid(user.LastName, user.DateOfBirth, user.HasCreditLimit, client))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
