using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000060")]
	public class MoldCellSlot
	{
		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x1C")]
		public bool IsHidden;

		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x20")]
		public (int Col, int Row)? LinkedPartner;

		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x2C")]
		public bool IsHammer;

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x3C1A1A8", Offset = "0x3C1A1A8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldCellSlot()
		{
		}
	}
}
