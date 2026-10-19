using Cpp2ILInjected;

namespace _game.CoreSystem.New.TopGridSystem.Core.Conditions
{
	[Token(Token = "0x2000279")]
	public enum BlockReason
	{
		[Token(Token = "0x40007E6")]
		None = 0,
		[Token(Token = "0x40007E7")]
		Neighbors = 1,
		[Token(Token = "0x40007E8")]
		Lock = 2,
		[Token(Token = "0x40007E9")]
		Garage = 3,
		[Token(Token = "0x40007EA")]
		HammerArea = 7,
		[Token(Token = "0x40007EB")]
		SnakeBody = 4,
		[Token(Token = "0x40007EC")]
		Hidden = 5,
		[Token(Token = "0x40007ED")]
		Pin = 6,
		[Token(Token = "0x40007EE")]
		Frozen = 8
	}
}
