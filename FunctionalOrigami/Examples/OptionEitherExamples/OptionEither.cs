using FunctionalOrigami.Extensions;

using static LanguageExt.Prelude;

using static FunctionalOrigami.Extensions.MapExtensions;
using static FunctionalOrigami.Helpers.ConsoleHelper;
using static FunctionalOrigami.Examples.OptionEitherExamples.NameConstructor;
using static FunctionalOrigami.Examples.OptionEitherExamples.PersonConstructor;

using static FunctionalOrigami.Types.MessageConstructor;

namespace FunctionalOrigami.Examples.OptionEitherExamples
{
    internal static class OptionEither
    {
        public static void Run()
        {
            MapAction(
                ("Running Option Either Person",
                    RunOptionEitherPerson),
                ("Running Option To Either Person",
                    RunOptionToEitherPerson),
                ("Running Either To Option Person",
                    RunEitherToOptionPerson))
            .Run();
        }

        private static void RunOptionEitherPerson()
        {
            EitherName("René")
            .Bind(f =>
                EitherName("Descartes")
            .Bind(l =>
                EitherPerson(f, None, l)))
            .Pipe(WriteLine);

            EitherName("René")
            .Bind(f =>
                EitherName("")
            .Bind(m =>
                EitherName("Descartes")
            .Bind(l =>
                EitherPerson(f, m, l))))
            .Pipe(WriteLine);

            EitherName("René")
            .Bind(f =>
                EitherName("Descartes")
            .Bind(l =>
                EitherPerson(f, OptionName(""), l)))
            .Pipe(WriteLine);

            EitherName("Gottfried")
            .Bind(f =>
                EitherName("Wilhelm")
            .Bind(m =>
                EitherName("Leibniz")
            .Bind(l =>
                EitherPerson(f, m, l))))
            .Pipe(WriteLine);

            WriteLine(
                from f in EitherName("René")
                from l in EitherName("Descartes")
                from p in EitherPerson(f, None, l)
                select p);

            WriteLine(
                from f in EitherName("René")
                from m in EitherName("")
                from l in EitherName("Descartes")
                from p in EitherPerson(f, m, l)
                select p);

            WriteLine(
                from f in EitherName("René")
                from l in EitherName("Descartes")
                from p in EitherPerson(f, OptionName(""), l)
                select p);

            WriteLine(
                from f in EitherName("Gottfried")
                from m in EitherName("Wilhelm")
                from l in EitherName("Leibniz")
                from p in EitherPerson(f, m, l)
                select p);
        }

        private static void RunOptionToEitherPerson()
        {
            EitherName("René")
            .Bind(f =>
                OptionName("Descartes")
                    .ToEither(Message("ToEither"))
            .Bind(l =>
                EitherPerson(f, None, l)))
            .Pipe(WriteLine);

            OptionName("")
                .ToEither(Message("ToEither"))
            .Bind(f =>
                EitherName("Descartes")
            .Bind(l =>
                EitherPerson(f, None, l)))
            .Pipe(WriteLine);

            WriteLine(
                from f in OptionName("René").ToEither(Message("ToEither"))
                from l in EitherName("Descartes")
                from p in EitherPerson(f, None, l)
                select p);

            WriteLine(
                from f in OptionName("").ToEither(Message("ToEither"))
                from l in EitherName("Descartes")
                from p in EitherPerson(f, None, l)
                select p);
        }

        private static void RunEitherToOptionPerson()
        {
            OptionName("René")
            .Bind(f =>
                EitherName("Descartes")
                    .ToOption()
            .Bind(l =>
                OptionPerson(f, None, l)))
            .Pipe(WriteLine);

            EitherName("")
                .ToOption()
            .Bind(f =>
                OptionName("Descartes")
            .Bind(l =>
                OptionPerson(f, None, l)))
            .Pipe(WriteLine);

            WriteLine(
                from f in EitherName("René").ToOption()
                from l in OptionName("Descartes")
                from p in OptionPerson(f, None, l)
                select p);

            WriteLine(
                from f in EitherName("").ToOption()
                from l in OptionName("Descartes")
                from p in OptionPerson(f, None, l)
                select p);
        }
    }
}