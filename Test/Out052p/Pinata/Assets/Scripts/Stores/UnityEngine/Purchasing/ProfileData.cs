using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Uniject;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200006D")]
	internal class ProfileData
	{
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x10")]
		private IUtil m_Util;

		[Token(Token = "0x400016C")]
		private static ProfileData ProfileInstance;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72C964", Offset = "0x72C964")]
		[CompilerGenerated]
		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x18")]
		private string _003CAppId_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72C9A0", Offset = "0x72C9A0")]
		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x20")]
		private string _003CUserId_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72C9DC", Offset = "0x72C9DC")]
		[CompilerGenerated]
		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x28")]
		private ulong _003CSessionId_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CA18", Offset = "0x72CA18")]
		[CompilerGenerated]
		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x30")]
		private string _003CPlatform_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CA54", Offset = "0x72CA54")]
		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x38")]
		private int _003CPlatformId_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CA90", Offset = "0x72CA90")]
		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x40")]
		private string _003CSdkVer_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CACC", Offset = "0x72CACC")]
		[CompilerGenerated]
		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x48")]
		private string _003COsVer_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CB08", Offset = "0x72CB08")]
		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x50")]
		private int _003CScreenWidth_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CB44", Offset = "0x72CB44")]
		[CompilerGenerated]
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x54")]
		private int _003CScreenHeight_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CB80", Offset = "0x72CB80")]
		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x58")]
		private float _003CScreenDpi_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CBBC", Offset = "0x72CBBC")]
		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x60")]
		private string _003CScreenOrientation_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CBF8", Offset = "0x72CBF8")]
		[CompilerGenerated]
		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x68")]
		private string _003CDeviceId_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CC70", Offset = "0x72CC70")]
		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x78")]
		private string _003CIapVer_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CCAC", Offset = "0x72CCAC")]
		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x80")]
		internal string _003CAdsGamerToken_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CCE8", Offset = "0x72CCE8")]
		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x88")]
		internal bool? _003CTrackingOptOut_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CD24", Offset = "0x72CD24")]
		[CompilerGenerated]
		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x8C")]
		internal int? _003CAdsABGroup_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CD60", Offset = "0x72CD60")]
		[CompilerGenerated]
		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x98")]
		internal string _003CAdsGameId_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CD9C", Offset = "0x72CD9C")]
		[CompilerGenerated]
		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0xA0")]
		internal int? _003CStoreABGroup_003Ek__BackingField;

		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CDD8", Offset = "0x72CDD8")]
		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0xA8")]
		internal string _003CCatalogId_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CE50", Offset = "0x72CE50")]
		[CompilerGenerated]
		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0xB8")]
		internal string _003CStoreName_003Ek__BackingField;

		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x72CE8C", Offset = "0x72CE8C")]
		[CompilerGenerated]
		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0xC0")]
		private string _003CGameVersion_003Ek__BackingField;

		[Token(Token = "0x17000035")]
		public string AppId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000190")]
			[Address(RVA = "0xC6B9B0", Offset = "0xC6B9B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AppId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000191")]
			[Address(RVA = "0xC6B9B8", Offset = "0xC6B9B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AppId>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CAppId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000036")]
		public string UserId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000192")]
			[Address(RVA = "0xC6B9C0", Offset = "0xC6B9C0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UserId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UserId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000193")]
			[Address(RVA = "0xC6B9C8", Offset = "0xC6B9C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UserId>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CUserId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000037")]
		public ulong SessionId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000194")]
			[Address(RVA = "0xC6B9D0", Offset = "0xC6B9D0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SessionId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SessionId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000195")]
			[Address(RVA = "0xC6B9D8", Offset = "0xC6B9D8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SessionId>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CSessionId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000038")]
		public string Platform
		{
			[CompilerGenerated]
			[Token(Token = "0x6000196")]
			[Address(RVA = "0xC6B9E0", Offset = "0xC6B9E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Platform>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Platform;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000197")]
			[Address(RVA = "0xC6B9E8", Offset = "0xC6B9E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Platform>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CPlatform_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000039")]
		public int PlatformId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000198")]
			[Address(RVA = "0xC6B9F0", Offset = "0xC6B9F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<PlatformId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return PlatformId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000199")]
			[Address(RVA = "0xC6B9F8", Offset = "0xC6B9F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<PlatformId>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CPlatformId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003A")]
		public string SdkVer
		{
			[CompilerGenerated]
			[Token(Token = "0x600019A")]
			[Address(RVA = "0xC6BA00", Offset = "0xC6BA00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<SdkVer>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SdkVer;
			}
			[CompilerGenerated]
			[Token(Token = "0x600019B")]
			[Address(RVA = "0xC6BA08", Offset = "0xC6BA08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<SdkVer>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CSdkVer_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003B")]
		public string OsVer
		{
			[CompilerGenerated]
			[Token(Token = "0x600019C")]
			[Address(RVA = "0xC6BA10", Offset = "0xC6BA10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<OsVer>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return OsVer;
			}
			[CompilerGenerated]
			[Token(Token = "0x600019D")]
			[Address(RVA = "0xC6BA18", Offset = "0xC6BA18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<OsVer>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003COsVer_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003C")]
		public int ScreenWidth
		{
			[CompilerGenerated]
			[Token(Token = "0x600019E")]
			[Address(RVA = "0xC6BA20", Offset = "0xC6BA20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ScreenWidth>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScreenWidth;
			}
			[CompilerGenerated]
			[Token(Token = "0x600019F")]
			[Address(RVA = "0xC6BA28", Offset = "0xC6BA28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ScreenWidth>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CScreenWidth_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003D")]
		public int ScreenHeight
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A0")]
			[Address(RVA = "0xC6BA30", Offset = "0xC6BA30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ScreenHeight>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScreenHeight;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A1")]
			[Address(RVA = "0xC6BA38", Offset = "0xC6BA38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ScreenHeight>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CScreenHeight_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003E")]
		public float ScreenDpi
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0xC6BA40", Offset = "0xC6BA40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ScreenDpi>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScreenDpi;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A3")]
			[Address(RVA = "0xC6BA48", Offset = "0xC6BA48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ScreenDpi>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CScreenDpi_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700003F")]
		public string ScreenOrientation
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A4")]
			[Address(RVA = "0xC6BA50", Offset = "0xC6BA50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ScreenOrientation>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ScreenOrientation;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0xC6BA58", Offset = "0xC6BA58", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ScreenOrientation>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CScreenOrientation_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000040")]
		public string DeviceId
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A6")]
			[Address(RVA = "0xC6BA60", Offset = "0xC6BA60", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<DeviceId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return DeviceId;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001A7")]
			[Address(RVA = "0xC6BA68", Offset = "0xC6BA68", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<DeviceId>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CDeviceId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000041")]
		public string BuildGUID
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A8")]
			[Address(RVA = "0xC6BA70", Offset = "0xC6BA70", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<BuildGUID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BuildGUID;
			}
		}

		[Token(Token = "0x17000042")]
		public string IapVer
		{
			[CompilerGenerated]
			[Token(Token = "0x60001A9")]
			[Address(RVA = "0xC6BA78", Offset = "0xC6BA78", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<IapVer>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IapVer;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001AA")]
			[Address(RVA = "0xC6BA80", Offset = "0xC6BA80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<IapVer>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CIapVer_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000043")]
		public string AdsGamerToken
		{
			[CompilerGenerated]
			[Token(Token = "0x60001AB")]
			[Address(RVA = "0xC6BA88", Offset = "0xC6BA88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdsGamerToken>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdsGamerToken;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001AC")]
			[Address(RVA = "0xC6BA90", Offset = "0xC6BA90", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdsGamerToken>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CAdsGamerToken_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000044")]
		public bool? TrackingOptOut
		{
			[CompilerGenerated]
			[Token(Token = "0x60001AD")]
			[Address(RVA = "0xC6BA98", Offset = "0xC6BA98", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TrackingOptOut>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return TrackingOptOut;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001AE")]
			[Address(RVA = "0xC6BAA0", Offset = "0xC6BAA0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TrackingOptOut>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CTrackingOptOut_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000045")]
		public int? AdsABGroup
		{
			[CompilerGenerated]
			[Token(Token = "0x60001AF")]
			[Address(RVA = "0xC6BAA8", Offset = "0xC6BAA8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdsABGroup>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdsABGroup;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001B0")]
			[Address(RVA = "0xC6BAB0", Offset = "0xC6BAB0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdsABGroup>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CAdsABGroup_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000046")]
		public string AdsGameId
		{
			[CompilerGenerated]
			[Token(Token = "0x60001B1")]
			[Address(RVA = "0xC6BAB8", Offset = "0xC6BAB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AdsGameId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AdsGameId;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001B2")]
			[Address(RVA = "0xC6BAC0", Offset = "0xC6BAC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AdsGameId>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CAdsGameId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000047")]
		public int? StoreABGroup
		{
			[CompilerGenerated]
			[Token(Token = "0x60001B3")]
			[Address(RVA = "0xC6BAC8", Offset = "0xC6BAC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StoreABGroup>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StoreABGroup;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001B4")]
			[Address(RVA = "0xC6BAD0", Offset = "0xC6BAD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StoreABGroup>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CStoreABGroup_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000048")]
		public string CatalogId
		{
			[CompilerGenerated]
			[Token(Token = "0x60001B5")]
			[Address(RVA = "0xC6BAD8", Offset = "0xC6BAD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<CatalogId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return CatalogId;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001B6")]
			[Address(RVA = "0xC6BAE0", Offset = "0xC6BAE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<CatalogId>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CCatalogId_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000049")]
		public string MonetizationId
		{
			[CompilerGenerated]
			[Token(Token = "0x60001B7")]
			[Address(RVA = "0xC6BAE8", Offset = "0xC6BAE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<MonetizationId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MonetizationId;
			}
		}

		[Token(Token = "0x1700004A")]
		public string StoreName
		{
			[CompilerGenerated]
			[Token(Token = "0x60001B8")]
			[Address(RVA = "0xC6BAF0", Offset = "0xC6BAF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StoreName>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StoreName;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0xC6BAF8", Offset = "0xC6BAF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StoreName>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CStoreName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700004B")]
		public string GameVersion
		{
			[CompilerGenerated]
			[Token(Token = "0x60001BA")]
			[Address(RVA = "0xC6BB00", Offset = "0xC6BB00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<GameVersion>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GameVersion;
			}
			[CompilerGenerated]
			[Token(Token = "0x60001BB")]
			[Address(RVA = "0xC6BB08", Offset = "0xC6BB08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<GameVersion>k__BackingField = value;\n\treturn;\n")]
			internal set
			{
				_003CGameVersion_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x1700004C")]
		public bool? StoreTestEnabled
		{
			[CompilerGenerated]
			[Token(Token = "0x60001BC")]
			[Address(RVA = "0xC6BB10", Offset = "0xC6BB10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<StoreTestEnabled>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return StoreTestEnabled;
			}
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0xC6BB18", Offset = "0xC6BB18", Length = "0x62C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EC3E60]);\n\tv27 = *([v26 @ X8_v68]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, util, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2023399]) = v45;\nL_001A:\n\tSystem.Object::.ctor(this);\n\tthis.m_Util = util;\n\tv51 = util->klass;\n\tv55 = *([v51 @ X8_v4 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v55) goto L_0042;\n\tv156 = *([v51 @ X8_v4 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_002D:\n\tv161 = *([v156 @ X11_v78-8]) == Uniject.IUtil;\n\tif (v161) goto L_0045;\n\tv155 = v155 + 1;\n\tv166 = v155 < *([v51 @ X8_v4 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv88 = ~v166;\n\tv156 = v156 + 0x10;\n\tv64 = ~v88;\n\tif (v64) goto L_002D;\nL_0042:\n\tthis = 0x8909C4(util, Uniject.IUtil, 2, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_004C;\nL_0045:\n\tv168 = *([v156 @ X11_v78]) + 2;\n\tv169 = v168 << 4;\n\tv170 = v51 + v169;\n\tthis = v170 + 0x130;\nL_004C:\n\t*([this @ X0 (UnityEngine.Purchasing.ProfileData)])(v192, util, *([this @ X0 (UnityEngine.Purchasing.ProfileData)+8]), 2, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis.<AppId>k__BackingField = v192;\n\tgoto L_0079;\n\tv251 = *([v193 @ X8_v7+B0]);\n\tv252 = 0;\n\tv253 = v251 + 8;\n\tv255 = *([v292 @ X11_v73-8]);\n\tv297 = v255 == v194;\n\tif (v297) goto L_0072;\n\tv275 = v291 + 1;\n\tv302 = v275 < v195;\n\tv273 = ~v302;\n\tv277 = v292 + 0x10;\n\tv257 = ~v273;\n\tif (v257) goto L_FFFFFFFF;\n\tv278 = v18;\n\tv279 = 0;\n\tv280 = 0x8909C4(v278, v194, v279, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0079;\nL_0072:\n\tv303 = *([v292 @ X11_v73]);\n\tv304 = v303 << 4;\n\tv305 = v193 + v304;\n\tv306 = v305 + 0x130;\nL_0079:\n\tv312 = Uniject.IUtil::get_platform(util);\n\t// 128 Box this @ X0 (UnityEngine.Purchasing.ProfileData), typeof(UnityEngine.RuntimePlatform), &v312 @ X0_v11 (UnityEngine.RuntimePlatform)\n\tv316 = *([this @ X0 (UnityEngine.Purchasing.ProfileData)]);\n\t*([v316 @ X8_v13+160])(v320, this, *([v316 @ X8_v13+168]), 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis = \"il2cpp_vm_object_unbox\"(this, *([v316 @ X8_v13+168]), 0, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis.<Platform>k__BackingField = v320;\n\tgoto L_00BA;\n\tv329 = *([v325 @ X8_v15+B0]);\n\tv330 = 0;\n\tv331 = v329 + 8;\n\tv333 = *([v370 @ X11_v68-8]);\n\tv375 = v333 == v326;\n\tif (v375) goto L_00B3;\n\tv353 = v369 + 1;\n\tv380 = v353 < v327;\n\tv351 = ~v380;\n\tv355 = v370 + 0x10;\n\tv335 = ~v351;\n\tif (v335) goto L_FFFFFFFF;\n\tv356 = v18;\n\tv357 = 0;\n\tv358 = 0x8909C4(v356, v326, v357, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00BA;\nL_00B3:\n\tv381 = *([v370 @ X11_v68]);\n\tv382 = v381 << 4;\n\tv383 = v325 + v382;\n\tv384 = v383 + 0x130;\nL_00BA:\n\tv405 = Uniject.IUtil::get_platform(util);\n\tthis.<PlatformId>k__BackingField = v405;\n\tv406 = util->klass;\n\tv409 = *([v406 @ X8_v18 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v409) goto L_00DE;\n\tv451 = *([v406 @ X8_v18 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_00C9:\n\tv456 = *([v451 @ X11_v63-8]) == Uniject.IUtil;\n\tif (v456) goto L_00E1;\n\tv450 = v450 + 1;\n\tv461 = v450 < *([v406 @ X8_v18 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv432 = ~v461;\n\tv451 = v451 + 0x10;\n\tv416 = ~v432;\n\tif (v416) goto L_00C9;\nL_00DE:\n\tthis = 0x8909C4(util, Uniject.IUtil, 4, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_00E8;\nL_00E1:\n\tv463 = *([v451 @ X11_v63]) + 4;\n\tv464 = v463 << 4;\n\tv465 = v406 + v464;\n\tthis = v465 + 0x130;\nL_00E8:\n\t*([this @ X0 (UnityEngine.Purchasing.ProfileData)])(v487, util, *([this @ X0 (UnityEngine.Purchasing.ProfileData)+8]), v715, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis.<SdkVer>k__BackingField = v487;\n\tv488 = util->klass;\n\tv491 = *([v488 @ X8_v21 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v491) goto L_010C;\n\tv533 = *([v488 @ X8_v21 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_00F7:\n\tv538 = *([v533 @ X11_v58-8]) == Uniject.IUtil;\n\tif (v538) goto L_010F;\n\tv532 = v532 + 1;\n\tv543 = v532 < *([v488 @ X8_v21 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv514 = ~v543;\n\tv533 = v533 + 0x10;\n\tv498 = ~v514;\n\tif (v498) goto L_00F7;\nL_010C:\n\tthis = 0x8909C4(util, Uniject.IUtil, 8, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0116;\nL_010F:\n\tv545 = *([v533 @ X11_v58]) + 8;\n\tv546 = v545 << 4;\n\tv547 = v488 + v546;\n\tthis = v547 + 0x130;\nL_0116:\n\t*([this @ X0 (UnityEngine.Purchasing.ProfileData)])(v569, util, *([this @ X0 (UnityEngine.Purchasing.ProfileData)+8]), v715, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis.<OsVer>k__BackingField = v569;\n\tv570 = util->klass;\n\tv573 = *([v570 @ X8_v24 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v573) goto L_013A;\n\tv615 = *([v570 @ X8_v24 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_0125:\n\tv620 = *([v615 @ X11_v53-8]) == Uniject.IUtil;\n\tif (v620) goto L_013D;\n\tv614 = v614 + 1;\n\tv625 = v614 < *([v570 @ X8_v24 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv596 = ~v625;\n\tv615 = v615 + 0x10;\n\tv580 = ~v596;\n\tif (v580) goto L_0125;\nL_013A:\n\tthis = 0x8909C4(util, Uniject.IUtil, 3, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0144;\nL_013D:\n\tv627 = *([v615 @ X11_v53]) + 3;\n\tv628 = v627 << 4;\n\tv629 = v570 + v628;\n\tthis = v629 + 0x130;\nL_0144:\n\t*([this @ X0 (UnityEngine.Purchasing.ProfileData)])(v651, util, *([this @ X0 (UnityEngine.Purchasing.ProfileData)+8]), v715, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis.<DeviceId>k__BackingField = v651;\n\tv652 = util->klass;\n\tv655 = *([v652 @ X8_v27 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v655) goto L_0168;\n\tv697 = *([v652 @ X8_v27 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_0153:\n\tv702 = *([v697 @ X11_v48-8]) == Uniject.IUtil;\n\tif (v702) goto L_016B;\n\tv696 = v696 + 1;\n\tv707 = v696 < *([v652 @ X8_v27 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv678 = ~v707;\n\tv697 = v697 + 0x10;\n\tv662 = ~v678;\n\tif (v662) goto L_0153;\nL_0168:\n\tthis = 0x8909C4(util, Uniject.IUtil, 6, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_0172;\nL_016B:\n\tv709 = *([v697 @ X11_v48]) + 6;\n\tv710 = v709 << 4;\n\tv711 = v652 + v710;\n\tthis = v711 + 0x130;\nL_0172:\n\t*([this @ X0 (UnityEngine.Purchasing.ProfileData)])(v733, util, *([this @ X0 (UnityEngine.Purchasing.ProfileData)+8]), v715, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tthis.<GameVersion>k__BackingField = v733;\n\tgoto L_0180;\n\tv740 = *([v736 @ X0_v33 (Il2CppClass<UnityEngine.Purchasing.Promo>)+E0]);\n\tv741 = v740 == 0;\n\tv742 = ~v741;\n\tgoto L_0180;\n\tv744 = \"il2cpp_codegen_runtime_class_init\"(v736, v731, v715, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0180:\n\tv747 = UnityEngine.Purchasing.Promo::Version();\n\tthis.<IapVer>k__BackingField = v747;\n\tgoto L_01AE;\n\tv752 = *([v748 @ X8_v34+B0]);\n\tv753 = 0;\n\tv754 = v752 + 8;\n\tv756 = *([v793 @ X11_v43-8]);\n\tv798 = v756 == v749;\n\tif (v798) goto L_01A6;\n\tv776 = v792 + 1;\n\tv803 = v776 < v750;\n\tv774 = ~v803;\n\tv778 = v793 + 0x10;\n\tv758 = ~v774;\n\tif (v758) goto L_FFFFFFFF;\n\tv779 = 5;\n\tv780 = v18;\n\tv781 = 0x8909C4(v780, v749, v779, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_01AE;\nL_01A6:\n\tv804 = *([v793 @ X11_v43]);\n\tv805 = v804 + 5;\n\tv806 = v805 << 4;\n\tv807 = v748 + v806;\n\tv808 = v807 + 0x130;\nL_01AE:\n\tv829 = Uniject.IUtil::get_userId(util);\n\tthis.<UserId>k__BackingField = v829;\n\tv830 = util->klass;\n\tv833 = *([v830 @ X8_v37 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v833) goto L_01D2;\n\tv875 = *([v830 @ X8_v37 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_01BD:\n\tv880 = *([v875 @ X11_v38-8]) == Uniject.IUtil;\n\tif (v880) goto L_01D5;\n\tv874 = v874 + 1;\n\tv885 = v874 < *([v830 @ X8_v37 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv856 = ~v885;\n\tv875 = v875 + 0x10;\n\tv840 = ~v856;\n\tif (v840) goto L_01BD;\nL_01D2:\n\tthis = 0x8909C4(util, Uniject.IUtil, 7, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_01DC;\nL_01D5:\n\tv887 = *([v875 @ X11_v38]) + 7;\n\tv888 = v887 << 4;\n\tv889 = v830 + v888;\n\tthis = v889 + 0x130;\nL_01DC:\n\t*([this @ X0 (UnityEngine.Purchasing.ProfileData)])(v911, util, *([this @ X0 (UnityEngine.Purchasing.ProfileData)+8]), v\n// ... truncated")]
		private ProfileData(IUtil util)
		{
			//IL_000d: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_06d8: Expected I, but got O
			//IL_0094: Expected O, but got I
			//IL_0743: Expected I, but got O
			//IL_0139: Expected O, but got I
			//IL_07ae: Expected I, but got O
			//IL_0214: Expected O, but got I
			//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Expected O, but got Unknown
			//IL_01e1: Expected O, but got I
			//IL_01f0: Expected O, but got I
			//IL_0185: Expected O, but got I
			//IL_0819: Expected I, but got O
			//IL_02e6: Expected O, but got I
			//IL_029a: Unknown result type (might be due to invalid IL or missing references)
			//IL_029f: Expected O, but got Unknown
			//IL_02bc: Expected O, but got I
			//IL_02cb: Expected O, but got I
			//IL_0260: Expected O, but got I
			//IL_03b8: Expected O, but got I
			//IL_036c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0371: Expected O, but got Unknown
			//IL_038e: Expected O, but got I
			//IL_039d: Expected O, but got I
			//IL_0332: Expected O, but got I
			//IL_08a0: Expected I, but got O
			//IL_043e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0443: Expected O, but got Unknown
			//IL_0460: Expected O, but got I
			//IL_046f: Expected O, but got I
			//IL_0404: Expected O, but got I
			//IL_04a2: Expected O, but got I
			//IL_0528: Unknown result type (might be due to invalid IL or missing references)
			//IL_052d: Expected O, but got Unknown
			//IL_054a: Expected O, but got I
			//IL_0559: Expected O, but got I
			//IL_095f: Expected I, but got O
			//IL_04ee: Expected O, but got I
			//IL_057d: Expected O, but got I
			//IL_0603: Unknown result type (might be due to invalid IL or missing references)
			//IL_0608: Expected O, but got Unknown
			//IL_0625: Expected O, but got I
			//IL_0634: Expected O, but got I
			//IL_05c9: Expected O, but got I
			base._002Ector();
			m_Util = util;
			IntPtr intPtr = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v4 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v4 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X11_v78-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v4 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			ProfileData profileData = (ProfileData)((long)(IntPtr)(object)((long)intPtr + (long)(int)((long)(IntPtr)(object)(obj + 2) << 4)) + 304L);
			goto IL_0681;
			IL_034b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			int num3 = 3;
			goto IL_07fd;
			IL_05e2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			int num4 = 12;
			goto IL_09ae;
			IL_0279:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num3 = 8;
			goto IL_0792;
			IL_08ef:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (UnityEngine.Purchasing.ProfileData)] (should have been resolved before IL gen)");
			ulong num5 = default(ulong);
			SessionId = num5;
			int screenWidth = util.screenWidth;
			ScreenWidth = screenWidth;
			int screenHeight = util.screenHeight;
			ScreenHeight = screenHeight;
			float screenDpi = util.screenDpi;
			float num6 = default(float);
			ScreenDpi = num6;
			IntPtr intPtr2 = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v49 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_05e2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v49 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj2 = 0L + 8L;
			int num7 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1202 @ X11_v18-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num7++;
				int num8 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1158 @ X8_v49 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag3 = (long)num8 < 0L;
				bool flag4 = !flag3;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_05e2;
			}
			profileData = (ProfileData)((long)(IntPtr)(object)((long)intPtr2 + (long)(int)((long)(IntPtr)(object)(obj2 + 12) << 4)) + 304L);
			num4 = 0;
			goto IL_09ae;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0681;
			IL_0681:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (UnityEngine.Purchasing.ProfileData)] (should have been resolved before IL gen)");
			string text = default(string);
			AppId = text;
			RuntimePlatform platform = util.platform;
			profileData = (ProfileData)(object)platform;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v316 @ X8_v13+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string text2 = default(string);
			Platform = text2;
			RuntimePlatform platform2 = util.platform;
			PlatformId = (int)platform2;
			IntPtr intPtr3 = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X8_v18 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_019e;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X8_v18 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj3 = 0L + 8L;
			int num9 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ X11_v63-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num9++;
				int num10 = num9;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X8_v18 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag5 = (long)num10 < 0L;
				bool flag6 = !flag5;
				obj3 = (long)(IntPtr)obj3 + 16L;
				if (!flag6)
				{
					continue;
				}
				goto IL_019e;
			}
			profileData = (ProfileData)((long)(IntPtr)(object)((long)intPtr3 + (long)(int)((long)(IntPtr)(object)(obj3 + 4) << 4)) + 304L);
			num3 = 0;
			goto IL_0727;
			IL_0792:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (UnityEngine.Purchasing.ProfileData)] (should have been resolved before IL gen)");
			string text3 = default(string);
			OsVer = text3;
			IntPtr intPtr4 = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X8_v24 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_034b;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X8_v24 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj4 = 0L + 8L;
			int num11 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v615 @ X11_v53-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num11++;
				int num12 = num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v570 @ X8_v24 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag7 = (long)num12 < 0L;
				bool flag8 = !flag7;
				obj4 = (long)(IntPtr)obj4 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_034b;
			}
			profileData = (ProfileData)((long)(IntPtr)(object)((long)intPtr4 + (long)(int)((long)(IntPtr)(object)(obj4 + 3) << 4)) + 304L);
			goto IL_07fd;
			IL_07fd:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (UnityEngine.Purchasing.ProfileData)] (should have been resolved before IL gen)");
			string text4 = default(string);
			DeviceId = text4;
			IntPtr intPtr5 = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ X8_v27 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_041d;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ X8_v27 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj5 = 0L + 8L;
			int num13 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ X11_v48-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num13++;
				int num14 = num13;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v652 @ X8_v27 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag9 = (long)num14 < 0L;
				bool flag10 = !flag9;
				obj5 = (long)(IntPtr)obj5 + 16L;
				if (!flag10)
				{
					continue;
				}
				goto IL_041d;
			}
			profileData = (ProfileData)((long)(IntPtr)(object)((long)intPtr5 + (long)(int)((long)(IntPtr)(object)(obj5 + 6) << 4)) + 304L);
			goto IL_0868;
			IL_041d:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num3 = 6;
			goto IL_0868;
			IL_0868:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (UnityEngine.Purchasing.ProfileData)] (should have been resolved before IL gen)");
			string text5 = default(string);
			GameVersion = text5;
			IapVer = Promo.Version();
			string userId = util.userId;
			UserId = userId;
			IntPtr intPtr6 = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ X8_v37 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0507;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ X8_v37 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj6 = 0L + 8L;
			int num15 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v875 @ X11_v38-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num15++;
				int num16 = num15;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v830 @ X8_v37 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag11 = (long)num16 < 0L;
				bool flag12 = !flag11;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag12)
				{
					continue;
				}
				goto IL_0507;
			}
			profileData = (ProfileData)((long)(IntPtr)(object)((long)intPtr6 + (long)(int)((long)(IntPtr)(object)(obj6 + 7) << 4)) + 304L);
			int num17 = 0;
			goto IL_08ef;
			IL_019e:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num3 = 4;
			goto IL_0727;
			IL_0727:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (UnityEngine.Purchasing.ProfileData)] (should have been resolved before IL gen)");
			string text6 = default(string);
			SdkVer = text6;
			IntPtr intPtr7 = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v21 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0279;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v21 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj7 = 0L + 8L;
			int num18 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v533 @ X11_v58-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num18++;
				int num19 = num18;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v488 @ X8_v21 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag13 = (long)num19 < 0L;
				bool flag14 = !flag13;
				obj7 = (long)(IntPtr)obj7 + 16L;
				if (!flag14)
				{
					continue;
				}
				goto IL_0279;
			}
			profileData = (ProfileData)((long)(IntPtr)(object)((long)intPtr7 + (long)(int)((long)(IntPtr)(object)(obj7 + 8) << 4)) + 304L);
			goto IL_0792;
			IL_09ae:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [this @ X0 (UnityEngine.Purchasing.ProfileData)] (should have been resolved before IL gen)");
			string text7 = default(string);
			ScreenOrientation = text7;
			return;
			IL_0507:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			num17 = 7;
			goto IL_08ef;
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0xC5CE3C", Offset = "0xC5CE3C", Length = "0x550")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EFF908]);\n\tv23 = *([v22 @ X8_v87]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202339A]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v46);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"appid\", this.<AppId>k__BackingField);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"platform\", this.<Platform>k__BackingField);\n\tv123 = this.<PlatformId>k__BackingField;\n\t// 54 Box v128 @ X0_v10 (System.Object), typeof(System.Int32), &v123 @ X8_v12 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"platformid\", v128);\n\tv196 = System.String::IsNullOrEmpty(this.<AdsGameId>k__BackingField);\n\tv198 = v196 == 0;\n\tv199 = ~v198;\n\tif (v199) goto L_0052;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"gameId\", this.<AdsGameId>k__BackingField);\nL_0052:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"sdk_ver\", this.<SdkVer>k__BackingField);\n\tv222 = System.String::op_Inequality(this.<DeviceId>k__BackingField, \"n/a\");\n\tv224 = v222 == 0;\n\tif (v224) goto L_0065;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"deviceid\", this.<DeviceId>k__BackingField);\nL_0065:\n\tv238 = System.String::IsNullOrEmpty(this.<UserId>k__BackingField);\n\tv240 = v238 == 0;\n\tv241 = ~v240;\n\tif (v241) goto L_0071;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"userid\", this.<UserId>k__BackingField);\nL_0071:\n\tv253 = this.<SessionId>k__BackingField;\n\tv254 = this.<SessionId>k__BackingField == 0;\n\tif (v254) goto L_0083;\n\t// 121 Box v260 @ X0_v87 (System.Object), typeof(System.UInt64), &v253 @ X8_v22 (System.UInt64)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"sessionid\", v260);\nL_0083:\n\tv275 = System.String::IsNullOrEmpty(this.<BuildGUID>k__BackingField);\n\tv278 = v275 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_0091;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"build_guid\", this.<BuildGUID>k__BackingField);\nL_0091:\n\tv293 = System.String::IsNullOrEmpty(this.<IapVer>k__BackingField);\n\tv295 = v293 == 0;\n\tv296 = ~v295;\n\tif (v296) goto L_009F;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"iap_ver\", this.<IapVer>k__BackingField);\nL_009F:\n\tv310 = System.String::IsNullOrEmpty(this.<AdsGamerToken>k__BackingField);\n\tv312 = v310 == 0;\n\tv313 = ~v312;\n\tif (v313) goto L_00AB;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"gamerToken\", this.<AdsGamerToken>k__BackingField);\nL_00AB:\n\tv325 = this.<TrackingOptOut>k__BackingField;\n\tv326 = this.<TrackingOptOut>k__BackingField < 0x100;\n\tv327 = ~v326;\n\tv335 = ~v327;\n\tif (v335) goto L_00C4;\n\t// 188 Box v341 @ X0_v81 (System.Object), typeof(System.Nullable`1<System.Boolean>), &v325 @ X8_v27 (System.Nullable`1<System.Boolean>)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"trackingOptOut\", v341);\nL_00C4:\n\tv354 = this.<AdsABGroup>k__BackingField;\n\tv355 = this.<AdsABGroup>k__BackingField & 0xFF00000000;\n\tv356 = v355 == 0;\n\tif (v356) goto L_00D5;\n\t// 205 Box v363 @ X0_v78 (System.Object), typeof(System.Nullable`1<System.Int32>), &v354 @ X8_v29 (System.Nullable`1<System.Int32>)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"abGroup\", v363);\nL_00D5:\n\tv376 = this.<StoreABGroup>k__BackingField;\n\tv377 = this.<StoreABGroup>k__BackingField & 0xFF00000000;\n\tv378 = v377 == 0;\n\tif (v378) goto L_00E8;\n\t// 222 Box v385 @ X0_v75 (System.Object), typeof(System.Nullable`1<System.Int32>), &v376 @ X8_v31 (System.Nullable`1<System.Int32>)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"store_abgroup\", v385);\nL_00E8:\n\tv400 = System.String::IsNullOrEmpty(this.<CatalogId>k__BackingField);\n\tv403 = v400 == 0;\n\tv404 = ~v403;\n\tif (v404) goto L_00F4;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"catalogid\", this.<CatalogId>k__BackingField);\nL_00F4:\n\tv416 = this.<StoreTestEnabled>k__BackingField;\n\tv417 = this.<StoreTestEnabled>k__BackingField < 0x100;\n\tv92 = ~v417;\n\tv68 = ~v92;\n\tif (v68) goto L_010F;\n\t// 261 Box v423 @ X0_v71 (System.Object), typeof(System.Nullable`1<System.Boolean>), &v416 @ X8_v34 (System.Nullable`1<System.Boolean>)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"iap_test\", v423);\nL_010F:\n\tv438 = System.String::IsNullOrEmpty(this.<StoreName>k__BackingField);\n\tv441 = v438 == 0;\n\tv442 = ~v441;\n\tif (v442) goto L_011D;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"store\", this.<StoreName>k__BackingField);\nL_011D:\n\tv456 = System.String::IsNullOrEmpty(this.<GameVersion>k__BackingField);\n\tv458 = v456 == 0;\n\tv459 = ~v458;\n\tif (v459) goto L_012B;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"game_ver\", this.<GameVersion>k__BackingField);\nL_012B:\n\tv473 = System.String::IsNullOrEmpty(this.<OsVer>k__BackingField);\n\tv475 = v473 == 0;\n\tv476 = ~v475;\n\tif (v476) goto L_0137;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"osv\", this.<OsVer>k__BackingField);\nL_0137:\n\tv123 = this.<ScreenWidth>k__BackingField;\n\t// 315 Box v491 @ X0_v49 (System.Object), typeof(System.Int32), &v123 @ X8_v12 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"w\", v491);\n\tv123 = this.<ScreenHeight>k__BackingField;\n\t// 327 Box v501 @ X0_v52 (System.Object), typeof(System.Int32), &v123 @ X8_v12 (System.Int32)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"h\", v501);\n\tv509 = this.<ScreenDpi>k__BackingField;\n\t// 341 Box v512 @ X0_v55 (System.Object), typeof(System.Single), &v509 @ X8_v45 (System.Single)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"ppi\", v512);\n\tv100 = this.m_Util;\n\tv515 = *([v100 @ X21_v4 (Uniject.IUtil)]);\n\tv519 = *([v515 @ X8_v48 (Il2CppClass<Uniject.IUtil>)+126]) == 0;\n\tif (v519) goto L_0184;\n\tv551 = *([v515 @ X8_v48 (Il2CppClass<Uniject.IUtil>)+B0]) + 8;\nL_016F:\n\tv566 = *([v551 @ X11_v5-8]) == Uniject.IUtil;\n\tif (v566) goto L_0187;\n\tv552 = v552 + 1;\n\tv571 = v552 < *([v515 @ X8_v48 (Il2CppClass<Uniject.IUtil>)+126]);\n\tv546 = ~v571;\n\tv551 = v551 + 0x10;\n\tv530 = ~v546;\n\tif (v530) goto L_016F;\nL_0184:\n\tv578 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v100, Uniject.IUtil, 0xC);\n\tgoto L_018E;\nL_0187:\n\tv573 = *([v551 @ X11_v5]) + 0xC;\n\tv574 = v573 << 4;\n\tv123 = v515 + v574;\n\tv578 = v123 + 0x130;\nL_018E:\n\t*([v578 @ X0_v57])(v583, v100, *([v578 @ X0_v57+8]), v577, Il2CppMethodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tthis.<ScreenOrientation>k__BackingField = v583;\n\tv585 = System.String::IsNullOrEmpty(v583);\n\tv587 = v585 == 0;\n\tv179 = ~v587;\n\tif (v179) goto L_01A5;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v46, \"orient\", this.<ScreenOrientation>k__BackingField);\nL_01A5:\n\treturn v46;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 293 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe Dictionary<string, object> GetProfileDict()
		{
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Expected I4, but got Unknown
			//IL_038a: Unknown result type (might be due to invalid IL or missing references)
			//IL_038f: Expected I4, but got Unknown
			//IL_061d: Expected I, but got O
			//IL_06d5: Expected O, but got I4
			//IL_0658: Expected O, but got I
			//IL_06ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_06f1: Expected O, but got Unknown
			//IL_071c: Expected O, but got I4
			//IL_0724: Expected I4, but got O
			//IL_06a4: Expected O, but got I
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("appid", AppId);
			dictionary.Add("platform", Platform);
			int platformId = PlatformId;
			object value = platformId;
			dictionary.Add("platformid", value);
			if (!string.IsNullOrEmpty(AdsGameId))
			{
				dictionary.Add("gameId", AdsGameId);
			}
			dictionary.Add("sdk_ver", SdkVer);
			if (DeviceId != "n/a")
			{
				dictionary.Add("deviceid", DeviceId);
			}
			if (!string.IsNullOrEmpty(UserId))
			{
				dictionary.Add("userid", UserId);
			}
			ulong sessionId = SessionId;
			if (SessionId != 0)
			{
				object value2 = sessionId;
				dictionary.Add("sessionid", value2);
			}
			if (!string.IsNullOrEmpty(BuildGUID))
			{
				dictionary.Add("build_guid", BuildGUID);
			}
			if (!string.IsNullOrEmpty(IapVer))
			{
				dictionary.Add("iap_ver", IapVer);
			}
			if (!string.IsNullOrEmpty(AdsGamerToken))
			{
				dictionary.Add("gamerToken", AdsGamerToken);
			}
			bool? trackingOptOut = TrackingOptOut;
			if ((long)(IntPtr)(void*)TrackingOptOut >= 256L)
			{
				object value3 = trackingOptOut;
				dictionary.Add("trackingOptOut", value3);
			}
			int? adsABGroup = AdsABGroup;
			if ((int)((_003F?)AdsABGroup & 0xFF00000000L) != 0)
			{
				object value4 = adsABGroup;
				dictionary.Add("abGroup", value4);
			}
			int? storeABGroup = StoreABGroup;
			if ((int)((_003F?)StoreABGroup & 0xFF00000000L) != 0)
			{
				object value5 = storeABGroup;
				dictionary.Add("store_abgroup", value5);
			}
			if (!string.IsNullOrEmpty(CatalogId))
			{
				dictionary.Add("catalogid", CatalogId);
			}
			bool? storeTestEnabled = StoreTestEnabled;
			if ((long)(IntPtr)(void*)StoreTestEnabled >= 256L)
			{
				object value6 = storeTestEnabled;
				dictionary.Add("iap_test", value6);
			}
			if (!string.IsNullOrEmpty(StoreName))
			{
				dictionary.Add("store", StoreName);
			}
			if (!string.IsNullOrEmpty(GameVersion))
			{
				dictionary.Add("game_ver", GameVersion);
			}
			if (!string.IsNullOrEmpty(OsVer))
			{
				dictionary.Add("osv", OsVer);
			}
			platformId = ScreenWidth;
			object value7 = platformId;
			dictionary.Add("w", value7);
			platformId = ScreenHeight;
			object value8 = platformId;
			dictionary.Add("h", value8);
			float screenDpi = ScreenDpi;
			object obj = screenDpi;
			dictionary.Add("ppi", obj);
			IUtil util = m_Util;
			IntPtr intPtr = (IntPtr)util;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ X8_v48 (Il2CppClass<Uniject.IUtil>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_06bd;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ X8_v48 (Il2CppClass<Uniject.IUtil>)+B0]");
			object obj2 = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v551 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IUtil))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ X8_v48 (Il2CppClass<Uniject.IUtil>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj2 = (long)(IntPtr)obj2 + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_06bd;
			}
			object obj3 = obj2 + 12;
			int num3 = (int)((long)(IntPtr)obj3 << 4);
			platformId = (int)((long)intPtr + (long)num3);
			object obj4 = platformId + 304;
			int num4 = (int)obj;
			goto IL_0780;
			IL_0780:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v578 @ X0_v57] (should have been resolved before IL gen)");
			string value9 = default(string);
			ScreenOrientation = value9;
			if (!string.IsNullOrEmpty(value9))
			{
				dictionary.Add("orient", ScreenOrientation);
			}
			return dictionary;
			IL_06bd:
			((Dictionary<string, object>)util).Add((string)(object)typeof(IUtil), (object)12);
			num4 = 12;
			goto IL_0780;
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0xC6C1AC", Offset = "0xC6C1AC", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EF1DC0]);\n\tv21 = *([v20 @ X8_v37]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202339B]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v44);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"appid\", this.<AppId>k__BackingField);\n\tv65 = System.String::op_Inequality(this.<DeviceId>k__BackingField, \"n/a\");\n\tv67 = v65 == 0;\n\tif (v67) goto L_003A;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"deviceid\", this.<DeviceId>k__BackingField);\nL_003A:\n\tv136 = System.String::IsNullOrEmpty(this.<UserId>k__BackingField);\n\tv138 = v136 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0048;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"userid\", this.<UserId>k__BackingField);\nL_0048:\n\tv153 = System.String::IsNullOrEmpty(this.<AdsGamerToken>k__BackingField);\n\tv155 = v153 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0054;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"gamerToken\", this.<AdsGamerToken>k__BackingField);\nL_0054:\n\tv168 = this.<TrackingOptOut>k__BackingField;\n\tv169 = this.<TrackingOptOut>k__BackingField < 0x100;\n\tv101 = ~v169;\n\tv77 = ~v101;\n\tif (v77) goto L_006F;\n\t// 101 Box v175 @ X0_v31 (System.Object), typeof(System.Nullable`1<System.Boolean>), &v168 @ X8_v14 (System.Nullable`1<System.Boolean>)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"trackingOptOut\", v175);\nL_006F:\n\tv188 = System.String::IsNullOrEmpty(this.<MonetizationId>k__BackingField);\n\tv191 = v188 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_007C;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"umpid\", this.<MonetizationId>k__BackingField);\nL_007C:\n\tv205 = this.<SessionId>k__BackingField == 0;\n\tif (v205) goto L_00A2;\n\tgoto L_008C;\n\tv224 = *([v208 @ X0_v22+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\tif (v226) goto L_008C;\n\tv228 = \"il2cpp_codegen_runtime_class_init\"(v208, v201, v200, v199, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_008C:\n\tv232 = System.Convert::ToString(this.<SessionId>k__BackingField);\n\tv218 = System.String::IsNullOrEmpty(v232);\n\tv234 = v218 == 0;\n\tv219 = ~v234;\n\tif (v219) goto L_00A2;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"sessionid\", v232);\nL_00A2:\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe Dictionary<string, object> GetProfileIds()
		{
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("appid", AppId);
			if (DeviceId != "n/a")
			{
				dictionary.Add("deviceid", DeviceId);
			}
			if (!string.IsNullOrEmpty(UserId))
			{
				dictionary.Add("userid", UserId);
			}
			if (!string.IsNullOrEmpty(AdsGamerToken))
			{
				dictionary.Add("gamerToken", AdsGamerToken);
			}
			bool? trackingOptOut = TrackingOptOut;
			if ((long)(IntPtr)(void*)TrackingOptOut >= 256L)
			{
				object value = trackingOptOut;
				dictionary.Add("trackingOptOut", value);
			}
			if (!string.IsNullOrEmpty(MonetizationId))
			{
				dictionary.Add("umpid", MonetizationId);
			}
			if (SessionId != 0)
			{
				string value2 = Convert.ToString(SessionId);
				if (!string.IsNullOrEmpty(value2))
				{
					dictionary.Add("sessionid", value2);
				}
			}
			return dictionary;
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0xC5CDB0", Offset = "0xC5CDB0", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ED4E38]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202339C]) = v40;\nL_0018:\n\tv52 = v44.ProfileInstance;\n\tv46 = v44.ProfileInstance == 0;\n\tv47 = ~v46;\n\tif (v47) goto L_002D;\n\tv48 = new UnityEngine.Purchasing.ProfileData();\n\tUnityEngine.Purchasing.ProfileData::.ctor(v48, util);\n\tv63.ProfileInstance = v48;\n\tv52 = v65.ProfileInstance;\nL_002D:\n\treturn v52;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static ProfileData Instance(IUtil util)
		{
			ProfileData profileInstance = ProfileInstance;
			if (ProfileInstance == null)
			{
				ProfileData profileInstance2 = new ProfileData(util);
				ProfileInstance = profileInstance2;
				profileInstance = ProfileInstance;
			}
			return profileInstance;
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0xC6C3A8", Offset = "0xC6C3A8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(gamerToken);\n\tv18 = v16 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0015;\n\tthis.<AdsGamerToken>k__BackingField = gamerToken;\nL_0015:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetGamerToken(string gamerToken)
		{
			if (!string.IsNullOrEmpty(gamerToken))
			{
				AdsGamerToken = gamerToken;
			}
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0xC6C3DC", Offset = "0xC6C3DC", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EF93B0]);\n\tv23 = *([v22 @ X8_v5]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, trackingOptOut, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202339D]) = v41;\nL_0015:\n\tv42 = trackingOptOut & 0xFFFF;\n\tv43 = v42 < 0x100;\n\tv44 = ~v43;\n\tv52 = ~v44;\n\tif (v52) goto L_0028;\n\tthis.<TrackingOptOut>k__BackingField = trackingOptOut;\nL_0028:\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetTrackingOptOut(bool? trackingOptOut)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected I4, but got Unknown
			int num = (_003F?)trackingOptOut & 0xFFFF;
			if (num >= 256)
			{
				TrackingOptOut = trackingOptOut;
			}
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0xC6C438", Offset = "0xC6C438", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(gameid);\n\tv18 = v16 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0015;\n\tthis.<AdsGameId>k__BackingField = gameid;\nL_0015:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetGameId(string gameid)
		{
			if (!string.IsNullOrEmpty(gameid))
			{
				AdsGameId = gameid;
			}
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0xC6C46C", Offset = "0xC6C46C", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EBF6E0]);\n\tv23 = *([v22 @ X8_v5]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, abgroup, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202339E]) = v41;\nL_0015:\n\tv42 = abgroup & 0xFF00000000;\n\tv43 = v42 == 0;\n\tif (v43) goto L_002B;\n\tv54 = abgroup < 1;\n\tif (v54) goto L_002B;\n\tthis.<AdsABGroup>k__BackingField = abgroup;\nL_002B:\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal unsafe void SetABGroup(int? abgroup)
		{
			//IL_003e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected I4, but got Unknown
			if ((int)((_003F?)abgroup & 0xFF00000000L) != 0 && (long)(IntPtr)(void*)abgroup >= 1L)
			{
				AdsABGroup = abgroup;
			}
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0xC6C4CC", Offset = "0xC6C4CC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE0ED8]);\n\tv23 = *([v22 @ X8_v5]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, abgroup, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202339F]) = v41;\nL_0015:\n\tv42 = abgroup & 0xFF00000000;\n\tv43 = v42 == 0;\n\tif (v43) goto L_001F;\n\tthis.<StoreABGroup>k__BackingField = abgroup;\nL_001F:\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetStoreABGroup(int? abgroup)
		{
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected I4, but got Unknown
			if ((int)((_003F?)abgroup & 0xFF00000000L) != 0)
			{
				StoreABGroup = abgroup;
			}
		}

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0xC6C524", Offset = "0xC6C524", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = storeid == 0;\n\tif (v0) goto L_0003;\n\tthis.<CatalogId>k__BackingField = storeid;\nL_0003:\n\treturn;\n")]
		internal void SetCatalogId(string storeid)
		{
			if (storeid != null)
			{
				CatalogId = storeid;
			}
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0xC63710", Offset = "0xC63710", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = System.String::IsNullOrEmpty(storename);\n\tv18 = v16 == 0;\n\tv19 = ~v18;\n\tif (v19) goto L_0015;\n\tthis.<StoreName>k__BackingField = storename;\nL_0015:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void SetStoreName(string storename)
		{
			if (!string.IsNullOrEmpty(storename))
			{
				StoreName = storename;
			}
		}
	}
}
