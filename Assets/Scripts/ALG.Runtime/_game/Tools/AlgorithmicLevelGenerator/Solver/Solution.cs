using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000021")]
	public class Solution
	{
		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x10")]
		public List<SolutionStep> Steps;

		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x18")]
		public int Length;

		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x20")]
		public string Strategy;

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x3C0B93C", Offset = "0x3C0B93C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolutionStep>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolutionStep>::.ctor(v48);\n\tthis.Steps = v48;\n")]
		public Solution()
		{
			List<SolutionStep> steps = new List<SolutionStep>();
			Steps = steps;
		}
	}
}
