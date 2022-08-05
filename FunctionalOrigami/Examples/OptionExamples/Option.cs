using FunctionalOrigami.Extensions;

using static LanguageExt.Prelude;

using static FunctionalOrigami.Extensions.MapExtensions;
using static FunctionalOrigami.Helpers.ConsoleHelper;
using static FunctionalOrigami.Examples.OptionExamples.Math;
using static FunctionalOrigami.Examples.OptionExamples.NameConstructor;
using static FunctionalOrigami.Examples.OptionExamples.PersonConstructor;

namespace FunctionalOrigami.Examples.OptionExamples
{
    internal static class Option
    {
        public static void Run()
        {
			MapAction(
				("Running Option",
					RunOption),
				("Running Option Math",
					RunOptionMath),
				("Running Option Name",
					RunOptionName),
				("Running Option Person",
					RunOptionPerson))
			.Run();
		}

		private static void RunOption()
        {
			None
			.Pipe(WriteLine);

			Some(3)
			.Pipe(WriteLine);

			Some(3)
			.Map(x => x + 1)
			.Pipe(WriteLine);

			Some(Some(3))
			.Bind(x => x)
			.Pipe(WriteLine);

			Some(Some(3))
			.Bind(o => o)
				.Map(i => i + 1)
			.Pipe(WriteLine);
		}

		private static void RunOptionMath()
        {
			Divide(6, 3)
				.Pipe(WriteLine);

			Divide(6, 0)
				.Pipe(WriteLine);

			Divide(6, 3)
				.Match(
				Some: WriteLine,
				None: WriteLine);

			Divide(6, 0)
				.Match(
				Some: WriteLine,
				None: WriteLine);

			Divide(6, 3)
				.Map(x => x + 1)
				.Pipe(WriteLine);

			Some(8)
			.Bind(x => Divide(x, 2))
			.Pipe(WriteLine);
		}

		private static void RunOptionName()
		{
			Name("René")
			.Pipe(WriteLine);

			Name(null)
			.Pipe(WriteLine);

			Name("René")
			.Match(
			Some: WriteLine,
			None: WriteLine);

			Name(null)
			.Match(
			Some: WriteLine,
			None: WriteLine);
		}

		private static void RunOptionPerson()
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
				Some: WriteLine,
				None: WriteLine);

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
				Some: WriteLine,
				None: WriteLine);

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
				Some: WriteLine,
				None: WriteLine);

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
				Some: WriteLine,
				None: WriteLine);
		}
	}
}