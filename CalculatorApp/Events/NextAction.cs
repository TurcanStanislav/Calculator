using System;

namespace CalculatorApp
{
    internal class NextAction
    {
        protected static char shortcut;
        protected static bool quitApproved = true;
        public static char[] hotkeys = { 'Q', 'N', 'C', 'Z' };

        protected static char ToUpper(char ch)
        {
            string temp = Convert.ToString(ch);
            temp = temp.ToUpper();
            ch = Convert.ToChar(temp);

            return ch;
        }
        public static bool CheckQuit()
        {
            quitApproved = false;
            bool correctAnswer = false;
            
            while (!correctAnswer)
            {
                Console.WriteLine("\nDo you really want to quit from calculator?");
                Console.Write("Write Yes to accept and No to cancel the action:   ");
                
                string[] options = { "YES", "NO" };
                string answer = Console.ReadLine();
                UserInterface.ShowMainInterface();
                answer = answer.ToUpper();

                if (answer.Length == 1 && answer == Convert.ToString('Z'))
                    ChooseAction(Convert.ToChar(answer));
                
                if (answer.Contains(options[0]) == true)
                {
                    quitApproved = true;
                    correctAnswer = true;
                }
                else if (answer.Contains(options[1]) == true)
                {
                    quitApproved = false;
                    correctAnswer = true;
                }
            }

            return quitApproved;
        }
        public static bool CheckIfShortcut(char control)
        {
            bool isShortcut = false;
            control = ToUpper(control);

            switch (control)
            {
                case 'Q':
                    if (CheckQuit() == true)
                        ChooseAction(control);
                    else
                        ReadKey();

                    isShortcut = true;
                    break;
                case 'N':
                    ChooseAction(control);
                    isShortcut = true;
                    break;
                case 'C':
                    ChooseAction(control);
                    isShortcut = true;
                    break;
                case 'Z':
                    ChooseAction(control);
                    isShortcut = true;
                    break;
                default:
                    return isShortcut;
            }

            return isShortcut;
        }

        public static void ReadKey()
        {
            Console.Write("\nPress any available shortcut...  ");
            shortcut = Console.ReadKey().KeyChar;
            shortcut = ToUpper(shortcut);
            Console.WriteLine();
            UserInterface.ShowMainInterface();
            CheckIfShortcut(shortcut);
        }

        protected static void ChooseAction(char control)
        {
            switch (control)
            {
                case 'Q':
                    Environment.Exit(0);
                    break;
                case 'N':
                    Launch.Execute();
                    break;
                case 'C':
                    Console.Write("\nUnavailable feature.");
                    ReadKey();
                    break;
                case 'Z':
                    Console.Clear();
                    if (Launch.calculationFinished == true && quitApproved == true)
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
