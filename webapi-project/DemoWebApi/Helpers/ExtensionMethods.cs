using System;
using System.Security.Cryptography;
using System.Text;
using DemoWebApi.Models;

namespace DemoWebApi.Helpers
{
    public static class ExtensionMethods
    {
        public static string GetHashMarvelApi(this AppSettingJson setting, string ticks) {

         var  bytes = Encoding.UTF8.GetBytes(ticks + setting.PrivateKey + setting.PublicKey);
        
         var gerador = MD5.Create();

         var bytesHash = gerador.ComputeHash(bytes);

         return BitConverter.ToString(bytesHash).ToLower().Replace("-", string.Empty);

        }

    }
}