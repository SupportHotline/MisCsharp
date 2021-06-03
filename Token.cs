using System;
using System.Linq;

namespace SupportHotline
{
    static class Token
    {
        static string CreateUniqueToken()
        {
            byte[] time = BitConverter.GetBytes(DateTime.Now.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            return Convert.ToBase64String(time.Concat(key).ToArray());
        }

        static DateTime GetTokenCreationTime(string token)
        {
            byte[] data = Convert.FromBase64String(token);
            return DateTime.FromBinary(BitConverter.ToInt64(data, 0));
        }
    }
}
