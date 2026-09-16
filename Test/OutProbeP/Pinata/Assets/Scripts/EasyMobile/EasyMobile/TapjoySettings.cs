using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x200003A")]
	public class TapjoySettings
	{
		[SerializeField]
		[Token(Token = "0x400019C")]
		[FieldOffset(Offset = "0x10")]
		private bool mAutoReconnect;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x732664", Offset = "0x732664")]
		[Token(Token = "0x400019D")]
		[FieldOffset(Offset = "0x14")]
		private float mAutoReconnectInterval;

		[SerializeField]
		[Token(Token = "0x400019E")]
		[FieldOffset(Offset = "0x18")]
		private AdId mDefaultInterstitialAdId;

		[SerializeField]
		[Token(Token = "0x400019F")]
		[FieldOffset(Offset = "0x20")]
		private AdId mDefaultRewardedAdId;

		[SerializeField]
		[Token(Token = "0x40001A0")]
		[FieldOffset(Offset = "0x28")]
		private Dictionary_AdPlacement_AdId mCustomInterstitialAdIds;

		[SerializeField]
		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0x30")]
		private Dictionary_AdPlacement_AdId mCustomRewardedAdIds;

		[Token(Token = "0x170000F1")]
		public bool EnableAutoReconnect
		{
			[Token(Token = "0x600033D")]
			[Address(RVA = "0xFD64D8", Offset = "0xFD64D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoReconnect;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return EnableAutoReconnect;
			}
			[Token(Token = "0x600033E")]
			[Address(RVA = "0xFD64E0", Offset = "0xFD64E0", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoReconnect = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mAutoReconnect = value;
			}
		}

		[Token(Token = "0x170000F2")]
		public float AutoReconnectInterval
		{
			[Token(Token = "0x600033F")]
			[Address(RVA = "0xFD64EC", Offset = "0xFD64EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoReconnectInterval;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AutoReconnectInterval;
			}
			[Token(Token = "0x6000340")]
			[Address(RVA = "0xFD64F4", Offset = "0xFD64F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoReconnectInterval = value;\n\treturn;\n")]
			set
			{
				AutoReconnectInterval = value;
			}
		}

		[Token(Token = "0x170000F3")]
		public AdId DefaultInterstitialAdId
		{
			[Token(Token = "0x6000341")]
			[Address(RVA = "0xFD64FC", Offset = "0xFD64FC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultInterstitialAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultInterstitialAdId;
			}
			[Token(Token = "0x6000342")]
			[Address(RVA = "0xFD6504", Offset = "0xFD6504", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultInterstitialAdId = value;\n\treturn;\n")]
			set
			{
				DefaultInterstitialAdId = value;
			}
		}

		[Token(Token = "0x170000F4")]
		public AdId DefaultRewardedAdId
		{
			[Token(Token = "0x6000343")]
			[Address(RVA = "0xFD650C", Offset = "0xFD650C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mDefaultRewardedAdId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DefaultRewardedAdId;
			}
			[Token(Token = "0x6000344")]
			[Address(RVA = "0xFD6514", Offset = "0xFD6514", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mDefaultRewardedAdId = value;\n\treturn;\n")]
			set
			{
				DefaultRewardedAdId = value;
			}
		}

		[Token(Token = "0x170000F5")]
		public Dictionary<AdPlacement, AdId> CustomInterstitialAdIds
		{
			[Token(Token = "0x6000345")]
			[Address(RVA = "0xFD651C", Offset = "0xFD651C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomInterstitialAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomInterstitialAdIds;
			}
			[Token(Token = "0x6000346")]
			[Address(RVA = "0xFD6524", Offset = "0xFD6524", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF91F0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256E5]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomInterstitialAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x170000F6")]
		public Dictionary<AdPlacement, AdId> CustomRewardedAdIds
		{
			[Token(Token = "0x6000347")]
			[Address(RVA = "0xFD65B4", Offset = "0xFD65B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mCustomRewardedAdIds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mCustomRewardedAdIds;
			}
			[Token(Token = "0x6000348")]
			[Address(RVA = "0xFD65BC", Offset = "0xFD65BC", Length = "0x90")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F057C0]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20256E6]) = v41;\nL_0015:\n\tv42 = value == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_003C;\n\tv95 = v95_asT == 0;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_003C;\nL_003C:\n\tthis.mCustomRewardedAdIds = v111;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x6000349")]
		[Address(RVA = "0xFD664C", Offset = "0xFD664C", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoReconnect = 1;\n\tthis.mAutoReconnectInterval = 10f;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TapjoySettings()
		{
			mAutoReconnect = true;
			AutoReconnectInterval = 10f;
		}
	}
}
