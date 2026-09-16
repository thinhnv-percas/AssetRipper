using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000035")]
	public class ChartboostSettings
	{
		[SerializeField]
		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x10")]
		private AdPlacement[] mCustomInterstitialPlacements;

		[SerializeField]
		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x18")]
		private AdPlacement[] mCustomRewardedPlacements;

		[Token(Token = "0x170000D9")]
		public AdPlacement[] CustomInterstitialPlacements
		{
			[Token(Token = "0x6000308")]
			[Address(RVA = "0xA4F2A0", Offset = "0xA4F2A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialPlacements;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomInterstitialPlacements;
			}
			[Token(Token = "0x6000309")]
			[Address(RVA = "0xA4F2A8", Offset = "0xA4F2A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mCustomInterstitialPlacements = value;\n\treturn;\n")]
			set
			{
				CustomInterstitialPlacements = value;
			}
		}

		[Token(Token = "0x170000DA")]
		public AdPlacement[] CustomRewardedPlacements
		{
			[Token(Token = "0x600030A")]
			[Address(RVA = "0xA4F2B0", Offset = "0xA4F2B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedPlacements;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CustomRewardedPlacements;
			}
			[Token(Token = "0x600030B")]
			[Address(RVA = "0xA4F2B8", Offset = "0xA4F2B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mCustomRewardedPlacements = value;\n\treturn;\n")]
			set
			{
				CustomRewardedPlacements = value;
			}
		}

		[Token(Token = "0x600030C")]
		[Address(RVA = "0xA4F2C0", Offset = "0xA4F2C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ChartboostSettings()
		{
		}
	}
}
