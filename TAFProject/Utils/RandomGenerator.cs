using System;
using System.Linq;

namespace TAFProject.Utils
{
    public static class RandomGenerator
    {
        public static string GetRandomString(this string message, int length)
        {
            string chars = "wrtpsdfghjklxcvbznm0123456789";
            Random random = new Random();
           // string result = new string(

	        message = Enumerable.Repeat(chars, length)
		        .Select(s => s[random.Next(s.Length)])
		        .ToString();

            return message;
        }
    }
}
