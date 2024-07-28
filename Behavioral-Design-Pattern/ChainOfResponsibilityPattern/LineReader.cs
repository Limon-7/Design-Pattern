using System;
namespace ChainOfResponsibilityPattern
{
    public static class LineReader
    {
        public static void ReadLines()
        {
            while (true)
            {

                try
                {
                    TheGreatDivider.MaxIntDividedBy(Console.ReadLine());
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Enter a valid number::");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"caught::{ex.Message}");
                }
            }
        }
    }
    public static class TheGreatDivider
    {
        public static void MaxIntDividedBy(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Nothing Entered::");
            Console.WriteLine(int.MaxValue / int.Parse(number));
        }
    }
}