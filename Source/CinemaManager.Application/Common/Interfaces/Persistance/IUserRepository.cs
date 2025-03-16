using CinemaManager.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManager.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetUserByEmail(string email);
    }
}
