using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000033")]
	public class AppLovinSettings
	{
		[SerializeField]
		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x10")]
		private bool mEnableTestMode;

		[SerializeField]
		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x11")]
		private bool mAgeRestrictMode;

		[SerializeField]
		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x18")]
		private string mSDKKey;

		[SerializeField]
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x20")]
		private AdId mDefaultBannerAdId;

		[SerializeField]
		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x28")]
		private AdId mDefaultInterstitialAdId;

		[SerializeField]
		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x30")]
		private AdId mDefaultRewardedAdId;

		[SerializeField]
		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x38")]
		private Dictionary_AdPlacement_AdId mCustomBannerAdIds;

		[SerializeField]
		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x40")]
		private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;

		[SerializeField]
		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x48")]
		private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;

		[Token(Token = "0x170000C7")]
		public string SDKKey
		{
			[Token(Token = "0x60002E2")]
			[Address(RVA = "0xA4E5F0", Offset = "0xA4E5F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mSDKKey;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SDKKey;
			}
			[Token(Token = "0x60002E3")]
			[Address(RVA = "0xA4E5F8", Offset = "0xA4E5F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mSDKKey = value;\n\treturn;\n")]
			set
			{
				SDKKey = value;
			}
		}

		[Token(Token = "0x170000C8")]
		public AdId DefaultBannerAdId
		{
			[Token(Token = "0x60002E4")]
			[Address(RVA = "0xA4E600", Offset = "0xA4E600", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultBannerAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultBannerAdId;
			}
			[Token(Token = "0x60002E5")]
			[Address(RVA = "0xA4E608", Offset = "0xA4E608", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultBannerAdId = value;\n\treturn;\n")]
			set
			{
				DefaultBannerAdId = value;
			}
		}

		[Token(Token = "0x170000C9")]
		public AdId DefaultInterstitialAdId
		{
			[Token(Token = "0x60002E6")]
			[Address(RVA = "0xA4E610", Offset = "0xA4E610", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultInterstitialAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultInterstitialAdId;
			}
			[Token(Token = "0x60002E7")]
			[Address(RVA = "0xA4E618", Offset = "0xA4E618", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultInterstitialAdId = value;\n\treturn;\n")]
			set
			{
				DefaultInterstitialAdId = value;
			}
		}

		[Token(Token = "0x170000CA")]
		public AdId DefaultRewardedAdId
		{
			[Token(Token = "0x60002E8")]
			[Address(RVA = "0xA4E620", Offset = "0xA4E620", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRewardedAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRewardedAdId;
			}
			[Token(Token = "0x60002E9")]
			[Address(RVA = "0xA4E628", Offset = "0xA4E628", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRewardedAdId = value;\n\treturn;\n")]
			set
			{
				DefaultRewardedAdId = value;
			}
		}

		[Token(Token = "0x170000CB")]
		public bool EnableTestMode
		{
			[Token(Token = "0x60002EA")]
			[Address(RVA = "0xA4E630", Offset = "0xA4E630", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableTestMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableTestMode;
			}
			[Token(Token = "0x60002EB")]
			[Address(RVA = "0xA4E638", Offset = "0xA4E638", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mEnableTestMode = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mEnableTestMode = value;
			}
		}

		[Token(Token = "0x170000CC")]
		public bool AgeRestrictMode
		{
			[Token(Token = "0x60002EC")]
			[Address(RVA = "0xA4E644", Offset = "0xA4E644", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAgeRestrictMode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AgeRestrictMode;
			}
			[Token(Token = "0x60002ED")]
			[Address(RVA = "0xA4E64C", Offset = "0xA4E64C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAgeRestrictMode = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mAgeRestrictMode = value;
			}
		}

		[Token(Token = "0x170000CD")]
		public Dictionary<AdPlacement, AdId> CustomBannerAdIds
		{
			[Token(Token = "0x60002EE")]
			[Address(RVA = "0xA4E658", Offset = "0xA4E658", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomBannerAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomBannerAdIds;
			}
			[Token(Token = "0x60002EF")]
			[Address(RVA = "0xA4E660", Offset = "0xA4E660", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBCFC8]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F3F]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomBannerAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Dictionary<AdPlacement, AdId> dictionary;
				if (value == null)
				{
					dictionary = null;
				}
				else
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					dictionary = ((dictionary_AdPlacement_AdId == null) ? null : value);
				}
				mCustomBannerAdIds = (Dictionary_AdPlacement_AdId)dictionary;
			}
		}

		[Token(Token = "0x170000CE")]
		public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
		{
			[Token(Token = "0x60002F0")]
			[Address(RVA = "0xA4E6F0", Offset = "0xA4E6F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomInterstitialAdIds;
			}
			[Token(Token = "0x60002F1")]
			[Address(RVA = "0xA4E6F8", Offset = "0xA4E6F8", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF5690]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F40]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomInterstitialAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Dictionary<AdPlacement, AdId> dictionary;
				if (value == null)
				{
					dictionary = null;
				}
				else
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					dictionary = ((dictionary_AdPlacement_AdId == null) ? null : value);
				}
				mCustomInterstitialAdIds = (Dictionary_AdPlacement_AdId)dictionary;
			}
		}

		[Token(Token = "0x170000CF")]
		public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
		{
			[Token(Token = "0x60002F2")]
			[Address(RVA = "0xA4E788", Offset = "0xA4E788", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomRewardedAdIds;
			}
			[Token(Token = "0x60002F3")]
			[Address(RVA = "0xA4E790", Offset = "0xA4E790", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE3C88]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021F41]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomRewardedAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				Dictionary<AdPlacement, AdId> dictionary;
				if (value == null)
				{
					dictionary = null;
				}
				else
				{
					Dictionary_AdPlacement_AdId dictionary_AdPlacement_AdId = value as Dictionary_AdPlacement_AdId;
					dictionary = ((dictionary_AdPlacement_AdId == null) ? null : value);
				}
				mCustomRewardedAdIds = (Dictionary_AdPlacement_AdId)dictionary;
			}
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0xA4E820", Offset = "0xA4E820", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppLovinSettings()
		{
		}
	}
}
