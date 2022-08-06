using LanguageExt;

using FunctionalOrigami.Extensions;
using FunctionalOrigami.Types;

using static LanguageExt.Prelude;
using static FunctionalOrigami.Types.MessageConstructor;

namespace FunctionalOrigami.Examples.EitherExamples
{
    internal class Person
    {
        public static Either<Message, Person> New(
            Name firstName,
            Name lastName)
        {
            if (firstName.IsNull())
                return Left(
                    Message(nameof(firstName)
                        .ConcatS("cannot be null")));

            if (lastName.IsNull())
                return Left(
                    Message(nameof(lastName)
                        .ConcatS("cannot be null")));

            return Right(new Person(firstName, lastName));
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
        public static Either<Message, Person> Person(
            Name firstName,
            Name lastName)
                => EitherExamples.Person.New(firstName, lastName);
    }
}