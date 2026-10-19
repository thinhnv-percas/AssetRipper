using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000020")]
	public class ForensicDiagnostics
	{
		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x10")]
		public Dictionary<string, int> InitialSupply;

		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x18")]
		public Dictionary<string, int> InitialDemand;

		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x20")]
		public int InitialPourableCubeCount;

		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x24")]
		public int InitialGridCubeCount;

		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x28")]
		public int BeamMaxDepthReached;

		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x2C")]
		public int BeamTerminalStuckLeaves;

		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x30")]
		public Dictionary<string, int> RolloutStuckReasons;

		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x38")]
		public int? IdaNodesExpanded;

		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x40")]
		public int? IdaDeadStatesPruned;

		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x48")]
		public int? IdaMaxDepthReached;

		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x50")]
		public int? IdaFinalThreshold;

		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x58")]
		public string IdaOutcome;

		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x60")]
		public string IdaFirstDeadReason;

		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x68")]
		public int? IdaFirstDeadDepth;

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x3C0B934", Offset = "0x3C0B934", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ForensicDiagnostics()
		{
		}
	}
}
