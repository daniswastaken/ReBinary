using System;
using System.Linq;

namespace binaryToDecimal
{
    class Program
    {
        static void Main()
        {
            // Choosing what to convert
            while (true) // Loop until the user chooses to exit
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Binary to Decimal");
                Console.WriteLine("2. Decimal to Binary");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice (1, 2, or 3): ");
                string? choice = Console.ReadLine()?.Trim() ?? string.Empty;

                // Checking if the user input is number or not
                if (!choice.All(c => c == '1' || c == '2' || c == '3'))
                {
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                }


                switch (choice)
                {
                    case "1":
                        BinaryToDecimalConverter();
                        break;
                    case "2":
                        DecimalToBinaryConverter();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program.");
                        return; // Exit the program
                }

                Console.WriteLine(); // Blank line for readability
            }
        }

        static void BinaryToDecimalConverter()
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
        static void DecimalToBinaryConverter()
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

