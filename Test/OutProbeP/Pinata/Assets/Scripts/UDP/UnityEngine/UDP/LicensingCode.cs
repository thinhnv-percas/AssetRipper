using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x2000006")]
	public enum LicensingCode
	{
		[Token(Token = "0x4000019")]
		RETRY = 0,
		[Token(Token = "0x400001A")]
		LICENSED = 1,
		[Token(Token = "0x400001B")]
		NOT_LICENSED = 2,
		[Token(Token = "0x400001C")]
		STORE_NOT_SUPPORT = 3
	}
}
