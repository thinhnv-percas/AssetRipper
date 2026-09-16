using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000011")]
	public enum ProductType
	{
		[Token(Token = "0x400002C")]
		Consumable = 0,
		[Token(Token = "0x400002D")]
		NonConsumable = 1,
		[Token(Token = "0x400002E")]
		Subscription = 2
	}
}
