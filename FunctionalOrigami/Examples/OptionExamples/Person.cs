using LanguageExt;
using FunctionalOrigami.Extensions;

using static LanguageExt.Prelude;

namespace FunctionalOrigami.Examples.OptionExamples
{
    internal class Person
    {
        public static Option<Person> New(
            Name firstName,
            Name lastName)
                => firstName.IsNotNull()
                    .And(lastName.IsNotNull())
                    ? Some(new Person(firstName, lastName))
                    : None;                

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
        public static Option<Person> Person(
            Name firstName,
            Name lastName)
                => OptionExamples.Person.New(firstName, lastName);
    }
}