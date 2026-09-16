using Cpp2ILInjected;

namespace MoreMountains.NiceVibrations
{
	[Token(Token = "0x2000002")]
	public enum HapticTypes
	{
		[Token(Token = "0x4000002")]
		Selection = 0,
		[Token(Token = "0x4000003")]
		Success = 1,
		[Token(Token = "0x4000004")]
		Warning = 2,
		[Token(Token = "0x4000005")]
		Failure = 3,
		[Token(Token = "0x4000006")]
		LightImpact = 4,
		[Token(Token = "0x4000007")]
		MediumImpact = 5,
		[Token(Token = "0x4000008")]
		HeavyImpact = 6,
		[Token(Token = "0x4000009")]
		None = 7
	}
}
