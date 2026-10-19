using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000027")]
	public class TappedCube
	{
		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x1C")]
		public bool WasHidden;

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x3C05E80", Offset = "0x3C05E80", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TappedCube()
		{
		}
	}
}
