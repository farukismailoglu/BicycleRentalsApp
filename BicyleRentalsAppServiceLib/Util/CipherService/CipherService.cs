using System;
using System.Security.Permissions;
using Microsoft.AspNetCore.DataProtection;

namespace BicyleRentalsApp
{
    public class CipherService : ICipherService
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private const string Key = "Faruk";

        public CipherService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtectionProvider = dataProtectionProvider;
        }

        public string Decrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Unprotect(input);
        }

        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(Key);
            return protector.Protect(input);
        }
    }
}
