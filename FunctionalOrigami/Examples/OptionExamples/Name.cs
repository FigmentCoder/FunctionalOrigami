using LanguageExt;
using FunctionalOrigami.Extensions;

using static System.String;
using static LanguageExt.Prelude;

namespace FunctionalOrigami.Examples.OptionExamples
{
    internal class Name
    {
        public static Option<Name> New(string value)
            => !IsNullOrEmpty(value)
                ? Some(new Name(value))
                : None;

        private Name(string value)
        {
            Value = value;
        }

        private readonly string Value;

        public override string ToString()
            => Value;

        public Name ConcatS(Name name)
            => new(Value.ConcatS(name.Value));
    }

    internal static class NameConstructor
    {
        public static Option<Name> Name(string value)
            => OptionExamples.Name.New(value);
    }
}