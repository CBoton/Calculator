using CalculatorLibrary.Models;
using System.Security.AccessControl;

namespace CalculatorLibrary
{
    internal class Helpers
    {
        internal static List<Problem> problems = new List<Problem>();

        internal static void PrintProblems()
        { 
            Console.Clear();
            Console.WriteLine("Previous Problems");
            Console.WriteLine("---------------------\n");
            foreach (var problem in problems)
            {
                Console.WriteLine("$ {problem.FirstNumber} {problem.Operand} {problem.SecondNumber} = {problem.Answer}");
            }
        }

        internal static void AddToProblems(double firstNumber, char operand, double secondNumber, double answer)
        {
            problems.Add(new Problem
            {
                FirstNumber = firstNumber,
                Operand = operand,
                SecondNumber = secondNumber,
                Answer = answer
            });
        }
    }
}
