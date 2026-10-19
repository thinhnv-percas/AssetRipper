using System;
using Cpp2ILInjected;

namespace _game.Systems.MonetizationCore
{
	[Serializable]
	[Token(Token = "0x200076F")]
	public class InterstitialConfig
	{
		[Token(Token = "0x40018D2")]
		[FieldOffset(Offset = "0x10")]
		public bool enabled;

		[Token(Token = "0x40018D3")]
		[FieldOffset(Offset = "0x11")]
		public bool editorDebugMode;

		[Token(Token = "0x40018D4")]
		[FieldOffset(Offset = "0x14")]
		public float interDisplayIntervalInSeconds;

		[Token(Token = "0x40018D5")]
		[FieldOffset(Offset = "0x18")]
		public int interDisplayLevelFrequency;

		[Token(Token = "0x40018D6")]
		[FieldOffset(Offset = "0x1C")]
		public int firstLevelToDisplayInter;

		[Token(Token = "0x40018D7")]
		[FieldOffset(Offset = "0x20")]
		public float firstInterDisplayTimeAfterStartInSeconds;

		[Token(Token = "0x40018D8")]
		[FieldOffset(Offset = "0x24")]
		public int firstDayToDisplayInter;

		[Token(Token = "0x40018D9")]
		[FieldOffset(Offset = "0x28")]
		public bool useCalendarDayCheck;

		[Token(Token = "0x40018DA")]
		[FieldOffset(Offset = "0x2C")]
		public int firstDayToDisplayBanner;

		[Token(Token = "0x40018DB")]
		[FieldOffset(Offset = "0x30")]
		public bool noBanner;

		[Token(Token = "0x40018DC")]
		[FieldOffset(Offset = "0x34")]
		public int firstLevelToShowRewardedOffer;

		[Token(Token = "0x40018DD")]
		[FieldOffset(Offset = "0x38")]
		public float rewardedInterstitialBufferSeconds;

		[Token(Token = "0x40018DE")]
		[FieldOffset(Offset = "0x3C")]
		public bool logEligibilityReasons;

		[Token(Token = "0x6001F5D")]
		[Address(RVA = "0x3D8F0C4", Offset = "0x3D8F0C4", Length = "0x40")]
		public InterstitialConfig()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InterstitialConfig::.ctor");
		}
	}
}
