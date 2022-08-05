using System;

namespace FunctionalOrigami.Extensions
{
    internal static class FuncExtensions
    {
        public static Func<A, A> Tap<A>(Action<A> action)
            => x => { action(x); return x; };

        public static B Pipe<A, B>(this A value, Func<A, B> func)
            => func(value);

        public static A Pipe<A>(this A input, Action<A> action)
            => Tap(action)(input);

        public static Func<A, bool> Not<A>(this Func<A, bool> predicate)
          => x => !predicate(x);

        public static Func<A, bool> And<A>(this Func<A, bool> left, Func<A, bool> right)
            => x => left(x) && right(x);

        public static Func<A, bool> Or<A>(this Func<A, bool> left, Func<A, bool> right)
            => x => left(x) || right(x);
    }
}