using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000029")]
	public class NewPourable
	{
		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x1C")]
		public bool WasHidden;

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x3C05F2C", Offset = "0x3C05F2C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public NewPourable()
		{
		}
	}
}
