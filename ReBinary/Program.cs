using System;
using System.Linq;

namespace binaryToDecimal
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

namespace decimalToBinary
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter decimal number:");
            string decimalNumberInput = Console.ReadLine()?.Trim() ?? string.Empty;

            // Validate and convert input to int
            if (!int.TryParse(decimalNumberInput, out int decimalNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
                return;
            }

            // Method to convert decimal to binary
            string binary = DecimalToBinary(decimalNumber);

            // Output the binary representation
            Console.WriteLine($"Binary representation of {decimalNumber} is: {binary}");
        }

        // Converting from decimal to binary
        static string DecimalToBinary(int decimalNumber)
        {
            // Edge case for 0
            if (decimalNumber == 0)
            {
                return "0";
            }

            // Initialize variables
            string binary = "";
            int remainder;

            // Loop through the conversion process
            while (decimalNumber > 0)
            {
                remainder = decimalNumber % 2;      // Get the remainder (0 or 1)
                binary = remainder + binary;        // Prepend the remainder to the result
                decimalNumber = decimalNumber / 2;  // Divide the number by 2
            }

            return binary;
        }
    }
}
