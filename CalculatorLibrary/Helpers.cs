﻿using CalculatorLibrary.Models;

namespace CalculatorLibrary
{
    public class Helpers
    {
        internal static List<Problem> problems = new List<Problem>();

        public static void PrintProblems()
        { 
            Console.Clear();
            Console.WriteLine("Previous Problems");
            Console.WriteLine("---------------------\n");
            int counter = 0;
            for (int i = 0; i < problems.Count; i++)
            {
                if (problems[i].Operation == '\u221A')
                {
                    Console.WriteLine($"{counter + 1}.  {problems[i].Operation} {problems[i].FirstNumber} = {problems[i].Answer}");
                    counter++;
                }
                else
                {
                    Console.WriteLine($"{counter + 1}. {problems[i].FirstNumber} {problems[i].Operation} {problems[i].SecondNumber} = {problems[i].Answer}");
                    counter++;
                }
            }
        }
        public static void ClearProblems()
        {
            problems.Clear();
        }

        internal static void AddToProblems(char operation, double firstNumber,  double answer)
        {
            problems.Add(new Problem
            {
                Operation = operation,
                FirstNumber = firstNumber,
                Answer = answer
            });
        }
        internal static void AddToProblems(double firstNumber, char operation, double secondNumber, double answer)
        {
            problems.Add(new Problem
            {
                FirstNumber = firstNumber,
                Operation = operation,
                SecondNumber = secondNumber,
                Answer = answer
            });
        }
        public static double GetNumber()
        {
            string? choice;
            string? numInput;
            if (problems.Count == 0)
            {
                Console.Write("Type a number, and then press Enter: ");
                numInput = Console.ReadLine();
                double cleanNum = 0;
                while (!double.TryParse(numInput, out cleanNum))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput = Console.ReadLine();
                }
                return cleanNum;
            }
            else
            {
                Console.WriteLine("Press 'n' to enter a number or 'l' to use a previous problem");
                choice = Console.ReadLine();
                while (choice != "n" && choice != "l")
                {
                    Console.WriteLine("Press 'n' to enter a number or 'l' to use a previous problem");
                    choice = Console.ReadLine();
                }
                if (choice == "n")
                {
                    Console.Write("Type a number, and then press Enter: ");
                    numInput = Console.ReadLine();

                    double cleanNum = 0;
                    while (!double.TryParse(numInput, out cleanNum))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput = Console.ReadLine();
                    }
                    return cleanNum;
                }
                else
                {
                    PrintProblems();
                    Console.WriteLine("Which problem would you like to use?");
                    numInput = Console.ReadLine();
                    double cleanNum = 0;
                    while (!double.TryParse(numInput, out cleanNum))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput = Console.ReadLine();
                    }
                    while (cleanNum < 1 || cleanNum > problems.Count)
                    {
                        Console.Write("Invalid choice, select a number from the list");
                        numInput = Console.ReadLine();
                    }
                    int selection = int.Parse(numInput);
                    cleanNum = problems[selection - 1].Answer;
                    return cleanNum;
                }
            }
        }
        public static void PrintMenu()
        {
            Console.WriteLine("Choose an operator from the following list:");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\ts - Subtract");
            Console.WriteLine("\tm - Multiply");
            Console.WriteLine("\td - Divide");
            Console.WriteLine("\te - Exponent");
            Console.WriteLine("\tr - Square Root");
            Console.WriteLine("\tl - List previous problems");
            Console.WriteLine("\tc - Clear previous problems");
            Console.Write("Your option? ");
        }
    }
}
