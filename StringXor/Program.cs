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
                var jumbled = jumble(input);
                Console.WriteLine($"Jumbled: {jumbled}");

                var original = jumble(jumbled);
                Console.WriteLine($"Original: {original}");

                Console.ReadLine();
            }
        }

        static string jumble(string input)
        {
            var result = "";
            var xorResult = xor(input);

            result += input[0];

            do
            {
                result += xorResult[0];
                xorResult = xor(xorResult);
            }
            while (xorResult.Length > 1);

            result += xorResult;

            return result;
        }

        static string xor(string input)
        {
            var chars = input.ToCharArray();
            var result = new char[chars.Length - 1];

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = (char)(chars[i] ^ chars[i + 1]);
            }

            return new string(result);
        }
    }
}
