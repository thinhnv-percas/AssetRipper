using Cpp2ILInjected;

[Token(Token = "0x2000003")]
public enum GameStatesEnum
{
	[Token(Token = "0x4000005")]
	None = -10,
	[Token(Token = "0x4000006")]
	Menu = 0,
	[Token(Token = "0x4000007")]
	Playing = 10,
	[Token(Token = "0x4000008")]
	Finished = 20
}
