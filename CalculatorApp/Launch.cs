using System;

namespace CalculatorApp
{
    class Launch
    {
        private static decimal operand1;
        private static decimal operand2;
        private static char _operator;
        private static decimal result;
        private static bool finishedCalculation;

        static bool CheckIfShortcut(char ch)
        {
            bool isShortcut = false;

            switch (ch)
            {
                case 'Q':
                    isShortcut = true;
                    break;
                case 'N':
                    isShortcut = true;
                    break;
                case 'C':
                    isShortcut = true;
                    break;
                case 'Z':
                    isShortcut = true;
                    break;
                default:
                    break;
            }

            return isShortcut;
        }
        static void CheckIfNextAction(char ch)
        {
            string temp = Convert.ToString(ch);
            temp = temp.ToUpper();
            ch = Convert.ToChar(temp);

            if (CheckIfShortcut(ch) == true)
                NextAction(ch);
        }
        static void NextAction(char control)
        {
            const char NORMAL_MODE = '0';
  
            string temp = Convert.ToString(control);
            temp = temp.ToUpper();
            control = Convert.ToChar(temp);

            switch (control)
            {
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'N':
                    Console.Clear();
                    RunUserInterface(NORMAL_MODE);
                    break;
                case 'C':
                    RunUserInterface(control);
                    break;
                case 'Z':
                    Console.Clear();
                    UserInterface();
                    if (finishedCalculation == true) RunUserInterface('0');
                    return;
                default:
                    Console.WriteLine("Invalid key. Please, try again");
                    NextAction(Console.ReadKey().KeyChar);
                    break;
            }
        }
        static decimal CalculateResult(char _operator, decimal operand1, decimal operand2)
        {
            decimal result = 0;

            switch (_operator)
            {
                case '+':
                    {
                        result = operand1 + operand2;
                        break;
                    }
                case '-':
                    {
                        result = operand1 - operand2;
                        break;
                    }
                case '*':
                    {
                        result = operand1 * operand2;
                        break;
                    }
                case '/':
                    {
                        result = operand1 / operand2;
                        break;
                    }
                case '%':
                    {
                        result = operand1 % operand2;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Something went wrong, please, try again");
                        break;
                    }
            };


            return result;
        }
        static decimal ReadOperand(string ord)
        {
            decimal decimalNumber = 0;
            string[] order = { "first", "second" };
            bool isAssigned = false;

            while (!isAssigned)
            {
                if (ord == order[0])
                    Console.Write("\nIntroduce the first operand: ");
                else Console.Write("\nIntroduce the second operand: ");

                string number = Console.ReadLine();
                if (number.Length == 1)
                    CheckIfNextAction(Convert.ToChar(number));
                if (number.Contains("."))
                {
                    number = number.Replace('.', ',');
                }

                try
                {
                    decimalNumber = decimal.Parse(number);
                    isAssigned = true;
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine("You did not enter anything");
                }
                catch (FormatException e)
                {
                    Console.WriteLine("You did not enter the number in the right format");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("You entered a number out of the range of the decimal type");
                }
            }
            return decimalNumber;
        }
        static bool CheckOperator(char op)
        {
            bool validOperator = false;

            switch (op)
            {
                case '+':
                    {
                        validOperator = true;
                        break;
                    }
                case '-':
                    {
                        validOperator = true;
                        break;
                    }
                case '*':
                    {
                        validOperator = true;
                        break;
                    }
                case '/':
                    {
                        validOperator = true;
                        break;
                    }
                case '%':
                    {
                        validOperator = true;
                        break;
                    }
                default:
                    {
                        if(CheckIfShortcut(op) == false)
                            Console.WriteLine("\nAn unexistent operator. Please, try again.");
                        break;
                    }
            };

            return validOperator;
        }
        static void UserInterface()
        {
            Console.WriteLine("                                      ____________________________");
            Console.WriteLine("                                       | Console Calculator App |");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Press Q to quit   | Z to clear screen  |  C to continue the previous one  |  N to start a new calculation...  ");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("                  Please, choose the operation by inputting its corresponding operator");
        }
        static void RunUserInterface(char control)
        {
            finishedCalculation = false;
            UserInterface();

            bool validOperator = false;

            do
            {
                Console.WriteLine("Operators:  +(addition)  -(subtraction)  /(division)  *(multiplication)  %(remainder)");
                Console.Write("Operator: ");
                char op = Console.ReadKey().KeyChar;
                CheckIfNextAction(op);

                validOperator = CheckOperator(op);
                if (validOperator) _operator = op;
            } while (!validOperator);

            if (control != 'C')
                operand1 = ReadOperand("first");

            else operand1 = result;

            operand2 = ReadOperand("second");

            result = CalculateResult(_operator, operand1, operand2);

            Console.WriteLine($"{operand1:F3} {_operator:F3} {operand2} = {result:F8}");
            finishedCalculation = true;
            NextAction(Console.ReadKey().KeyChar);
        }
        static void Main(string[] args)
        {
            RunUserInterface('0');
        }
    }
}
