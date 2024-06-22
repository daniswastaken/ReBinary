using System;
using System.Linq;

namespace ReBinary
{
    class Program
    {
        static void Main()
        {
            string number = "11111";
            int result = number.Reverse()
                .Select((c, i) => (c - '0') * (1 << i))
                .Sum();

            Console.WriteLine(result);
        }
    }
}