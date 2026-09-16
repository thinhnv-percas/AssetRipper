using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200007A")]
	internal enum AppleStoreProductType
	{
		[Token(Token = "0x40001E9")]
		NonConsumable = 0,
		[Token(Token = "0x40001EA")]
		Consumable = 1,
		[Token(Token = "0x40001EB")]
		NonRenewingSubscription = 2,
		[Token(Token = "0x40001EC")]
		AutoRenewingSubscription = 3
	}
}
