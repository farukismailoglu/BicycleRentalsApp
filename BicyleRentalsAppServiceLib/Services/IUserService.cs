using System;
using System.Collections.Generic;
using System.Text;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Repository;

namespace BicyleRentalsApp.Services
{
    public interface IUserService : IBaseService
    {
        public User Add(User user);

        public User GetUser(User user);
        public User CheckPassword(User user);
    }
}
