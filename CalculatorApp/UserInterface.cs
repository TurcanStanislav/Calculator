using System;

namespace CalculatorApp
{
    internal class UserInterface
    {
        protected static int cursorXPosition;
        protected static int cursorYPosition;

        public static void ShowMainInterface()
        {
            cursorXPosition = Console.CursorLeft;
            cursorYPosition = Console.CursorTop;

            Console.SetCursorPosition(0, Console.WindowHeight - 5);
            Console.WriteLine("                                              ____________________________");
            Console.WriteLine("                                               | Console Calculator App |");
            Console.WriteLine("      --------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("      Press Q to quit   | Z to clear screen  |  C to continue the previous one  |  N to start a new calculation...  ");
            Console.WriteLine("      --------------------------------------------------------------------------------------------------------------");
            Console.SetCursorPosition(cursorXPosition, cursorYPosition);
        }
        public static void ShowResult(char _operator, decimal operand1, decimal operand2, decimal result)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"{operand1:F3} {_operator:F3} {operand2} = {result:F8}");
            Console.ResetColor();

            
        }
    }
}
