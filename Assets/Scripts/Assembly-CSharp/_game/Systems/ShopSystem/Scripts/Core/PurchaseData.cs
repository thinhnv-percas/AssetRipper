using System;
using Cpp2ILInjected;

namespace _game.Systems.ShopSystem.Scripts.Core
{
	[Serializable]
	[Token(Token = "0x2000723")]
	public class PurchaseData
	{
		[Token(Token = "0x40017EA")]
		[FieldOffset(Offset = "0x10")]
		public string orderId;

		[Token(Token = "0x40017EB")]
		[FieldOffset(Offset = "0x18")]
		public string packageName;

		[Token(Token = "0x40017EC")]
		[FieldOffset(Offset = "0x20")]
		public string productId;

		[Token(Token = "0x40017ED")]
		[FieldOffset(Offset = "0x28")]
		public long purchaseTime;

		[Token(Token = "0x40017EE")]
		[FieldOffset(Offset = "0x30")]
		public int purchaseState;

		[Token(Token = "0x40017EF")]
		[FieldOffset(Offset = "0x38")]
		public string purchaseToken;

		[Token(Token = "0x40017F0")]
		[FieldOffset(Offset = "0x40")]
		public int quantity;

		[Token(Token = "0x40017F1")]
		[FieldOffset(Offset = "0x44")]
		public bool acknowledged;

		[Token(Token = "0x6001E22")]
		[Address(RVA = "0x3D817C8", Offset = "0x3D817C8", Length = "0x10")]
		public PurchaseData()
		{
			quantity = 1;
		}
	}
}
