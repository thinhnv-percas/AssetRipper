using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Conveyor
{
	[Token(Token = "0x200039A")]
	public static class MoldUnits
	{
		[Token(Token = "0x17000132")]
		public static int UnitsPerCube
		{
			[Token(Token = "0x6000F21")]
			[Address(RVA = "0x3C95FA4", Offset = "0x3C95FA4", Length = "0x8")]
			get
			{
				return 3;
			}
		}

		[Token(Token = "0x17000133")]
		public static int CapacityInUnits
		{
			[Token(Token = "0x6000F22")]
			[Address(RVA = "0x3C95FAC", Offset = "0x3C95FAC", Length = "0x8")]
			get
			{
				return 12;
			}
		}
	}
}
