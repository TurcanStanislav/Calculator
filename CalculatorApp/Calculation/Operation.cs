using System;

namespace CalculatorApp
{
    internal class Operation
    {
        protected static decimal resultOfOperation;

        public static decimal Calculate(char _operator, decimal operand1, decimal operand2)
        {
            try
            {
                switch (_operator)
                {
                    case '+':
                        {
                            resultOfOperation = operand1 + operand2;
                            break;
                        }
                    case '-':
                        {
                            resultOfOperation = operand1 - operand2;
                            break;
                        }
                    case '*':
                        {
                            resultOfOperation = operand1 * operand2;
                            break;
                        }
                    case '/':
                        {
                            resultOfOperation = operand1 / operand2;
                            break;
                        }
                    default:
                        {
                            break;
                        }
                };
            }
            catch(OverflowException e)
            {
                Console.WriteLine("The result is out of the bounds of decimal type");
            }

            return resultOfOperation;
        }
        public static decimal Calculate(string operation, decimal value)
        {
            switch (operation)
            {
                case "rad":
                    {
                        resultOfOperation = (decimal)Math.Sqrt((double) value);
                        break;
                    }
                default:
                    {
                        break;
                    }
            };

            return resultOfOperation;
        }
    }
}
