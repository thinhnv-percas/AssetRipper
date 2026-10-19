using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200000D")]
	public class GridCube
	{
		[Token(Token = "0x400003C")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x18")]
		public SolverColor Color;

		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x1C")]
		public bool IsHidden;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x20")]
		public SolverColor LockColor;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x24")]
		public SolverColor KeyColor;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x28")]
		public int? IceStrength;

		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x30")]
		public int? CoverGroupId;

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x3C0AD7C", Offset = "0x3C0AD7C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv45.Col = this.Col;\n\tv45.Color = this.Color;\n\tv45.IsHidden = this.IsHidden;\n\tv45.LockColor = this.LockColor;\n\tv45.IceStrength = this.IceStrength;\n\tv45.CoverGroupId = this.CoverGroupId;\n\treturn v45;\nL_0017:\n\tv45 = new _game.Tools.AlgorithmicLevelGenerator.Solver.GridCube();\n\tSystem.Object::.ctor(v45);\n")]
		public GridCube Clone()
		{
			GridCube gridCube = new GridCube();
			gridCube.Col = Col;
			gridCube.Row = (int)((uint)Col >> 32);
			gridCube.Color = Color;
			gridCube.IsHidden = IsHidden;
			gridCube.LockColor = LockColor;
			gridCube.IceStrength = IceStrength;
			gridCube.CoverGroupId = CoverGroupId;
			return gridCube;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x3BFF8CC", Offset = "0x3BFF8CC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GridCube()
		{
		}
	}
}
