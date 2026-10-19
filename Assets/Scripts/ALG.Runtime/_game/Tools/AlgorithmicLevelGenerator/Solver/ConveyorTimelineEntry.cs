using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000022")]
	public class ConveyorTimelineEntry
	{
		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x10")]
		public int Step;

		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x14")]
		public int FillPct;

		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x18")]
		public int Total;

		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x1C")]
		public int Capacity;

		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x20")]
		public Dictionary<string, int> Pool;

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x3C0B9C8", Offset = "0x3C0B9C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ConveyorTimelineEntry()
		{
		}
	}
}
