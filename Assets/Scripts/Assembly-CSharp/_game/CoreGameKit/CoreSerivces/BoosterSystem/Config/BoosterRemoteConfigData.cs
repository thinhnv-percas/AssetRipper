using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.BoosterSystem.Config
{
	[Serializable]
	[Token(Token = "0x200062D")]
	public class BoosterRemoteConfigData
	{
		[Token(Token = "0x400154F")]
		[FieldOffset(Offset = "0x10")]
		public string BoosterId;

		[Token(Token = "0x4001550")]
		[FieldOffset(Offset = "0x18")]
		public int VisibleFromLevel;

		[Token(Token = "0x4001551")]
		[FieldOffset(Offset = "0x1C")]
		public int UnlockLevel;

		[Token(Token = "0x4001552")]
		[FieldOffset(Offset = "0x20")]
		public int GiftCountOnUnlock;

		[Token(Token = "0x4001553")]
		[FieldOffset(Offset = "0x24")]
		public int PurchaseAmount;

		[Token(Token = "0x4001554")]
		[FieldOffset(Offset = "0x28")]
		public int PurchasePrice;

		[Token(Token = "0x6001A75")]
		[Address(RVA = "0x3D53814", Offset = "0x3D53814", Length = "0x8")]
		public BoosterRemoteConfigData()
		{
		}
	}
}
