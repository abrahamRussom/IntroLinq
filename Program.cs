using System;

namespace AdvancedCsharp.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            SetupConsoleWindow();
            new LinqAssignement().Run();
            StopAndWaitForUser();
        }

        static public void SetupConsoleWindow()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowWidth = 80;
            Console.WindowHeight = 30;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
        }

        private static void StopAndWaitForUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
