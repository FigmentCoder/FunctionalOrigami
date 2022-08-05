using System;

using static FunctionalOrigami.Helpers.ConsoleHelper;
using static FunctionalOrigami.Examples.ExceptionExamples.Math;
using static FunctionalOrigami.Examples.ExceptionExamples.NameConstructor;
using static FunctionalOrigami.Examples.ExceptionExamples.PersonConstructor;

namespace FunctionalOrigami.Examples.ExceptionExamples
{
    internal static class Exception
    {
        public static void Run()
        {
            WriteLine("Running Exception Math");
            RunExceptionMath();
            WriteLine("\n");

            WriteLine("Running Exception Name");
            RunExceptionName();
            WriteLine("\n");

            WriteLine("Running Exception Person");
            RunExceptionPerson();
            WriteLine("\n");
        }

        /// <summary>
        /// Remember to use Try Catch to handle Exceptions on Partial Functions
        /// </summary>
        private static void RunExceptionMath()
        {
            WriteLine(Divide(6, 3));

            try
            {
                Divide(6, 0);
            }
            catch (InvalidOperationException exception)
            {
                WriteLine("You remembered to use Try Catch");
                WriteLine(exception);
            }
        }

        /// <summary>
        /// Remember to use Try Catch to handle Exceptions on Partial Functions
        /// </summary>
        private static void RunExceptionName()
        {
            WriteLine(Name("Francis"));

            try
            {
                Name(null);
            }
            catch (ArgumentNullException exception)
            {
                WriteLine("You remembered to use Try Catch");
                WriteLine(exception);
            }
        }

        /// <summary>
        /// Remember to use Try Catch to handle Exceptions on Partial Functions
        /// </summary>
        private static void RunExceptionPerson()
        {
            WriteLine(Person(
                Name("Francis"),
                Name("Galton")));

            try
            {
                Person(
                    Name("Francis"),
                    Name(null));
            }
            catch (ArgumentNullException exception)
            {
                WriteLine("You remembered to use Try Catch");
                WriteLine(exception);
            }
        }
    }
}