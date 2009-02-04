using System.Collections.Generic;
using System.Linq;
using MbUnit.Framework;
using Openidauth.MVC.Data.DataAccess;
using Openidauth.MVC.Data.Entities;
using User=Openidauth.MVC.Data.Entities.User;

namespace Openidauth.MVC.Tests
{
    [TestFixture]
    public class UserRepositoryTests
    {
        private IUserRepository repository;

        [SetUp]
        public void Initialize()
        {
            repository = new TestUserRepository();
        }

        [Test]
        public void UserRepository_Returns_5_Users()
        {
            Assert.IsNotNull(repository.GetUsers());
            Assert.AreEqual(5, repository.GetUsers().ToList().Count, "the number of users in the repository is wrong");
        }

        [Test]
        public void UserRepository_Should_Allow_Addition_Of_Users()
        {
            IUser user = new User("min", "Khaja", "Minhajuddin", "http://min.myoid.com", "min@minhajuddin.com", "minhaj");
            repository.AddUser(user);

            Assert.AreEqual(6, repository.GetUsers().ToList().Count, "the count of users is incorrect");
        }

        [Test]
        public void UserRepository_Should_Get_User_By_UserName_UserName4()
        {
            IList<IUser> users = repository.GetUserByUserName("UserName4").ToList();

            Assert.IsNotNull(users, "the get user by username method does not work");
        }

        [Test]
        public void UserRepository_Should_Return_A_Null_When_UserName_Does_Not_Exist()
        {
            IList<IUser> users = repository.GetUserByUserName("Something").ToList();
            Assert.AreEqual(0, users.Count, "the repository returns a user even if it doesn't exist");

        }

    }
}