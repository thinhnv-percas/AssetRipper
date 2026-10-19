using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200005E")]
	public class CubeSlot
	{
		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor FrozenColor;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x1C")]
		public bool IsHidden;

		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x20")]
		public SolverColor FrozenLockColor;

		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x24")]
		public bool HasLockSlot;

		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x28")]
		public SolverColor FrozenKeyColor;

		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x2C")]
		public bool HasKeySlot;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x30")]
		public int? FrozenIceStrength;

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x38")]
		public int? CoverGroupId;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x40")]
		public int? FrozenCoverCounter;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x48")]
		public int? FrozenSnakeId;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x50")]
		public int FrozenSnakeNextCol;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x54")]
		public int FrozenSnakeNextRow;

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x3C1C214", Offset = "0x3C1C214", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.FrozenSnakeNextCol = -1;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public CubeSlot()
		{
			FrozenSnakeNextCol = -1;
			FrozenSnakeNextRow = -1;
		}
	}
}
