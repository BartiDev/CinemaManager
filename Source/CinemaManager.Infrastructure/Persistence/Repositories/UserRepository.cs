using CinemaManager.Application.Common.Interfaces.Persistance;
using CinemaManager.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManager.Application.Authentication.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.FirstOrDefault(u => u.Email == email);
        }
    }
}
