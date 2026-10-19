using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000010")]
	public class MoldActivation
	{
		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x14")]
		public int FromRow;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x18")]
		public int ToRow;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x1C")]
		public SolverColor NewColor;

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x3C0AEA4", Offset = "0x3C0AEA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldActivation()
		{
		}
	}
}
