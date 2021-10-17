using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OpenSourceIdeasDbContext _context;
        public UserRepository(OpenSourceIdeasDbContext context)
        {
            _context = context;
        }
        

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(Guid id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByLogInInfo(string email, string password)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }
        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email );

        }
        public int Insert(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChanges();
        }

        public int Update(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser == null) return -1;

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;

            _context.Users.Update(existingUser);
            return _context.SaveChanges();

        }

        public int Delete(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (existingUser == null) return -1;

            _context.Remove(existingUser);

            return _context.SaveChanges();

        }
    }
}
