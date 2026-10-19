using Cpp2ILInjected;

namespace _game.Systems.UncoInput
{
	[Token(Token = "0x2000008")]
	public enum InputMode
	{
		[Token(Token = "0x400000F")]
		None = 0,
		[Token(Token = "0x4000010")]
		Click = 1,
		[Token(Token = "0x4000011")]
		Hold = 2
	}
}
