using System;

namespace CalculatorApp
{
    class Launch
    {
        private static decimal operand1;
        private static decimal operand2;
        private static char _operator;
        private static decimal result;


        static void NextAction()
        {
            char control;
            const char NORMAL_MODE = '0';

            Console.WriteLine("Press A to continue, Q to quit, Z to clear screen, C to continue the previous one, N to start a new calculation...");
            control = Console.ReadKey().KeyChar;
            string temp = Convert.ToString(control);
            temp = temp.ToUpper();
            control = Convert.ToChar(temp);

            switch (control)
            {
                case 'A':
                    return;
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'N':
                    RunUserInterface(NORMAL_MODE);
                    break;
                case 'C':
                    RunUserInterface(control);
                    break;
                case 'Z':
                    Console.Clear();
                    RunUserInterface(NORMAL_MODE);
                    break;
                default:
                    Console.WriteLine("Invalid key. Please, try again");
                    NextAction();
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
                NextAction();
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
                        Console.WriteLine("An unexistent operator. Please, try again.");
                        NextAction();
                        break;
                    }
            };

            return validOperator;
        }
        static void RunUserInterface(char control)
        {
            Console.WriteLine("\n----------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Please, choose the operation by inputting its corresponding operator");

            bool validOperator = false;

            do
            {
                Console.WriteLine("Operators:  +(addition)  -(subtraction)  /(division)  *(multiplication)  %(remainder)");
                Console.Write("Operator: ");
                char op = Console.ReadKey().KeyChar;
                Console.WriteLine("\n");

                validOperator = CheckOperator(op);
                if (validOperator) _operator = op;
            } while (!validOperator);

            if (control != 'C')
                operand1 = ReadOperand("first");

            else operand1 = result;

            operand2 = ReadOperand("second");

            result = CalculateResult(_operator, operand1, operand2);

            Console.WriteLine($"{operand1:F3} {_operator:F3} {operand2} = {result:F8}");
            NextAction();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("                                        Console Calculator App");
            RunUserInterface('0');
        }
    }
}
