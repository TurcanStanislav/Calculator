using System;

namespace CalculatorApp
{
    internal class InputOperator
    {
        protected static bool validOperator = false;
        protected static char _operator;

        public static char ReadOperator()
        {
            Console.WriteLine("                  Please, choose the operation by inputting its corresponding operator");
            while (!validOperator)
            {
                Console.WriteLine("Operators:      +(addition)   |   -(subtraction)   |   /(division)   |   *(multiplication)");
                Console.Write("Operator: ");
                char op = Console.ReadKey().KeyChar;
                NextAction.CheckIfShortcut(op);

                Console.WriteLine();
                if (CheckOperator(op) == true)
                {
                    _operator = op;
                    break;
                }
            }
            validOperator = false;
            return _operator;
        }

        protected static bool CheckOperator(char _operator)
        {
            switch (_operator)
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
                default:
                    {
                        Console.WriteLine("An unexistent operator. Please, try again.");
                        break;
                    }
            }

            return validOperator;
        }

    }   
}
