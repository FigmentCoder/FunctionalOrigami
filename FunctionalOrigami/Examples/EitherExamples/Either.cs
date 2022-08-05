using FunctionalOrigami.Extensions;

using static LanguageExt.Prelude;

using static FunctionalOrigami.Extensions.MapExtensions;
using static FunctionalOrigami.Helpers.ConsoleHelper;
using static FunctionalOrigami.Examples.EitherExamples.Math;
using static FunctionalOrigami.Examples.EitherExamples.NameConstructor;
using static FunctionalOrigami.Examples.EitherExamples.PersonConstructor;

namespace FunctionalOrigami.Examples.EitherExamples
{
    internal static class Either
    {
        public static void Run()
        {
			MapAction(
				("Running Either",
					RunEither),
				("Running Either Math",
					RunEitherMath),
				("Running Either Name",
					RunEitherName),
				("Running Either Person",
					RunEitherPerson))
			.Run();
		}

		private static void RunEither()
        {
			Left("Error")
				.Pipe(WriteLine);

			Right(3)
			.Pipe(WriteLine);

			Right(3)
			.Map(x => x + 1)
			.Pipe(WriteLine);

			Right(Right(3))
			.Bind(x => x)
			.Pipe(WriteLine);

			Right(Right(3))
			.Bind(e => e
				.Map(i => i + 1))
			.Pipe(WriteLine);
		}

		private static void RunEitherMath()
        {
			Divide(6, 3)
				.Pipe(WriteLine);

			Divide(6, 0)
				.Pipe(WriteLine);

			Divide(6, 3)
				.Match(
				Right: WriteLine,
				Left: WriteLine);

			Divide(6, 0)
				.Match(
				Right: WriteLine,
				Left: WriteLine);

			Divide(6, 3)
				.Map(x => x + 1)
				.Pipe(WriteLine);

			Right(8)
			.Bind(x => Divide(x, 2))
			.Pipe(WriteLine);
		}

		private static void RunEitherName()
        {
			Name("René")
			.Pipe(WriteLine);

			Name(null)
			.Pipe(WriteLine);

			Name("René")
			.Match(
			Right: WriteLine,
			Left: WriteLine);

			Name(null)
			.Match(
			Right: WriteLine,
			Left: WriteLine);
		}

		private static void RunEitherPerson()
        {
			Name("René")
			.Bind(f =>
				Name("Descartes")
			.Bind(l =>
				Person(f, l)))
			.Pipe(WriteLine);

			Name("René")
			.Bind(f =>
				Name("Descartes")
			.Bind(l =>
				Person(f, l)))
			.Match(
				Right: WriteLine,
				Left: WriteLine);

			Name("René")
			.Bind(f =>
				Name(null)
			.Bind(l =>
				Person(f, l)))
			.Pipe(WriteLine);

			Name("René")
			.Bind(f =>
				Name(null)
			.Bind(l =>
				Person(f, l)))
			.Match(
				Right: WriteLine,
				Left: WriteLine);

			WriteLine(
				from f in Name("René")
				from l in Name("Descartes")
				from p in Person(f, l)
				select p);

			(from f in Name("René")
			 from l in Name("Descartes")
			 from p in Person(f, l)
			 select p)
			.Match(
				Right: WriteLine,
				Left: WriteLine);

			WriteLine(
				from f in Name("René")
				from l in Name(null)
				from p in Person(f, l)
				select p);

			(from f in Name("René")
			 from l in Name(null)
			 from p in Person(f, l)
			 select p)
			.Match(
				Right: WriteLine,
				Left: WriteLine);
		}
    }
}