using System;
using MbUnit.Framework;
using Openidauth.MVC.Data.Entities;

namespace Openidauth.MVC.Tests
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        public void User_Should_Have_UserName_FirstName_LastName_OpenIDUrl_Email_And_Password_CreatedOn_LastActivity_Fields()
        {
            IUser user = new User("min", "Khaja", "Minhajuddin", "http://min.myoid.com", "min@minhajuddin.com", "minhaj");
            user.CreatedOn = DateTime.Now.Date;
            user.LastActivity = DateTime.Now.Date;

            Assert.AreEqual("min", user.UserName, "the user name is wrong");
            Assert.AreEqual("http://min.myoid.com", user.OpenIDUrl, "the openID url is wrong");
            Assert.AreEqual("Khaja", user.FirstName, "the first name is wrong");
            Assert.AreEqual("Minhajuddin", user.LastName, "the last name is wrong");
            Assert.AreEqual("min@minhajuddin.com", user.Email, "the email address is wrong");
            Assert.AreEqual("minhaj", user.Password, "the password is wrong");
            Assert.AreEqual(DateTime.Now.Date, user.CreatedOn, "the created on property is set wrong");
            Assert.AreEqual(DateTime.Now.Date, user.LastActivity, "the last activity property is set wrong");
        }

    }
}