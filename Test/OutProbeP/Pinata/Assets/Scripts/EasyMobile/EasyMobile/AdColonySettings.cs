using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000031")]
	public class AdColonySettings
	{
		[SerializeField]
		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x10")]
		private AdId mAppId;

		[SerializeField]
		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x18")]
		private AdOrientation mOrientation;

		[SerializeField]
		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x1C")]
		private bool mEnableRewardedAdPrePopup;

		[SerializeField]
		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x1D")]
		private bool mEnableRewardedAdPostPopup;

		[SerializeField]
		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x20")]
		private AdId mDefaultInterstitialAdId;

		[SerializeField]
		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x28")]
		private AdId mDefaultRewardedAdId;

		[SerializeField]
		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x30")]
		private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;

		[SerializeField]
		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x38")]
		private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;

		[Token(Token = "0x170000B6")]
		public AdId AppId
		{
			[Token(Token = "0x60002BE")]
			[Address(RVA = "0xA453E4", Offset = "0xA453E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAppId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppId;
			}
			[Token(Token = "0x60002BF")]
			[Address(RVA = "0xA453EC", Offset = "0xA453EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAppId = value;\n\treturn;\n")]
			set
			{
				AppId = value;
			}
		}

		[Token(Token = "0x170000B7")]
		public AdOrientation Orientation
		{
			[Token(Token = "0x60002C0")]
			[Address(RVA = "0xA453F4", Offset = "0xA453F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mOrientation;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Orientation;
			}
			[Token(Token = "0x60002C1")]
			[Address(RVA = "0xA453FC", Offset = "0xA453FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mOrientation = value;\n\treturn;\n")]
			set
			{
				Orientation = value;
			}
		}

		[Token(Token = "0x170000B8")]
		public bool EnableRewardedAdPrePopup
		{
			[Token(Token = "0x60002C2")]
			[Address(RVA = "0xA45404", Offset = "0xA45404", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableRewardedAdPrePopup;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableRewardedAdPrePopup;
			}
			[Token(Token = "0x60002C3")]
			[Address(RVA = "0xA4540C", Offset = "0xA4540C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableRewardedAdPrePopup = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableRewardedAdPrePopup = value;
			}
		}

		[Token(Token = "0x170000B9")]
		public bool EnableRewardedAdPostPopup
		{
			[Token(Token = "0x60002C4")]
			[Address(RVA = "0xA45418", Offset = "0xA45418", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableRewardedAdPostPopup;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableRewardedAdPostPopup;
			}
			[Token(Token = "0x60002C5")]
			[Address(RVA = "0xA45420", Offset = "0xA45420", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableRewardedAdPostPopup = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableRewardedAdPostPopup = value;
			}
		}

		[Token(Token = "0x170000BA")]
		public AdId DefaultInterstitialAdId
		{
			[Token(Token = "0x60002C6")]
			[Address(RVA = "0xA4542C", Offset = "0xA4542C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultInterstitialAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultInterstitialAdId;
			}
			[Token(Token = "0x60002C7")]
			[Address(RVA = "0xA45434", Offset = "0xA45434", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultInterstitialAdId = value;\n\treturn;\n")]
			set
			{
				DefaultInterstitialAdId = value;
			}
		}

		[Token(Token = "0x170000BB")]
		public AdId DefaultRewardedAdId
		{
			[Token(Token = "0x60002C8")]
			[Address(RVA = "0xA4543C", Offset = "0xA4543C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRewardedAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRewardedAdId;
			}
			[Token(Token = "0x60002C9")]
			[Address(RVA = "0xA45444", Offset = "0xA45444", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRewardedAdId = value;\n\treturn;\n")]
			set
			{
				DefaultRewardedAdId = value;
			}
		}

		[Token(Token = "0x170000BC")]
		public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
		{
			[Token(Token = "0x60002CA")]
			[Address(RVA = "0xA4544C", Offset = "0xA4544C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomInterstitialAdIds;
			}
			[Token(Token = "0x60002CB")]
			[Address(RVA = "0xA45454", Offset = "0xA45454", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF01F0]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EB2]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0037;\n\tgoto L_FFFFFFFF;\n\tv63 = v63_asT == 0;\n\tif (v63) goto L_0040;\nL_0037:\n\tthis.mCustomRewardedAdIds = value;\n\treturn;\nL_0040:\n\tthrow System.InvalidCastException;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != null)
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					if (dictionary_AdPlacement_AdId == null)
					{
						throw new InvalidCastException();
					}
				}
				mCustomRewardedAdIds = (Dictionary_AdPlacement_AdId)value;
			}
		}

		[Token(Token = "0x170000BD")]
		public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
		{
			[Token(Token = "0x60002CC")]
			[Address(RVA = "0xA454E4", Offset = "0xA454E4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomRewardedAdIds;
			}
			[Token(Token = "0x60002CD")]
			[Address(RVA = "0xA454EC", Offset = "0xA454EC", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EEED28]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021EB3]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_0037;\n\tgoto L_FFFFFFFF;\n\tv63 = v63_asT == 0;\n\tif (v63) goto L_0040;\nL_0037:\n\tthis.mCustomRewardedAdIds = value;\n\treturn;\nL_0040:\n\tthrow System.InvalidCastException;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				if (value != null)
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					if (dictionary_AdPlacement_AdId == null)
					{
						throw new InvalidCastException();
					}
				}
				mCustomRewardedAdIds = (Dictionary_AdPlacement_AdId)value;
			}
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0xA4557C", Offset = "0xA4557C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mOrientation = 2;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AdColonySettings()
		{
			Orientation = AdOrientation.AdOrientationAll;
		}
	}
}
