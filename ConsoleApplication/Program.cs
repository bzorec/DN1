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

            byte[] sortedNumbers = RadixSort(numbers);

            File.WriteAllText("out.txt", string.Join(" ", sortedNumbers));
            Console.WriteLine("Sorted numbers written to out.txt.");
        }

        static byte[] RadixSort(byte[] input)
        {
            byte[] numbers = (byte[]) input.Clone();

            for (int k = 0; k < 8; k++)
            {
                int[] counts = new int[2];
                byte[] output = new byte[numbers.Length];

                foreach (byte number in numbers)
                {
                    byte bit = (byte) ((number >> k) & 1);
                    counts[bit]++;
                }

                counts[1] += counts[0];

                for (int i = numbers.Length - 1; i >= 0; i--)
                {
                    byte bit = (byte) ((numbers[i] >> k) & 1);
                    output[--counts[bit]] = numbers[i];
                }

                numbers = output;
            }

            return numbers;
        }
    }
}