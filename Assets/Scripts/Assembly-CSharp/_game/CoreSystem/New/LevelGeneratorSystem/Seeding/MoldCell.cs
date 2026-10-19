using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Seeding
{
	[Token(Token = "0x200032B")]
	public readonly struct MoldCell
	{
		[Token(Token = "0x4000956")]
		[FieldOffset(Offset = "0x0")]
		public readonly int Column;

		[Token(Token = "0x4000957")]
		[FieldOffset(Offset = "0x4")]
		public readonly int Row;

		[Token(Token = "0x4000958")]
		[FieldOffset(Offset = "0x8")]
		public readonly GameColor Color;

		[Token(Token = "0x6000D8B")]
		[Address(RVA = "0x3EF21D0", Offset = "0x3EF21D0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Column = column;\n\tthis.Row = row;\n\tthis.Color = color;\n\treturn;\n")]
		public MoldCell(int column, int row, GameColor color)
		{
			Column = column;
			Row = row;
			Color = color;
		}

		[Token(Token = "0x6000D8C")]
		[Address(RVA = "0x3EF22B0", Offset = "0x3EF22B0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Column;\n")]
		public MoldCell WithColor(GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldCell::WithColor");
			return default;
		}
	}
}
