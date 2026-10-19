using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200002D")]
	public class CoverReveal
	{
		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x18")]
		public int GroupId;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x1C")]
		public SolverColor Color;

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x3C05E88", Offset = "0x3C05E88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public CoverReveal()
		{
		}
	}
}
