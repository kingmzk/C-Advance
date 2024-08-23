using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public static class StringExtensions
    {
        public static string Shorten(this string str, int numberOfWords)
        {
            if (numberOfWords <= 0) return "";

            var words = str.Split(' ');

            if (words.Length < numberOfWords) return str;

            return string.Join(" ", words.Take(numberOfWords));
        }
    }
}
