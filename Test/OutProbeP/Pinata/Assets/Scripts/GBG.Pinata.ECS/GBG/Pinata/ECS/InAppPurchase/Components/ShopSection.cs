using System;
using Cpp2ILInjected;
using TMPro;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x200005C")]
	public struct ShopSection
	{
		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x0")]
		public string productName;

		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x8")]
		public TextMeshProUGUI reward;

		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x10")]
		public TextMeshProUGUI extraReward;

		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x18")]
		public TextMeshProUGUI price;
	}
}
