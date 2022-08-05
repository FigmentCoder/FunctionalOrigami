using System;

using LanguageExt;

using static LanguageExt.Prelude;
using static FunctionalOrigami.Helpers.ConsoleHelper;

namespace FunctionalOrigami.Extensions
{
    internal static class MapExtensions
    {
        public static Map<string, Action> MapAction(
            (string, Action) head,
            params (string, Action)[] tail)
                => Map(head, tail);

        public static void Run(this Map<string, Action> map)
            => map.ForEach(m =>
            {
                WriteLine(m.Key + "\n");
                m.Value();
                WriteLine("\n");
            });
    }
}