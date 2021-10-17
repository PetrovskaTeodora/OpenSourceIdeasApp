using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User GetByLogInInfo(string email, string password);
        User GetByEmail(string email);
        int Insert(User user);
        int Update(User user);
        int Delete(User user);
    }
}
