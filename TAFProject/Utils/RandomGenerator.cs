using System;
using System.Linq;

namespace TAFProject.Utils
{
    public static class RandomGenerator
    {
        public static string GetRandomString(int length)
        {
            string chars = "wrtpsdfghjklxcvbznm0123456789";
            Random random = new Random();
            string result = new string(
                Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());

            return result;
        }
    }
}
