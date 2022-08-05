using System.Linq;
using LanguageExt;
using FunctionalOrigami.Extensions;

using static LanguageExt.Prelude;

using static FunctionalOrigami.Extensions.MapExtensions;
using static FunctionalOrigami.Helpers.ConsoleHelper;

namespace FunctionalOrigami.Examples.ListExamples
{
    internal static class List
    {
        public static void Run()
        {
            MapAction(
                ("Running Array",
                    RunArray),
                ("Running List",
                    RunList))
            .Run();
        }

        private static void RunArray()
        {
            System.Array.Empty<int>()
                .Pipe(WriteLine);

            new[] { 1, 2, 3, 4 }
                .Pipe(WriteLine);

            new[] { 1, 2, 3, 4 }
                .Select(x => x + 1)
                .Pipe(WriteLine);

            new int[][] 
                { new[] { 1, 2 },
                  new[] { 3, 4 } }
                    .SelectMany(x => x)
                    .Pipe(WriteLine);

            new int[][]
                { new[] { 1, 2 },
                  new[] { 3, 4 } }
                    .SelectMany(a => a
                        .Select(i => i + 1))
                    .Pipe(WriteLine);
        }

        private static void RunList()
        {
            Lst<int>.Empty
                .Pipe(WriteLine);

            List(1, 2, 3, 4)
                .Pipe(WriteLine);

            List(1, 2, 3, 4)
                .Map(x => x + 1)
                .Pipe(WriteLine);

            List(List(1, 2), List(3, 4))
                .Bind(x => x)
                .Pipe(WriteLine);

            List(List(1, 2), List(3, 4))
                .Bind(l => l
                    .Map(i => i + 1))
                .Pipe(WriteLine);
        }
    }
}