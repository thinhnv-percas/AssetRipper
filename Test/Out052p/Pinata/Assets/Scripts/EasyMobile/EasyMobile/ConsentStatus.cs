using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000083")]
	public enum ConsentStatus
	{
		[Token(Token = "0x4000319")]
		Unknown = 0,
		[Token(Token = "0x400031A")]
		Granted = 1,
		[Token(Token = "0x400031B")]
		Revoked = 2
	}
}
