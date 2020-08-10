using System;
using System.Collections.Generic;
using System.Text;
using BicyleRentalsApp.Entities;

namespace BicyleRentalsApp.Repository
{
    public interface IUserRepository
    {
        User Save(User user);

        User FindByUsername(string username);
    }
}
