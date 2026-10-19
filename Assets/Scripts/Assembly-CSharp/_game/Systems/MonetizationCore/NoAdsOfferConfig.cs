using System;
using Cpp2ILInjected;

namespace _game.Systems.MonetizationCore
{
	[Serializable]
	[Token(Token = "0x2000774")]
	public class NoAdsOfferConfig
	{
		[Token(Token = "0x40018EC")]
		[FieldOffset(Offset = "0x10")]
		public int startAfterEventCount;

		[Token(Token = "0x40018ED")]
		[FieldOffset(Offset = "0x14")]
		public int repeatEveryNEvents;

		[Token(Token = "0x40018EE")]
		[FieldOffset(Offset = "0x18")]
		public int maxShowCount;

		[Token(Token = "0x6001F70")]
		[Address(RVA = "0x3D8FFE8", Offset = "0x3D8FFE8", Length = "0x1C")]
		public NoAdsOfferConfig()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("NoAdsOfferConfig::.ctor");
		}
	}
}
