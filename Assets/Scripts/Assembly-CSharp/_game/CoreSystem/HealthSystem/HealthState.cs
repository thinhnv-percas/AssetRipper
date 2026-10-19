using Cpp2ILInjected;

namespace _game.CoreSystem.HealthSystem
{
	[Token(Token = "0x20004C6")]
	public enum HealthState
	{
		[Token(Token = "0x4000FFE")]
		Full = 0,
		[Token(Token = "0x4000FFF")]
		Regenerating = 1,
		[Token(Token = "0x4001000")]
		Infinite = 2
	}
}
