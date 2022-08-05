using System;
using FunctionalOrigami.Extensions;

namespace FunctionalOrigami.Examples.ExceptionExamples
{
    internal class Person
    {
        /// <summary>
        /// Function is Partial and throws ArgumentNullException
        /// I hope that this comment is read
        /// I hope the client code can handle Exceptions
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static Person New(
            Name firstName,
            Name lastName)
        {
            if (firstName.IsNull())
                throw new ArgumentNullException(nameof(firstName));

            if (lastName.IsNull())
                throw new ArgumentNullException(nameof(lastName));

            return new Person(firstName, lastName);
        }

        private Person(
            Name firstName,
            Name lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Name FirstName { get; }

        public Name LastName { get; }

        public override string ToString()
            => FirstName.ConcatS(LastName).ToString();
    }

    internal static class PersonConstructor
    {
        /// <summary>
        /// Function is Partial and throws ArgumentNullException
        /// I hope that this comment is read
        /// I hope the client code can handle Exceptions
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static Person Person(
            Name firstName,
            Name lastName)
                => ExceptionExamples.Person.New(firstName, lastName);
    }
}