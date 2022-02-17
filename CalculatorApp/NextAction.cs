using System;

namespace CalculatorApp
{
    internal class NextAction
    {
        protected static char shortcut;

        protected static char ToUpper(char ch)
        {
            string temp = Convert.ToString(ch);
            temp = temp.ToUpper();
            ch = Convert.ToChar(temp);

            return ch;
        }

        public static void CheckIfShortcut(char control)
        {
            control = ToUpper(control);

            switch (control)
            {
                case 'Q':
                    ChooseAction(control);
                    break;
                case 'N':
                    ChooseAction(control);
                    break;
                case 'C':
                    ChooseAction(control);
                    break;
                case 'Z':
                    ChooseAction(control);
                    break;
                default:
                    return;
            }
        }

        public static void ReadKey()
        {
            Console.WriteLine("\nPress any available shortcut... ");
            shortcut = Console.ReadKey().KeyChar;
            shortcut = ToUpper(shortcut);

            ChooseAction(shortcut);
        }

        protected static void ChooseAction(char control)
        {
            var l = new Launch();

            switch (control)
            {
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'N':
                    Launch.Execute();
                    break;
                case 'C':
                    Console.WriteLine("Unavailable feature.");
                    ReadKey();
                    break;
                case 'Z':
                    Console.Clear();
                    if (Launch.calculationFinished == true)
                    {
                        UserInterface.ShowMainInterface();
                        ReadKey();
                    }
                    else 
                        UserInterface.ShowMainInterface();
                    return;
                default:
                    Console.WriteLine("Invalid key. Please, try again: ");
                    ReadKey();
                    break;
            }
        }
    }
}
