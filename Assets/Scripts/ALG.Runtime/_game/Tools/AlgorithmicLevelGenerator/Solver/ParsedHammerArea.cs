using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000012")]
	public class ParsedHammerArea
	{
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x18")]
		public int SizeX;

		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x1C")]
		public int SizeY;

		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x20")]
		public int GroupId;

		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x24")]
		public int Counter;

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x3C0B594", Offset = "0x3C0B594", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ParsedHammerArea()
		{
		}
	}
}
