using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200001B")]
	public class ConveyorState
	{
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x10")]
		public Dictionary<string, int> Pool;

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x18")]
		public int Total;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x1C")]
		public int Capacity;

		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x20")]
		public int UsagePct;

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x3C03490", Offset = "0x3C03490", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ConveyorState()
		{
		}
	}
}
