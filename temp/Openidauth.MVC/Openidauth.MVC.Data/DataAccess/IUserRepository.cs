using System.Linq;
using Openidauth.MVC.Data.Entities;

namespace Openidauth.MVC.Data.DataAccess
{
    public interface IUserRepository
    {
        IQueryable<IUser> GetUsers();
        void AddUser(IUser user);
        IQueryable<IUser> GetUserByUserName(string UserName);
    }
}