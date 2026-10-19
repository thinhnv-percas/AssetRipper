using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200000E")]
	public class MoldCell
	{
		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x1C")]
		public bool IsHidden;

		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x20")]
		public float Fill;

		[Token(Token = "0x17000001")]
		public bool IsComplete
		{
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x3C01C6C", Offset = "0x3C01C6C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = this.Fill < 0x3F7FBE77;\n\tv9 = this.Fill == this.Fill;\n\tv12 = ~v9;\n\tv13 = v5 == v12;\n\treturn v13;\n")]
			get
			{
				bool flag = Fill < 0.999f;
				bool flag2 = Fill == Fill;
				bool flag3 = !flag2;
				return flag == flag3;
			}
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x3C0AE18", Offset = "0x3C0AE18", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.Col = this.Col;\n\tv45.Color = this.Color;\n\tv45.IsHidden = this.IsHidden;\n\tv45.Fill = this.Fill;\n\treturn v45;\nL_0017:\n\tv45 = new _game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell();\n\tSystem.Object::.ctor(v45);\n")]
		public MoldCell Clone()
		{
			MoldCell moldCell = new MoldCell();
			moldCell.Col = Col;
			moldCell.Row = (int)((uint)Col >> 32);
			moldCell.Color = Color;
			moldCell.IsHidden = IsHidden;
			moldCell.Fill = Fill;
			return moldCell;
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x3BFF960", Offset = "0x3BFF960", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldCell()
		{
		}
	}
}
