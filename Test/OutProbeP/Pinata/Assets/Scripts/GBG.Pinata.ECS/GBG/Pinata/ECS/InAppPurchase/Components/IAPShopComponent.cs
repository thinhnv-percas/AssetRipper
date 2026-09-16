using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Morpeh;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x200005B")]
	public struct IAPShopComponent : IComponent
	{
		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x0")]
		public List<ShopSection> shopSections;
	}
}
