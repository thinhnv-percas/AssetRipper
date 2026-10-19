using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000023")]
	public class SolverMetrics
	{
		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x10")]
		public long GreedyRuntimeMs;

		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x18")]
		public long? MctsRuntimeMs;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x28")]
		public int? MctsRollouts;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x30")]
		public int StatesExplored;

		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x38")]
		public double? RolloutWinRate;

		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x48")]
		public int? BeamMaxDepthReached;

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x50")]
		public int? BeamTerminalStuckLeaves;

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x3C0B92C", Offset = "0x3C0B92C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SolverMetrics()
		{
		}
	}
}
