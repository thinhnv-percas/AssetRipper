using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Purchase
{
	[Token(Token = "0x200061D")]
	public interface IBoosterPurchaseHandler
	{
		[Token(Token = "0x6001A2D")]
		IBoosterPurchaseOffer GetOffer(string boosterId);

		[Token(Token = "0x6001A2E")]
		void Purchase(IBoosterPurchaseOffer offer, Action<bool> onComplete);
	}
}
