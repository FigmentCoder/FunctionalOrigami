using System;
using FunctionalOrigami.Extensions;
using static System.String;

namespace FunctionalOrigami.Examples.ExceptionExamples
{
    internal class Name
    {
        /// <summary>
        /// Function is Partial and throws ArgumentNullException
        /// I hope that this comment is read
        /// I hope the client code can handle Exceptions
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Name New(string value)
        {
            if (IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            return new Name(value);
        }

        private Name(string value)
        {
            Value = value;
        }

        private readonly string Value;

        public override string ToString()
            => Value;

        public Name ConcatS(Name name)
            => new Name(Value.ConcatS(name.Value));
    }

    internal static class NameConstructor
    {
        /// <summary>
        /// Function is Partial and throws ArgumentNullException
        /// I hope that this comment is read
        /// I hope the client code can handle Exceptions
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Name Name(string value)
            => ExceptionExamples.Name.New(value);
    }
}