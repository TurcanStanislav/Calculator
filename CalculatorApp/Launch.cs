using System;
using System.Runtime.InteropServices;

namespace CalculatorApp
{
    class Launch
    {
        const int MF_BYCOMMAND = 0x00000000;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        const int SC_SIZE = 0xF000;

        protected static char _operator;
        protected static decimal operand1;
        protected static decimal operand2;
        protected static decimal result;
        internal static bool calculationFinished;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static void Execute()
        {
            calculationFinished = false;
            Console.Clear();
            UserInterface.ShowMainInterface();
            _operator = InputOperator.ReadOperator();
            operand1 = InputOperand.Read("first");
            operand2 = InputOperand.Read("second");

            result = Operation.Calculate(_operator, operand1, operand2);
            UserInterface.ShowResult(_operator, operand1, operand2, result);
            calculationFinished = true;
            NextAction.ReadKey();
        }
        public static decimal FirstOperand()
        {
            return operand1;
        }
        public static decimal SecondOperand()
        {
            return operand2;
        }
        public static char Operator()
        {
            return _operator;
        }
        protected static void FixedWindow()
        {
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MINIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(GetSystemMenu(GetConsoleWindow(), false), SC_SIZE, MF_BYCOMMAND);
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(122, 30);
            FixedWindow();
            Execute();
        }
    }
}
