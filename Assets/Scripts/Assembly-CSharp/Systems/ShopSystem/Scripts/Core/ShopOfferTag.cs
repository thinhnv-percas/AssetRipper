using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Core
{
	[Token(Token = "0x200004A")]
	public enum ShopOfferTag
	{
		[Token(Token = "0x40000A7")]
		None = 0,
		[Token(Token = "0x40000A8")]
		Discount = 1,
		[Token(Token = "0x40000A9")]
		BestValue = 2,
		[Token(Token = "0x40000AA")]
		Popular = 3,
		[Token(Token = "0x40000AB")]
		New = 4
	}
}
