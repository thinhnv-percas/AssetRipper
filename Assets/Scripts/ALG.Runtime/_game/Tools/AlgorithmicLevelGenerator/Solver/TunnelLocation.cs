using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200002B")]
	public class TunnelLocation
	{
		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x3C05F24", Offset = "0x3C05F24", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelLocation()
		{
		}
	}
}
