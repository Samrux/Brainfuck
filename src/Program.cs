using System;
using System.Text;
using static Brainfuck.Brainfuck;

namespace Brainfuck
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a Brainfuck program and its input separated by an exclamation mark: ");
                var userInput = new StringBuilder();
                var line = Console.ReadLine();
                while (!string.IsNullOrWhiteSpace(line))
                {
                    userInput.AppendLine(line);
                    line = Console.ReadLine();
                }

                var slice = userInput.ToString().Trim().Split('!', 2);
                string program = slice[0];
                string programInput = slice.Length > 1 ? slice[1] : "";

                try {  Console.WriteLine(new Brainfuck(program, programInput).Run()); }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.GetType().Name}: {e.Message}");
                    if (e.InnerException != null) Console.WriteLine($"Inner exception: {e.InnerException}");
                    if (e is BrainfuckException be) Console.WriteLine($"Memory at the point of exception: {be.Memory}");
                }

                Console.WriteLine();
            }
        }
    }
}
