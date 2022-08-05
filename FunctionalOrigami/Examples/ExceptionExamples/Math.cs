using System;

namespace FunctionalOrigami.Examples.ExceptionExamples
{
    internal static class Math
    {
        /// <summary>
        /// Function is Partial and throws InvalidOperationException
        /// I hope that this comment is read
        /// I hope the client code can handle Exceptions 
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>        
        public static int Divide(int dividend, int divisor)
        {
            if (divisor.Equals(0))
                throw new InvalidOperationException("Cannot divide by zero");

            return dividend / divisor;
        }
    }
}