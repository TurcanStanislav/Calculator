using System;

namespace CalculatorApp
{
    internal class InputOperand
    {
        protected static decimal decimalNumber;
        protected static bool isAssigned = false;

        public static decimal Read()
        {
            while (!isAssigned)
            {
                Console.Write("Input first/second operand: ");
                string number = Console.ReadLine();

                UserInterface.ShowMainInterface();

                if (number.Length == 1)
                {
                    NextAction.CheckIfShortcut(Convert.ToChar(number));
                    continue;
                }

                if (number.Contains("."))
                {
                    number = number.Replace('.', ',');
                }
                
                if(number.StartsWith("-00") || number.StartsWith("00") || 
                    number.StartsWith("0") && number.Length > 1)
                {
                    Console.WriteLine("\nYou did not enter the number in the right format");
                    continue;
                }

                try
                {
                    decimalNumber = decimal.Parse(number);
                    isAssigned = true;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("\nYou did not enter anything");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("\nYou did not enter the number in the right format");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("\nYou entered a number out of the range of the decimal type");
                }
            }
            isAssigned = false;
            return decimalNumber;
        }
    }
}
