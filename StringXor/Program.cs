using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringXor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");

            var input = Console.ReadLine();

            if (input.Length > 1)
            {
                var jumbled = input.Xor();
                Console.WriteLine($"Jumbled: {jumbled}");

                var original = jumbled.Xor();
                Console.WriteLine($"Original: {original}");

                Console.ReadLine();
            }
        }
    }
}
