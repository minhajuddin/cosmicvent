using Openidauth.MVC.Data.DataAccess;

namespace Openidauth.MVC.Service
{

    //The service layer acts as a layre between the repository and the actual code
    public class UserService
    {
        private IUserRepository _repository;

        //Constructors
        public UserService()
        {
        }
        
        //Pass the repository to be used at runtime
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        
    }
}