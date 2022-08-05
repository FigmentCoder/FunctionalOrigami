using LanguageExt;
using FunctionalOrigami.Types;

using static LanguageExt.Prelude;
using static FunctionalOrigami.Types.MessageConstructor;

namespace FunctionalOrigami.Examples.EitherExamples
{
    internal static class Math
    {
        public static Either<Message, int> Divide(int dividend, int divisor)
            => !divisor.Equals(0)
                ? Right(dividend / divisor)
                : Left(Message("Cannot divide by zero"));
    }
}