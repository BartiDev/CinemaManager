using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManager.Domain.User
{
    public sealed class User
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime CreatedTime { get; private set; }
        public DateTime UpdateTime { get; private set; }


        private User(int id,
            string firstName,
            string lastName,
            string password,
            string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            CreatedTime = DateTime.Now;
            UpdateTime = DateTime.Now;
        }

        public static User CreateUser(string firstName,
            string lastName,
            string email,
            string password)
        {
            return new User(id: 0, 
                firstName, 
                lastName, 
                email, 
                password);
        }
    }
}
