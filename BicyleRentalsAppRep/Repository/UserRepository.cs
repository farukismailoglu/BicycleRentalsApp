using System;
using System.Linq;
using BicyleRentalsApp.Data;
using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Util;

namespace BicyleRentalsApp.Repository
{
    public class UserRepository :IUserRepository
    {
        public User Save(User user)
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();

                context.Users.Add(user);
                context.SaveChanges();
                return user;
            }
            catch(Exception ex)
            {
                throw new RepositoryException("Save user", ex);
            }
        }
        
        public User FindByUsername(string username)
        {
            try
            {
                using var context = new BicycleRentalsAppDbContext();

                return context.Users.FirstOrDefault(u => u.UserName == username);
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Find By Id", ex);
            }
        }

    }
}
