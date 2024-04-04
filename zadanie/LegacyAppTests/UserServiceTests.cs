using LegacyApp;


namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    [Obsolete("Obsolete")]
    public void AddUser_Should_Return_False_When_Email_Without_At_And_Dot()
    {
        //Arrange
        string firstNAme = "John";
        string lastName = "Doe";
        DateTime dob = new DateTime(1997, 2, 3);
        int clientId = 1;
        string email = "jdoe";
        var service = new UserService();
        //Act
        bool result = service.AddUser(firstNAme, lastName, email, dob, clientId);
        //Asset
        Assert.False(result);

    }

    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Return_True_When_After_Birthday_This_Year()
    {
        //Arrange
        string firstNAme = "John";
        string lastName = "Doe";
        DateTime dob = new DateTime(2003, 1, 3);
        int clientId = 1;
        string email = "j@doe.pl";
        var service = new UserService();
        //Act
        bool result = service.AddUser(firstNAme, lastName, email, dob, clientId);

        Assert.True(result);

    }

    [Fact]
    [Obsolete("Obsolete")]
    public void AddUser_Should_Return_False_When_Age_Under_21()
    {
        //Arrange
        string firstNAme = "John";
        string lastName = "Doe";
        DateTime dob = new DateTime(2003, 12, 3);
        int clientId = 1;
        string email = "j@doe.pl";
        var service = new UserService();
        //Act
        bool result = service.AddUser(firstNAme, lastName, email, dob, clientId);
        //Asset
        Assert.False(result);

    }

    [Fact]
    [Obsolete("Obsolete")]
    public void AddUser_Should_Return_False_When_FirstName_Empty()
    {
        string firstNAme = "";
        string lastName = "Doe";
        DateTime dob = new DateTime(1997, 2, 3);
        int clientId = 1;
        string email = "jdoe";
        var service = new UserService();

        bool result = service.AddUser(firstNAme, lastName, email, dob, clientId);

        Assert.False(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void AddUser_Should_Return_False_When_FirstName_Null()
    {

        var service = new UserService();

        bool result = service.AddUser(null, "Doe", "w@w.com", new DateTime(1990, 2, 3), 1);

        Assert.False(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void AddUser_Should_Return_False_When_LastName_Empty()
    {
        string firstNAme = "John";
        string lastName = "";
        DateTime dob = new DateTime(1997, 2, 3);
        int clientId = 1;
        string email = "jdoe";
        var service = new UserService();

        bool result = service.AddUser(firstNAme, lastName, email, dob, clientId);

        Assert.False(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void AddUser_Should_Return_False_When_LastName_Null()
    {
        var service = new UserService();

        bool result = service.AddUser("John", null, "w@w.com", new DateTime(1990, 2, 3), 1);

        Assert.False(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Return_True_When_Type_NormalClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 5);

        Assert.True(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Return_False_When_Under500CreditLimit_And_Type_NormalClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Kowalski", "kowalski@wp.pl", new DateTime(1999, 01, 01), 1);

        Assert.False(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Return_True_When_Type_VeryImportantClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 2);

        Assert.True(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Return_True_When_Type_ImportantClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 3);

        Assert.True(result);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Return_True_When_LastName_In_Database_With_Different_ClientId()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "andrzejewicz@wp.pl", new DateTime(1999, 01, 01), 6);

        Assert.True(result);
    }
    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Throw_Exception_With_LastName_In_Database_And_NoCreditLimit()
    {
        var service = new UserService();

        var exception = Assert.Throws<ArgumentException>(Act);
        Assert.Contains("Client Andrzejewicz does not exist", exception.Message);
        return;

        void Act() => service.AddUser("John", "Andrzejewicz", "andrzejewicz@wp.pl", new DateTime(1999, 01, 01), 6);
    }

    [Fact]
    [Obsolete("Obsolete")]
    public void Should_Throw_Exception_When_NoIdClient_In_Database()
    {
        var service = new UserService();

        var exception = Assert.Throws<ArgumentException>(Act);

       
        Assert.Contains("User with id 8 does not exist in database", exception.Message);
        return;

        void Act() => service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 8);
    }
    [Fact]
    public void AddUser_Should_Add_User_When_Valid_Data()
    {
       
        var fakeClientRepository = new FakeClientRepository();
        var userCreditService = new UserCreditService();
        var userService = new UserService(fakeClientRepository, userCreditService);
        
        var result = userService.AddUser("James", "Doe", "jamesjones@example.com", new DateTime(1987, 4, 23), 1);
       
        Assert.True(result);
        
    }
    [Fact]
    public void AddUser_Should_Add_User_To_FakeRepository()
    {
        var fakeUserRepository = new FakeUserRepository();
        var user = new User { LastName = "Doe" };
        
        fakeUserRepository.AddUser(user);
        
        var addedUsers = fakeUserRepository.GetAllUsers();
        
        Assert.Contains(user, addedUsers);
    }

}