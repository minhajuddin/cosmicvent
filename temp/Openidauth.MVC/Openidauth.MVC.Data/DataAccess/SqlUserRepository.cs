using System.Linq;
using Openidauth.MVC.Data.Entities;

namespace Openidauth.MVC.Data.DataAccess
{
    public class SqlUserRepository : IUserRepository
    {
        private OpenidauthLinqDBDataContext db;

        public SqlUserRepository()
        {
            db = new OpenidauthLinqDBDataContext();
        }

        public IQueryable<IUser> GetUsers()
        {
            return (IQueryable<IUser>) (from user in db.Users
                                        select user).AsQueryable();
        }

        public void AddUser(IUser user)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<IUser> GetUserByUserName(string UserName)
        {
            throw new System.NotImplementedException();
        }
    }
}