using Cpp2ILInjected;

namespace Unco.SettingsSyste.Core
{
	[Token(Token = "0x2000008")]
	public enum HapticCategory
	{
		[Token(Token = "0x400001D")]
		Default = 0,
		[Token(Token = "0x400001E")]
		CubeTap = 1,
		[Token(Token = "0x400001F")]
		ConveyorFlow = 2,
		[Token(Token = "0x4000020")]
		MoldFill = 3,
		[Token(Token = "0x4000021")]
		MoldComplete = 4,
		[Token(Token = "0x4000022")]
		LevelResult = 5
	}
}
