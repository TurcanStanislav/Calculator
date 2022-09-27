using System;

namespace CalculatorApp
{
    internal class InputOperand
    {
        protected static decimal decimalNumber;
        protected static bool isAssigned = false;

        public static decimal Read(string ord)
        {
            while (!isAssigned)
            {
                string[] options = { "first", "second" };
                if(ord == options[0])
                    Console.Write($"Input {options[0]} operand: ");
                else Console.Write($"Input {options[1]} operand: ");

                string number = Console.ReadLine();
                number = number.ToUpper();

                UserInterface.ShowMainInterface();

                //decimal zero = 0;
                //if (Launch.Operator() == '/' && ord == "second" && Convert.ToString(number) == Convert.ToString(zero))
                //    continue;

                if (number.Length == 1 && decimal.TryParse(number, out decimal temp) == false)
                {
                    bool isShortcut = false;
                    foreach (char ch in NextAction.hotkeys)
                        if (number == Convert.ToString(ch))
                        {
                            NextAction.CheckIfShortcut(Convert.ToChar(number));
                            isShortcut = true;
                            break;
                        }
                    if(isShortcut) continue;
                }

                if(number == "-" || number == "+")
                {
                    Console.WriteLine("\nYou did not enter the number in the right format");
                    continue;
                }

                if (number.Contains("."))
                {
                    number = number.Replace('.', ',');
                }
                
                if(number.StartsWith("-00") || number.StartsWith("0") && 
                   number.Length > 1 && !number.StartsWith("0,") ||
                   number.Equals("-0") || number.Equals("+0"))
                {
                    Console.WriteLine("\nYou did not enter the number in the right format.");
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

                //if (decimal.TryParse(number, out decimalNumber))
                //{
                //    isAssigned = true;
                //}
                //else Console.WriteLine("Wrong input. Please, try again.");

            }
            isAssigned = false;
            return decimalNumber;
        }
    }
}
