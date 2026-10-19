using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200001E")]
	public enum VerdictLabel
	{
		[Token(Token = "0x40000A0")]
		CertifiedWin = 0,
		[Token(Token = "0x40000A1")]
		HeuristicWin = 1,
		[Token(Token = "0x40000A2")]
		ProvenUnsolvable = 2,
		[Token(Token = "0x40000A3")]
		BudgetExhausted = 3,
		[Token(Token = "0x40000A4")]
		ParityFail = 4
	}
}
