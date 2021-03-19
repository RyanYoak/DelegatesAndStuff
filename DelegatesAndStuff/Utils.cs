using System;

namespace DelegatesAndStuff.Utilities
{
    public static class Utils
    {
        public static string FormatName(string first, string last) => $"{last}, {first}";

        public static bool IsEven(this int n) => n % 2 == 0;

        public static string MakeTag(this string tag, string content) => $"<{tag}>{content}</{tag}>";

        public static DateTime DaysFromToday(this int days) => DateTime.Now.AddDays(days);
    }
}
