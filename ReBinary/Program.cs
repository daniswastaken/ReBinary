using System;
using System.Linq;

namespace ReBinary
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter binary number:");
            string? input = Console.ReadLine()?.Trim() ?? string.Empty;

            // Checking if the user input is number or not
            if (!input.All(c => c == '0' || c == '1'))
            {
                Console.WriteLine("Invalid input. Please enter a binary number (only 0s and 1s).");
                return;
            }

            int result = input.Reverse()
                .Select((c, i) => (c - '0') * (1 << i))
                .Sum();

            Console.WriteLine($"Decimal value: {result}");
        }
    }
}