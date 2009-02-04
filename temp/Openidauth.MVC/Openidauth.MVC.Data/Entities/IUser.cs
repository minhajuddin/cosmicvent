using System;

namespace Openidauth.MVC.Data.Entities
{
    public interface IUser
    {
        int ID { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; }
        string Password { get; }
        string UserName { get; set; }
        string OpenIDUrl { get; }
        DateTime CreatedOn { get; set; }
        DateTime LastActivity { get; set; }
    }
}