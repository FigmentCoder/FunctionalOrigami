using System.Linq;

using FunctionalOrigami.Extensions;
using FunctionalOrigami.Examples.ExceptionExamples;
using FunctionalOrigami.Examples.ListExamples;
using FunctionalOrigami.Examples.OptionExamples;
using FunctionalOrigami.Examples.EitherExamples;
using FunctionalOrigami.Examples.OptionEitherExamples;

using static FunctionalOrigami.Extensions.FuncExtensions;
using static FunctionalOrigami.Helpers.ConsoleHelper;
using static FunctionalOrigami.Extensions.MapExtensions;

namespace FunctionalOrigami
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            MapAction(
                ("Exception", Exception.Run),
                ("List", List.Run),
                ("Option", Option.Run),
                ("Either", Either.Run),
                ("OptionEither", OptionEither.Run))
                .Pipe(m => args.Any()
                .IfElse(
                    () => m.Find(args[0])
                        .Match(
                            (run) => run(),
                            () => WriteLine($"Unknown option: '{args[0]}'")),
                    () => WriteLine("No input detected")));

            ReadKey();
        }
    }
}