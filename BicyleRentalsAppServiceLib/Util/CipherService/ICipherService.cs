using System;
using System.Collections.Generic;
using System.Text;

namespace BicyleRentalsApp
{
    public interface ICipherService
    {
        string Encrypt(string cipherText);
        string Decrypt(string cipherText);
    }
}
