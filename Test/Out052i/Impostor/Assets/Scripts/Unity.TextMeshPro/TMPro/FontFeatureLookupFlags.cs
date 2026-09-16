using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Flags]
	[Token(Token = "0x200004E")]
	public enum FontFeatureLookupFlags
	{
		[Token(Token = "0x400022E")]
		None = 0,
		[Token(Token = "0x400022F")]
		IgnoreLigatures = 4,
		[Token(Token = "0x4000230")]
		IgnoreSpacingAdjustments = 0x100
	}
}
