using BicyleRentalsApp.Entities;
using BicyleRentalsApp.Repository;
using BicyleRentalsApp.Util;
using Microsoft.Extensions.DependencyInjection;

namespace BicyleRentalsApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository m_userRepository;
        
        public UserService(IUserRepository userRepository)
        {
            m_userRepository = userRepository;
        }
        public User EncryptPassword(User user)
        {
            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var key = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<CipherService>(key);
            user.Password = locker.Encrypt(user.Password);
            return user;
        }
        public string DecryptPassword(string decryptKey)
        {
            var SCollection = new ServiceCollection();
            SCollection.AddDataProtection();
            var key = SCollection.BuildServiceProvider();
            var locker = ActivatorUtilities.CreateInstance<CipherService>(key);
            return locker.Decrypt(decryptKey);
        }


        public User Add(User user)
        {
            try
            {
                EncryptPassword(user);
                return m_userRepository.Save(user);
            }
            catch (RepositoryException ex)
            {
                throw new ServiceException("Add User", ex.InnerException);

            }
        }

        public User GetUser(User user)
        {
            try
            {
                return m_userRepository.FindByUsername(user.UserName);
            }
            catch (RepositoryException ex)
            {

                throw new ServiceException("Get User", ex.InnerException);
            }
            
        }
        
        public User CheckPassword(User user)
        {
            try
            {
                var _user = GetUser(user);
                return DecryptPassword(_user.Password) == user.Password ? _user : null;
            }
            catch (RepositoryException ex)
            {

                throw new ServiceException("Check User", ex.InnerException);
            }
        }
    }
}
