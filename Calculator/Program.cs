using CalculatorLibrary;
using System.Text.RegularExpressions;

namespace CalculatorProgram
{

    class Program
    {
        static void Main(string[] args)
        {
            int timesUsed = 0;
            bool endApp = false;
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            Calculator calculator = new Calculator();
            while (!endApp)
            {
                double result = 0;

                Helpers.PrintMenu();
                
                string? op = Console.ReadLine();
                if (op == "l")
                {
                    Helpers.PrintProblems();
                }
                else if (op == "c")
                {
                    Helpers.ClearProblems();
                    Helpers.PrintProblems();
                }
                else if (op == null || !Regex.IsMatch(op, "[a|s|m|d]"))
                {
                    Console.WriteLine("Error: Unrecognized input.");
                }
                
                if (Regex.IsMatch(op, "[a|s|m|d]"))
                {
                    double cleanNum1 = Helpers.GetNumber();

                    double cleanNum2 = Helpers.GetNumber();
                    try
                    {
                        result = calculator.DoOperation(cleanNum1, op, cleanNum2);
                           if (double.IsNaN(result))
                           {
                                Console.WriteLine("This operation will result in a mathematical error.\n");
                           }
                           else
                           {
                                Console.WriteLine("Your result: {0:0.##}\n", result);
                                timesUsed++;
                                Console.WriteLine($"You have used the calculator {timesUsed} times.");
                           }
                    }
                        catch (Exception e)
                        {
                            Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                        }
                } 
                Console.WriteLine("------------------------\n");

                Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;
                
                Console.WriteLine("\n"); 
            }
            calculator.Finish();
            return;
        }
    }
}