using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000036")]
	public class HeyzapSettings
	{
		[SerializeField]
		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x10")]
		private string mPublisherId;

		[SerializeField]
		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x18")]
		private bool mShowTestSuite;

		[SerializeField]
		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x20")]
		private AdPlacement[] mCustomInterstitialPlacements;

		[SerializeField]
		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x28")]
		private AdPlacement[] mCustomRewardedPlacements;

		[Token(Token = "0x170000DB")]
		public string PublisherId
		{
			[Token(Token = "0x600030D")]
			[Address(RVA = "0xBF528C", Offset = "0xBF528C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mPublisherId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PublisherId;
			}
			[Token(Token = "0x600030E")]
			[Address(RVA = "0xBF5294", Offset = "0xBF5294", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mPublisherId = value;\n\treturn;\n")]
			set
			{
				PublisherId = value;
			}
		}

		[Token(Token = "0x170000DC")]
		public AdPlacement[] CustomInterstitialPlacements
		{
			[Token(Token = "0x600030F")]
			[Address(RVA = "0xBF529C", Offset = "0xBF529C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialPlacements;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomInterstitialPlacements;
			}
			[Token(Token = "0x6000310")]
			[Address(RVA = "0xBF52A4", Offset = "0xBF52A4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mCustomInterstitialPlacements = value;\n\treturn;\n")]
			set
			{
				CustomInterstitialPlacements = value;
			}
		}

		[Token(Token = "0x170000DD")]
		public AdPlacement[] CustomRewardedPlacements
		{
			[Token(Token = "0x6000311")]
			[Address(RVA = "0xBF52AC", Offset = "0xBF52AC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedPlacements;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomRewardedPlacements;
			}
			[Token(Token = "0x6000312")]
			[Address(RVA = "0xBF52B4", Offset = "0xBF52B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mCustomRewardedPlacements = value;\n\treturn;\n")]
			set
			{
				CustomRewardedPlacements = value;
			}
		}

		[Token(Token = "0x170000DE")]
		public bool ShowTestSuite
		{
			[Token(Token = "0x6000313")]
			[Address(RVA = "0xBF52BC", Offset = "0xBF52BC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mShowTestSuite;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ShowTestSuite;
			}
			[Token(Token = "0x6000314")]
			[Address(RVA = "0xBF52C4", Offset = "0xBF52C4", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mShowTestSuite = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mShowTestSuite = value;
			}
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0xBF52D0", Offset = "0xBF52D0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HeyzapSettings()
		{
		}
	}
}
