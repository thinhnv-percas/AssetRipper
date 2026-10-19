using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.UI
{
	[Flags]
	[Token(Token = "0x2000634")]
	public enum BaseLayerSettingsState
	{
		[Token(Token = "0x4001562")]
		None = 0,
		[Token(Token = "0x4001563")]
		HasStarted = 1,
		[Token(Token = "0x4001564")]
		HomeAvailable = 2,
		[Token(Token = "0x4001565")]
		WinAdsButtonAvailable = 4
	}
}
