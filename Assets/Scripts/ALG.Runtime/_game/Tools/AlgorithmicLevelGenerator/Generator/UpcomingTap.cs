using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000037")]
	public class UpcomingTap
	{
		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x10")]
		public (int Col, int Row) Position;

		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor FrozenColor;

		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x1C")]
		public int ClusterSize;

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x3C10D28", Offset = "0x3C10D28", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ClusterSize = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UpcomingTap()
		{
			ClusterSize = 1;
		}
	}
}
