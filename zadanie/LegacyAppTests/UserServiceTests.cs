using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
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
        Assert.Equal(false, result);

    }

    [Fact]
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

        Assert.Equal(true, result);

    }

    [Fact]
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
        Assert.Equal(false, result);

    }

    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Empty()
    {
        string firstNAme = "";
        string lastName = "Doe";
        DateTime dob = new DateTime(1997, 2, 3);
        int clientId = 1;
        string email = "jdoe";
        var service = new UserService();

        bool result = service.AddUser(firstNAme, lastName, email, dob, clientId);

        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_FirstName_Null()
    {

        var service = new UserService();

        bool result = service.AddUser(null, "Doe", "w@w.com", new DateTime(1990, 2, 3), 1);

        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Empty()
    {
        string firstNAme = "John";
        string lastName = "";
        DateTime dob = new DateTime(1997, 2, 3);
        int clientId = 1;
        string email = "jdoe";
        var service = new UserService();

        bool result = service.AddUser(firstNAme, lastName, email, dob, clientId);

        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_LastName_Null()
    {
        var service = new UserService();

        bool result = service.AddUser("John", null, "w@w.com", new DateTime(1990, 2, 3), 1);

        Assert.Equal(false, result);
    }

    [Fact]
    public void Should_Return_True_When_Type_NormalClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 5);

        Assert.Equal(true, result);
    }

    [Fact]
    public void Should_Return_True_When_Under500CreditLimit_And_Type_NormalClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 1);

        Assert.Equal(false, result);
    }

[Fact]
    public void Should_Return_True_When_Type_VeryImportantClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 2);

        Assert.Equal(true, result);
    }

    [Fact]
    public void Should_Return_True_When_Type_ImportantClient()
    {
        var service = new UserService();
        var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 3);

        Assert.Equal(true, result);
    }

    [Fact]
    public void Should_Return_FalseWithNoCreditLimit()
        {
            var service = new UserService();
            var result = service.AddUser("John", "Doe", "jd@wp.pl", new DateTime(1999, 01, 01), 6);

            Assert.Equal(true, result);
        }
    
}