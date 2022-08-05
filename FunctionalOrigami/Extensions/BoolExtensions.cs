using System;

namespace FunctionalOrigami.Extensions
{
    internal static class BoolExtensions
    {
        public static A IfTrue<A>(this bool value, Func<A> func)
            => value ? func() : default;

        public static B IfTrue<A, B>(this bool value, Func<A, B> func, A a)
            => value ? func(a) : default;

        public static A IfFalse<A>(this bool value, Func<A> func)
            => value ? default : func();

        public static B IfFalse<A, B>(this bool value, Func<A, B> func, A a)
            => value ? default : func(a);

        public static void IfTrue(this bool value, Action action)
        {
            if (value) action();
        }

        public static void IfTrue<A>(this bool value, Action<A> action, A a)
        {
            if (value) action(a);
        }

        public static void IfFalse(this bool value, Action action)
        {
            if (!value) action();
        }

        public static void IfFalse<A>(this bool value, Action<A> action, A a)
        {
            if (!value) action(a);
        }

        public static void IfElse(this bool value, Action actionIsTrue, Action actionIsFalse)
        {
            if (value)
                actionIsTrue();
            else
                actionIsFalse();
        }

        public static bool And(this bool left, bool right)
            => left && right;

        public static bool Or(this bool left, bool right)
            => left || right;
    }
}