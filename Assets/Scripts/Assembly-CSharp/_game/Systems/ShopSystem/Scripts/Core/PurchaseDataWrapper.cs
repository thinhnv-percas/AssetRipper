using System;
using Cpp2ILInjected;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000724")]
	public class PurchaseDataWrapper
	{
		[Token(Token = "0x40017F2")]
		[FieldOffset(Offset = "0x10")]
		public PurchaseData PurchaseData;

		[Token(Token = "0x6001E23")]
		[Address(RVA = "0x3D823B4", Offset = "0x3D823B4", Length = "0x8")]
		public PurchaseDataWrapper()
		{
		}
	}
}
