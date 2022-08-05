using LanguageExt;

using FunctionalOrigami.Types;
using FunctionalOrigami.Extensions;

using static System.String;
using static LanguageExt.Prelude;
using static FunctionalOrigami.Types.MessageConstructor;

namespace FunctionalOrigami.Examples.EitherExamples
{
    internal class Name
    {
        public static Either<Message, Name> New(string value)
            => !IsNullOrEmpty(value)
                ? Right(new Name(value))
                : Left(Message(nameof(value)
                    .ConcatS("cannot be null or empty")));

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
        public static Either<Message, Name> Name(string value)
            => EitherExamples.Name.New(value);
    }
}