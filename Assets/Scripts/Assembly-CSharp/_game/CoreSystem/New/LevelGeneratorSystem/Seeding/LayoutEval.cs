using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Seeding
{
	[Token(Token = "0x200032A")]
	public readonly struct LayoutEval
	{
		[Token(Token = "0x4000953")]
		[FieldOffset(Offset = "0x0")]
		public readonly int[] Occupancy;

		[Token(Token = "0x4000954")]
		[FieldOffset(Offset = "0x8")]
		public readonly float Mae;

		[Token(Token = "0x4000955")]
		[FieldOffset(Offset = "0xC")]
		public readonly bool Win;

		[Token(Token = "0x6000D8A")]
		[Address(RVA = "0x3EF2274", Offset = "0x3EF2274", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.Occupancy = occupancy;\n\tthis.Mae = mae;\n\tthis.Win = win;\n\treturn;\n")]
		public LayoutEval(int[] occupancy, float mae, bool win)
		{
			Occupancy = occupancy;
			Mae = mae;
			Win = win;
		}
	}
}
