using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000021")]
	public enum AutoAdLoadingMode
	{
		[Token(Token = "0x400011E")]
		None = 0,
		[Token(Token = "0x400011F")]
		LoadDefaultAds = 1,
		[Token(Token = "0x4000120")]
		LoadAllDefinedPlacements = 2
	}
}
