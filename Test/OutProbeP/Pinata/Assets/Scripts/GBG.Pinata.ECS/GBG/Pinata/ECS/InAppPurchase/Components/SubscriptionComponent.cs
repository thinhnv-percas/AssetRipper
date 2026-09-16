using System;
using Cpp2ILInjected;
using EasyMobile;
using Morpeh;

namespace GBG.Pinata.ECS.InAppPurchase.Components
{
	[Serializable]
	[Token(Token = "0x2000061")]
	public struct SubscriptionComponent : IComponent
	{
		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x0")]
		public IAPProduct product;
	}
}
