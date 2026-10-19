using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000019")]
	public class ParsedMoldCell
	{
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x1C")]
		public bool IsHidden;

		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x1D")]
		public bool IsHammer;

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x3C0B6F0", Offset = "0x3C0B6F0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ParsedMoldCell()
		{
		}
	}
}
