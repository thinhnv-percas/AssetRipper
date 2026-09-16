using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000004")]
	public enum AndroidStore
	{
		[Token(Token = "0x4000003")]
		GooglePlay = 0,
		[Token(Token = "0x4000004")]
		AmazonAppStore = 1,
		[Token(Token = "0x4000005")]
		CloudMoolah = 2,
		[Token(Token = "0x4000006")]
		SamsungApps = 3,
		[Token(Token = "0x4000007")]
		XiaomiMiPay = 4,
		[Token(Token = "0x4000008")]
		UDP = 5,
		[Token(Token = "0x4000009")]
		NotSpecified = 6
	}
}
