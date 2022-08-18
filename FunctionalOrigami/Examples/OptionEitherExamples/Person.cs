using LanguageExt;

using FunctionalOrigami.Extensions;
using FunctionalOrigami.Types;

using static LanguageExt.Prelude;
using static FunctionalOrigami.Types.MessageConstructor;

namespace FunctionalOrigami.Examples.OptionEitherExamples
{
    class Person
    {
        public static Either<Message, Person> EitherNew(
            Name firstName,
            Option<Name> middleName,
            Name lastName)
        {
            if (firstName.IsNull())
                return Left(
                    Message(nameof(firstName)
                        .ConcatS("cannot be null")));

            if (middleName.IsNull())
                return Left(
                    Message(nameof(middleName)
                        .ConcatS("cannot be null")));

            if (lastName.IsNull())
                return Left(
                    Message(nameof(lastName)
                        .ConcatS("cannot be null")));

            return Right(new Person(firstName, middleName, lastName));
        }

        public static Option<Person> OptionNew(
            Name firstName,
            Option<Name> middleName,
            Name lastName)
                => firstName.IsNotNull()
                    .And(middleName.IsNotNull()
                    .And(lastName.IsNotNull()))
                    ? Some(new Person(firstName, middleName, lastName))
                    : None;

        private Person(
            Name firstName,
            Option<Name> middleName,
            Name lastName)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
        }

        public Name FirstName { get; }

        public Option<Name> MiddleName { get; }

        public Name LastName { get; }

        public override string ToString()
            => MiddleName.Match(
                Some: middleName => 
                    FirstName
                    .ConcatS(middleName)
                    .ConcatS(LastName)
                    .ToString(),
                None: FirstName
                    .ConcatS(LastName)
                    .ToString());
    }

    internal static class PersonConstructor
    {
        public static Either<Message, Person> EitherPerson(
            Name firstName,
            Option<Name> middleName,
            Name lastName)
                => Person.EitherNew(firstName, middleName, lastName);

        public static Option<Person> OptionPerson(
            Name firstName,
            Option<Name> middleName,
            Name lastName)
                => Person.OptionNew(firstName, middleName, lastName);
    }
}