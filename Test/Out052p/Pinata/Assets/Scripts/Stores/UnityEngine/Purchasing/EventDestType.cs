using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000056")]
	public enum EventDestType
	{
		[Token(Token = "0x40000FF")]
		Unknown = 0,
		[Token(Token = "0x4000100")]
		AdsTracking = 1,
		[Token(Token = "0x4000101")]
		IAP = 2,
		[Token(Token = "0x4000102")]
		Analytics = 3,
		[Token(Token = "0x4000103")]
		CDP = 4,
		[Token(Token = "0x4000104")]
		CDPDirect = 5,
		[Token(Token = "0x4000105")]
		AdsIPC = 6
	}
}
