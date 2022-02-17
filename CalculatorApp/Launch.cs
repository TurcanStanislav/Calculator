using System;

namespace CalculatorApp
{
    class Launch
    {
        protected static char _operator;
        protected static decimal operand1;
        protected static decimal operand2;
        protected static decimal result;
        internal static bool calculationFinished; 

        public static void Execute()
        {
            calculationFinished = false;
            Console.Clear();
            UserInterface.ShowMainInterface();
            _operator = InputOperator.ReadOperator();
            operand1 = InputOperand.Read();
            operand2 = InputOperand.Read();

            result = Operation.Calculate(_operator, operand1, operand2);
            UserInterface.ShowResult(_operator, operand1, operand2, result);
            calculationFinished = true;
            NextAction.ReadKey();
        }

        static void Main(string[] args)
        {
            Execute();
        }
    }
}
