using LanguageExt;
using static LanguageExt.Prelude;

namespace FunctionalOrigami.Examples.OptionExamples
{
    internal static class Math
    {
        public static Option<int> Divide(int dividend, int divisor)
            => !divisor.Equals(0)
                ? Some(dividend / divisor)
                : None;
    }
}