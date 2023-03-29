using System;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: dn1 <input_file>");
                return;
            }

            string inputFilePath = args[0];
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            string[] inputNumbers = File.ReadAllText(inputFilePath).Split(' ');
            byte[] numbers = inputNumbers.Select(byte.Parse).ToArray();
        }
    }
}