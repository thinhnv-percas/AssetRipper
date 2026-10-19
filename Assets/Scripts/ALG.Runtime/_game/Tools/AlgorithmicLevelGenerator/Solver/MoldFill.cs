using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000028")]
	public class MoldFill
	{
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x3C01C88", Offset = "0x3C01C88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldFill()
		{
		}
	}
}
