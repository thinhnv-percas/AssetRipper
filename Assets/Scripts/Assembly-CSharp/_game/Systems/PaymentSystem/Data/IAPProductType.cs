using Cpp2ILInjected;

namespace _game.Systems.PaymentSystem.Data
{
	[Token(Token = "0x200074E")]
	public enum IAPProductType
	{
		[Token(Token = "0x4001871")]
		Consumable = 0,
		[Token(Token = "0x4001872")]
		NonConsumable = 1,
		[Token(Token = "0x4001873")]
		Subscription = 2
	}
}
