using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200001C")]
	public class LinkedMoldStateEntry
	{
		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x14")]
		public bool Blocked;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x18")]
		public List<int> Partners;

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x3C0B75C", Offset = "0x3C0B75C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public LinkedMoldStateEntry()
		{
		}
	}
}
