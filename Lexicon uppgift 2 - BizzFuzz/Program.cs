using System.Numerics;

namespace Lexicon_uppgift_2___BizzFuzz
{
    internal class Program
    {
        static void Main(string[] args) // HEJ
        {
            string? choice;

            do
            {
                Console.WriteLine("\nSelect program:");
                Console.WriteLine("1: FizzBuzz");
                Console.WriteLine("2: BizzFuzz");
                Console.WriteLine("Other: Quit");

                switch (choice = Console.ReadLine())
                {
                    case "1":
                        FizzBuzz();
                        break;
                    case "2":
                        BizzFuzz();
                        break;
                    default:
                        choice = null;
                        break;
                }
            }while(choice != null);

            Console.WriteLine("\nGoodbye!");
        }

        static void FizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void BizzFuzz()
        {
            long from, to, firstNumber, secondNumber, numberCounter=0;
            const long limit = 1_000_000_000_000_000_000;
            
            from = ReadLongInput("Select from:", 1, limit, "From must be between 1-10^18. Try again.");  
            to = ReadLongInput("Select to:", from, limit, "To must be equal to or larger than from, and max 10^18. Try again.");
            firstNumber = ReadLongInput("Select first number:", 1, to, "First number must be between 1 and to. Try again.");
            secondNumber = ReadLongInput("Select second number:", 1, to, "Second number must be between 1 and to. Try again.");

            Console.WriteLine("");

            for (long i = from; i <= to; i++)
            {
                if (i % firstNumber == 0 && i% secondNumber == 0)
                {
                    numberCounter++;
                    //Console.Write(i + " ");
                }
            }

            Console.WriteLine($"Between {from}-{to} there are {numberCounter} numbers divisible by both {firstNumber} and {secondNumber}");
        }

        static long ReadLongInput(string prompt, long min, long max, string errorMessage)
        {
            long value;
            while (true)  //Evighetsloop tills inmatat värde är korrekt
            {
                Console.WriteLine(prompt);
                if (long.TryParse(Console.ReadLine(), out value) && value >= min && value <= max)
                 return value;
                Console.WriteLine(errorMessage);
            }
        }
    }
}
