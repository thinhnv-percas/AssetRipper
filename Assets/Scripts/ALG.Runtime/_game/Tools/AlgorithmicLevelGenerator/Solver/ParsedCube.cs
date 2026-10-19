using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000015")]
	public class ParsedCube
	{
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x1C")]
		public bool IsHidden;

		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x20")]
		public SolverColor LockColor;

		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x24")]
		public SolverColor KeyColor;

		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x28")]
		public int? IceStrength;

		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x30")]
		public int? CoverGroupId;

		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x38")]
		public int? CoverCounter;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x40")]
		public int? LinkedGroupId;

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x3C0B630", Offset = "0x3C0B630", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public ParsedCube()
		{
		}
	}
}
