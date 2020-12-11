using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Windows;

namespace ERPcyber.Model
{
    class Encrypt
    {
        public static string truc(string source)
        {
            // Creates an instance of the default implementation of the MD5 hash algorithm.
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(source);

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                // Output the MD5 hash
                return hash;
            }
        }



    }
}
