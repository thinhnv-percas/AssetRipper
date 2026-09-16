using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200005D")]
	public enum IAPProductType
	{
		[Token(Token = "0x4000230")]
		Consumable = 0,
		[Token(Token = "0x4000231")]
		NonConsumable = 1,
		[Token(Token = "0x4000232")]
		Subscription = 2
	}
}
