using LanguageExt;

using FunctionalOrigami.Extensions;
using FunctionalOrigami.Types;

using static System.String;
using static LanguageExt.Prelude;
using static FunctionalOrigami.Types.MessageConstructor;

namespace FunctionalOrigami.Examples.OptionEitherExamples
{
    internal class Name
    {
        public static Either<Message, Name> EitherNew(string value)
            => !IsNullOrEmpty(value)
                ? Right(new Name(value))
                : Left(Message(nameof(value)
                    .ConcatS("cannot be null or empty")));

        public static Option<Name> OptionNew(string value)
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
        public static Either<Message, Name> EitherName(string value)
            => Name.EitherNew(value);

        public static Option<Name> OptionName(string value)
            => Name.OptionNew(value);
    }
}