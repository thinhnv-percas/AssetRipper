using System;
using Cpp2ILInjected;

namespace Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000049")]
	public struct ShopItemVisualData
	{
		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x0")]
		public ShopOfferTag OfferTag;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x4")]
		public float FloatvValue;
	}
}
