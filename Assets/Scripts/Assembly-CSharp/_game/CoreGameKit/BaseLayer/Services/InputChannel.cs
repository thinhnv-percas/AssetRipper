using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Services
{
	[Flags]
	[Token(Token = "0x2000658")]
	public enum InputChannel
	{
		[Token(Token = "0x40015C4")]
		None = 0,
		[Token(Token = "0x40015C5")]
		CubeInteraction = 1,
		[Token(Token = "0x40015C6")]
		HammerButton = 2,
		[Token(Token = "0x40015C7")]
		VacuumButton = 4,
		[Token(Token = "0x40015C8")]
		SwapButton = 8,
		[Token(Token = "0x40015C9")]
		SettingsButton = 0x10,
		[Token(Token = "0x40015CA")]
		ForcePourTarget = 0x20,
		[Token(Token = "0x40015CB")]
		BoosterButtons = 0xE,
		[Token(Token = "0x40015CC")]
		All = 0x3F
	}
}
