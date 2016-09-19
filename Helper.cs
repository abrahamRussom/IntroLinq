namespace AdvancedCsharp.Linq
{
    using System;
    using System.Collections;

    static class Helper
    {

        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public static void Header(string header)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"---- {header} ----");
        }

        public static void DisplayList(IEnumerable list)
        {
            if (list == null)
            {
                Console.WriteLine("Listan är tom");
            }

            foreach (var x in list)
            {

                Console.WriteLine(x);
            }

        }


        public static void DisplayList2(IEnumerable list)
        {
            if (list == null)
            {
                Console.WriteLine("Listan är tom");
            }

            foreach (var x in list)
            {

                Console.Write(x);
            }

        }
    }
}
