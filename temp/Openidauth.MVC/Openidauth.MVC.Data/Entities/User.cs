using System;

namespace Openidauth.MVC.Data.Entities
{
    public class User : IUser
    {
        public User(string userName, string firstName, string lastName, string openIDUrl, string email, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            OpenIDUrl = openIDUrl;
            Email = email;
            Password = password;
        }

        public User()
        {}


// ReSharper disable UnusedAutoPopertyAccessor
        public int ID { get; private set; }
// ReSharper restore UnusedAutoPopertyAccessor
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string OpenIDUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastActivity { get; set; }
    }
}