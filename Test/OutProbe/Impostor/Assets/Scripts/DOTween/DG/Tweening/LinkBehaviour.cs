using Cpp2ILInjected;

namespace DG.Tweening
{
	[Token(Token = "0x2000016")]
	public enum LinkBehaviour
	{
		[Token(Token = "0x4000064")]
		PauseOnDisable = 0,
		[Token(Token = "0x4000065")]
		PauseOnDisablePlayOnEnable = 1,
		[Token(Token = "0x4000066")]
		PauseOnDisableRestartOnEnable = 2,
		[Token(Token = "0x4000067")]
		PlayOnEnable = 3,
		[Token(Token = "0x4000068")]
		RestartOnEnable = 4,
		[Token(Token = "0x4000069")]
		KillOnDisable = 5,
		[Token(Token = "0x400006A")]
		KillOnDestroy = 6,
		[Token(Token = "0x400006B")]
		CompleteOnDisable = 7,
		[Token(Token = "0x400006C")]
		CompleteAndKillOnDisable = 8,
		[Token(Token = "0x400006D")]
		RewindOnDisable = 9,
		[Token(Token = "0x400006E")]
		RewindAndKillOnDisable = 10
	}
}
