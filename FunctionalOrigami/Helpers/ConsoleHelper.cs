using System;
using System.Collections.Generic;
using System.Linq;

using static System.Environment;
using static System.String;

namespace FunctionalOrigami.Helpers
{
    internal static class ConsoleHelper
    {
        public static void WriteLine<T>(T value)
            => Console.WriteLine(value + NewLine);

        public static void WriteLine()
            => Console.WriteLine("None" + NewLine);

        public static void WriteLine<T>(IEnumerable<T> values)
            => WriteLine(values.ToArray());

        public static void WriteLine<T>(T[] array)
        {
            if (array.Any())
                Console.WriteLine(
                    "[" + Join(", ", array) + "]" + NewLine);
            else
                Console.WriteLine("[]" + NewLine);
        }
        
        public static ConsoleKeyInfo ReadKey()
            => Console.ReadKey();
    }
}