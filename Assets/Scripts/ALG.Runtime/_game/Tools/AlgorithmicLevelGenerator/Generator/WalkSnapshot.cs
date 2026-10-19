using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000063")]
	public class WalkSnapshot
	{
		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x10")]
		public int TapIndex;

		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x18")]
		public ConstructiveSimulator SimBeforeTap;

		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x20")]
		public Dictionary<SolverColor, int> UsageCountsBeforeTap;

		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x28")]
		public SolverColor PickedColor;

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x3C1D14C", Offset = "0x3C1D14C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public WalkSnapshot()
		{
		}
	}
}
