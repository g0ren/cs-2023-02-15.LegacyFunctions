using System.Globalization;

namespace LegacyFunctions
{
    class Program
    {

        static void HelloWorld()
        {
            WinApi.MessageBox(IntPtr.Zero, "Hello, world!", "Hello", 0);
        }


        static void GameOfNumbers()
        {
            var random = new Random();
            int command = 0;
            int x = 0;
            int y = 0;

            while (true)
            {
                while (command != 6 && command != 2)
                {
                    x = random.Next(100);
                    command = WinApi.MessageBox(IntPtr.Zero,
                        $"Do you want to think of number {x}?",
                        "Game of numbers", 3);
                    // yes == 6
                    // no == 7
                    // cancel == 2
                    if (command == 2)
                    {
                        return;
                    }
                }

                y = random.Next(100);
                if (x == y)
                {
                    command = WinApi.MessageBox(IntPtr.Zero,
                            $"I've guessed your number {x}!\nDo you want to play again?",
                            "Game of numbers", 1);
                }
                else
                {
                    command = WinApi.MessageBox(IntPtr.Zero,
                    $"I've guessed number {y}, you thought of {x}!\nDo you want to play again?",
                    "Game of numbers", 1);
                }

                // ok == 1
                // cancel == 2
                if (command == 2)
                {
                    return;
                }
            }
        }

        static void KillNotepad()
        {
            //Console.WriteLine(WinApi.GetWindowClassName(WinApi.FindWindowByWindowName("Untitled - Notepad")));
            //className == "Notepad"
            WinApi.SendQuitMessage(WinApi.FindWindowByClassName("Notepad"));
        }

        static void SetCurrentTimeAsNotepadHeader()
        {
            while (WinApi.FindWindowByClassName("Notepad")>0)
            {
                
                WinApi.SetWindowText(
                    (IntPtr)(WinApi.FindWindowByClassName("Notepad")),
                    DateTime.Now.ToString("hh:mm:ss", CultureInfo.CurrentCulture));
                Thread.Sleep(1000);
            }
        }

        public static void Main(string[] args)
        {
            int command = 0;
            while (true)
            {
                Console.WriteLine("Enter your command");
                Console.WriteLine("1. Hello World");
                Console.WriteLine("2. Game of numbers");
                Console.WriteLine("3. Close Notepad window");
                Console.WriteLine("4. Set header of Notepad window to system time (and update it every second until you close it)");
                Console.WriteLine("0. Exit");

                command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        HelloWorld();
                        break;
                    case 2:
                        GameOfNumbers();
                        break;
                    case 3:
                        KillNotepad();
                        break;
                    case 4:
                        SetCurrentTimeAsNotepadHeader();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Wrong Command");
                        break;
                }
                
            }
        }
    }
}