using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000024")]
	public class UnsolvableEvidence
	{
		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x10")]
		public int RolloutsRun;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x18")]
		public double LossRate;

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x3C0B9D0", Offset = "0x3C0B9D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public UnsolvableEvidence()
		{
		}
	}
}
