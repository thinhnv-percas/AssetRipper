using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000014")]
	public class ParsedSnakeSegment
	{
		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x10")]
		public int SnakeId;

		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x14")]
		public int NextCol;

		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x18")]
		public int NextRow;

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x3C0B628", Offset = "0x3C0B628", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ParsedSnakeSegment()
		{
		}
	}
}
