using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Hypercasual.Code.Utils.Apple;
using Sirenix.Utilities;
using UnityEngine;

namespace Morpeh.Hypercasual.Code.Utils
{
	[AttributeAttribute(Type = typeof(GlobalConfigAttribute), RVA = "0x743E24", Offset = "0x743E24")]
	[Token(Token = "0x2000009")]
	public class KeysConfig : GlobalConfig<KeysConfig>
	{
		[Serializable]
		[Token(Token = "0x2000017")]
		public class PlatformPair
		{
			[Token(Token = "0x400003D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string iOS;

			[Token(Token = "0x400003E")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string Android;

			[Token(Token = "0x6000026")]
			[Address(RVA = "0x1633844", Offset = "0x1633844", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public PlatformPair()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000018")]
		public struct AnalyticsSettings
		{
			[Token(Token = "0x400003F")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string Tenjin;

			[Token(Token = "0x4000040")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public string AppsFlyer;

			[Token(Token = "0x4000041")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string Adjust;

			[Token(Token = "0x4000042")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public PlatformPair AppMetrica;

			[Token(Token = "0x4000043")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public PlatformPair MyTracker;
		}

		[Serializable]
		[Token(Token = "0x2000019")]
		public struct AdvertisingSettings
		{
			[Serializable]
			[Token(Token = "0x200001C")]
			public class SpecialPlatformPair : PlatformPair
			{
				[Token(Token = "0x400004E")]
				[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
				public bool DontUseIronSource;

				[Token(Token = "0x6000027")]
				[Address(RVA = "0x163383C", Offset = "0x163383C", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				public SpecialPlatformPair()
				{
				}
			}

			[Token(Token = "0x4000044")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public PlatformPair IronSource;

			[Token(Token = "0x4000045")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public SpecialPlatformPair Admob;
		}

		[Serializable]
		[Token(Token = "0x200001A")]
		public struct iOSSettings
		{
			[Token(Token = "0x4000046")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int appID;

			[Token(Token = "0x4000047")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public List<iOSFrameworkDescription> frameworks;

			[Token(Token = "0x4000048")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public List<BuildProperties> flags;

			[Token(Token = "0x4000049")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public PlistKeys plistKeys;
		}

		[Serializable]
		[StructLayout((LayoutKind)0, Size = 32)]
		[Token(Token = "0x200001B")]
		public struct AndroidSettings
		{
			[Delayed]
			[Token(Token = "0x400004A")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public string keystoreName;

			[Delayed]
			[Token(Token = "0x400004B")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public string keystorePass;

			[Delayed]
			[Token(Token = "0x400004C")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public string keyaliasName;

			[Delayed]
			[Token(Token = "0x400004D")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public string keyaliasPass;
		}

		[Token(Token = "0x400001C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public AnalyticsSettings Analytics;

		[Token(Token = "0x400001D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public AdvertisingSettings Advertising;

		[Token(Token = "0x400001E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x50")]
		public iOSSettings iOS;

		[Token(Token = "0x400001F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		public AndroidSettings Android;

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x16337EC", Offset = "0x16337EC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA8918]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A4DC]) = v38;\nL_001C:\n\tSirenix.Utilities.GlobalConfig`1<Morpeh.Hypercasual.Code.Utils.KeysConfig>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public KeysConfig()
		{
		}
	}
}
