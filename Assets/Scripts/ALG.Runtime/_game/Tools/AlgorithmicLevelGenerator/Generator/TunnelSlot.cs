using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200005F")]
	public class TunnelSlot
	{
		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x18")]
		public TunnelDirection Direction;

		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x20")]
		public List<SolverColor> FrozenQueue;

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x3C1C224", Offset = "0x3C1C224", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelSlot()
		{
		}
	}
}
