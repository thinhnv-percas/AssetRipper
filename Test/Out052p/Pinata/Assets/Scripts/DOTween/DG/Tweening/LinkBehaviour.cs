using Cpp2ILInjected;

namespace DG.Tweening
{
	[Token(Token = "0x200000D")]
	public enum LinkBehaviour
	{
		[Token(Token = "0x4000051")]
		PauseOnDisable = 0,
		[Token(Token = "0x4000052")]
		PauseOnDisablePlayOnEnable = 1,
		[Token(Token = "0x4000053")]
		PauseOnDisableRestartOnEnable = 2,
		[Token(Token = "0x4000054")]
		PlayOnEnable = 3,
		[Token(Token = "0x4000055")]
		RestartOnEnable = 4,
		[Token(Token = "0x4000056")]
		KillOnDisable = 5,
		[Token(Token = "0x4000057")]
		KillOnDestroy = 6,
		[Token(Token = "0x4000058")]
		CompleteOnDisable = 7,
		[Token(Token = "0x4000059")]
		CompleteAndKillOnDisable = 8,
		[Token(Token = "0x400005A")]
		RewindOnDisable = 9,
		[Token(Token = "0x400005B")]
		RewindAndKillOnDisable = 10
	}
}
