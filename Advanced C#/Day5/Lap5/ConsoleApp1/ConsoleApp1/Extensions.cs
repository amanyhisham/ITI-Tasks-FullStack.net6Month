using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lap5AdvancedC
{
    public static class Extensions
    {
        // 1. Email validation
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }

        //  2. Above average numbers
        public static IEnumerable<int> GetAboveAverage(this IEnumerable<int> numbers)
        {
            if (numbers == null || !numbers.Any())
                return new List<int>();

            double avg = numbers.Average();

            return numbers.Where(n => n > avg);
        }

        // 3. Friendly Date
        public static string ToFriendlyDate(this DateTime date)
        {
            DateTime today = DateTime.Today;

            if (date.Date == today)
                return "Today";

            if (date.Date == today.AddDays(-1))
                return "Yesterday";

            if (date.Date == today.AddDays(1))
                return "Tomorrow";

            return date.ToString("dd/MM/yyyy");
        }
    }
}