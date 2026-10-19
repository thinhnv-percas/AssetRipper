using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Purchase
{
	[Token(Token = "0x200061E")]
	public interface IBoosterPurchaseOffer
	{
		[Token(Token = "0x17000282")]
		string BoosterId
		{
			[Token(Token = "0x6001A2F")]
			get;
		}

		[Token(Token = "0x17000283")]
		int Amount
		{
			[Token(Token = "0x6001A30")]
			get;
		}

		[Token(Token = "0x17000284")]
		string PriceDisplay
		{
			[Token(Token = "0x6001A31")]
			get;
		}

		[Token(Token = "0x17000285")]
		Sprite CurrencyIcon
		{
			[Token(Token = "0x6001A32")]
			get;
		}
	}
}
