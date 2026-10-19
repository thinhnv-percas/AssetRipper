using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200002C")]
	public class IceHit
	{
		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x18")]
		public int RemainingStrength;

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x3C05E90", Offset = "0x3C05E90", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public IceHit()
		{
		}
	}
}
