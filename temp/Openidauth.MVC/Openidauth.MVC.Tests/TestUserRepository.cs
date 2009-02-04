using System.Collections.Generic;
using System.Linq;
using Openidauth.MVC.Data.DataAccess;
using Openidauth.MVC.Data.Entities;
using User=Openidauth.MVC.Data.Entities.User;

namespace Openidauth.MVC.Tests
{
    public class TestUserRepository : IUserRepository
    {
        private IList<IUser> result;

        //Sets up the user repository
        public TestUserRepository()
        {
            result = new List<IUser>();

            for (int i = 1; i < 6; i++)
            {
                IUser user = new User
                                 {
                                     UserName = ("UserName" + i),
                                     FirstName = ("FirstName" + i),
                                     LastName = ("LastName" + i),
                                     Email = ("Email" + i),
                                     OpenIDUrl = ("Openid" + i),
                                     Password = ("Password" + i)
                                 };
                result.Add(user);
            }

        }


        public IQueryable<IUser> GetUsers()
        {
            return result.AsQueryable();
        }

        public void AddUser(IUser user)
        {
            result.Add(user);
        }

        public IQueryable<IUser> GetUserByUserName(string userName)
        {
            return (from user in result
                    where user.UserName == userName
                    select user).AsQueryable();
        }
    }
}