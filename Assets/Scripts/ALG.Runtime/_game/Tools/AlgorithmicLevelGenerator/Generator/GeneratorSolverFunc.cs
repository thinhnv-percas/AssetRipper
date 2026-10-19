using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200003C")]
	public delegate SolverResult GeneratorSolverFunc(ParsedLevel parsed);
}
