using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile
{
	[Serializable]
	[Token(Token = "0x2000040")]
	public class GameServicesSettings
	{
		[Token(Token = "0x200011F")]
		public enum GpgsGravity
		{
			[Token(Token = "0x40004CC")]
			Top = 0,
			[Token(Token = "0x40004CD")]
			Bottom = 1,
			[Token(Token = "0x40004CE")]
			Left = 2,
			[Token(Token = "0x40004CF")]
			Right = 3,
			[Token(Token = "0x40004D0")]
			CenterHorizontal = 4
		}

		[SerializeField]
		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x10")]
		private bool mAutoInit;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7327D8", Offset = "0x7327D8")]
		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x14")]
		private float mAutoInitDelay;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x73281C", Offset = "0x73281C")]
		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x18")]
		private int mAndroidMaxLoginRequests;

		[SerializeField]
		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x1C")]
		private bool mGpgsDebugLogEnabled;

		[SerializeField]
		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x20")]
		private GpgsGravity mGpgsPopupGravity;

		[SerializeField]
		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x24")]
		private bool mGpgsShouldRequestServerAuthCode;

		[SerializeField]
		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x25")]
		private bool mGpgsForceRefreshServerAuthCode;

		[SerializeField]
		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x28")]
		private string[] mGpgsOauthScopes;

		[SerializeField]
		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0x30")]
		private Leaderboard[] mLeaderboards;

		[SerializeField]
		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0x38")]
		private Achievement[] mAchievements;

		[SerializeField]
		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x40")]
		private string mAndroidXmlResources;

		[SerializeField]
		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x48")]
		private bool mEnableMultiplayer;

		[SerializeField]
		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x49")]
		private bool mEnableSavedGames;

		[SerializeField]
		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x4C")]
		private SavedGameConflictResolutionStrategy mAutoConflictResolutionStrategy;

		[SerializeField]
		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x50")]
		private GPGSSavedGameDataSource mGpgsDataSource;

		[Token(Token = "0x17000109")]
		public bool IsAutoInit
		{
			[Token(Token = "0x6000390")]
			[Address(RVA = "0xBF1A24", Offset = "0xBF1A24", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoInit;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsAutoInit;
			}
			[Token(Token = "0x6000391")]
			[Address(RVA = "0xBF1A2C", Offset = "0xBF1A2C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoInit = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mAutoInit = value;
			}
		}

		[Token(Token = "0x1700010A")]
		public float AutoInitDelay
		{
			[Token(Token = "0x6000392")]
			[Address(RVA = "0xBF1A38", Offset = "0xBF1A38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoInitDelay;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AutoInitDelay;
			}
			[Token(Token = "0x6000393")]
			[Address(RVA = "0xBF1A40", Offset = "0xBF1A40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoInitDelay = value;\n\treturn;\n")]
			set
			{
				AutoInitDelay = value;
			}
		}

		[Token(Token = "0x1700010B")]
		public int AndroidMaxLoginRequests
		{
			[Token(Token = "0x6000394")]
			[Address(RVA = "0xBF1A48", Offset = "0xBF1A48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAndroidMaxLoginRequests;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AndroidMaxLoginRequests;
			}
		}

		[Token(Token = "0x1700010C")]
		public bool GgpsDebugLogEnabled
		{
			[Token(Token = "0x6000395")]
			[Address(RVA = "0xBF1A50", Offset = "0xBF1A50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mGpgsDebugLogEnabled;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GgpsDebugLogEnabled;
			}
			[Token(Token = "0x6000396")]
			[Address(RVA = "0xBF1A58", Offset = "0xBF1A58", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mGpgsDebugLogEnabled = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mGpgsDebugLogEnabled = value;
			}
		}

		[Token(Token = "0x1700010D")]
		public GpgsGravity GpgsPopupGravity
		{
			[Token(Token = "0x6000397")]
			[Address(RVA = "0xBF1A64", Offset = "0xBF1A64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mGpgsPopupGravity;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GpgsPopupGravity;
			}
			[Token(Token = "0x6000398")]
			[Address(RVA = "0xBF1A6C", Offset = "0xBF1A6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mGpgsPopupGravity = value;\n\treturn;\n")]
			set
			{
				GpgsPopupGravity = value;
			}
		}

		[Token(Token = "0x1700010E")]
		public bool GpgsShouldRequestServerAuthCode
		{
			[Token(Token = "0x6000399")]
			[Address(RVA = "0xBF1A74", Offset = "0xBF1A74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mGpgsShouldRequestServerAuthCode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GpgsShouldRequestServerAuthCode;
			}
			[Token(Token = "0x600039A")]
			[Address(RVA = "0xBF1A7C", Offset = "0xBF1A7C", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mGpgsShouldRequestServerAuthCode = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mGpgsShouldRequestServerAuthCode = value;
			}
		}

		[Token(Token = "0x1700010F")]
		public bool GpgsForceRefreshServerAuthCode
		{
			[Token(Token = "0x600039B")]
			[Address(RVA = "0xBF1A88", Offset = "0xBF1A88", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mGpgsForceRefreshServerAuthCode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GpgsForceRefreshServerAuthCode;
			}
			[Token(Token = "0x600039C")]
			[Address(RVA = "0xBF1A90", Offset = "0xBF1A90", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mGpgsForceRefreshServerAuthCode = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				mGpgsForceRefreshServerAuthCode = value;
			}
		}

		[Token(Token = "0x17000110")]
		public string[] GpgsOauthScopes
		{
			[Token(Token = "0x600039D")]
			[Address(RVA = "0xBF1A9C", Offset = "0xBF1A9C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mGpgsOauthScopes;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GpgsOauthScopes;
			}
			[Token(Token = "0x600039E")]
			[Address(RVA = "0xBF1AA4", Offset = "0xBF1AA4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mGpgsOauthScopes = value;\n\treturn;\n")]
			set
			{
				GpgsOauthScopes = value;
			}
		}

		[Token(Token = "0x17000111")]
		public Leaderboard[] Leaderboards
		{
			[Token(Token = "0x600039F")]
			[Address(RVA = "0xBF1AAC", Offset = "0xBF1AAC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mLeaderboards;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Leaderboards;
			}
			[Token(Token = "0x60003A0")]
			[Address(RVA = "0xBF1AB4", Offset = "0xBF1AB4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mLeaderboards = value;\n\treturn;\n")]
			set
			{
				Leaderboards = value;
			}
		}

		[Token(Token = "0x17000112")]
		public Achievement[] Achievements
		{
			[Token(Token = "0x60003A1")]
			[Address(RVA = "0xBF1ABC", Offset = "0xBF1ABC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAchievements;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Achievements;
			}
			[Token(Token = "0x60003A2")]
			[Address(RVA = "0xBF1AC4", Offset = "0xBF1AC4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAchievements = value;\n\treturn;\n")]
			set
			{
				Achievements = value;
			}
		}

		[Token(Token = "0x17000113")]
		public bool IsMultiplayerEnabled
		{
			[Token(Token = "0x60003A3")]
			[Address(RVA = "0xBF1ACC", Offset = "0xBF1ACC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableMultiplayer;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsMultiplayerEnabled;
			}
		}

		[Token(Token = "0x17000114")]
		public bool IsSavedGamesEnabled
		{
			[Token(Token = "0x60003A4")]
			[Address(RVA = "0xBF1AD4", Offset = "0xBF1AD4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mEnableSavedGames;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return IsSavedGamesEnabled;
			}
		}

		[Token(Token = "0x17000115")]
		public SavedGameConflictResolutionStrategy AutoConflictResolutionStrategy
		{
			[Token(Token = "0x60003A5")]
			[Address(RVA = "0xBF1ADC", Offset = "0xBF1ADC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mAutoConflictResolutionStrategy;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AutoConflictResolutionStrategy;
			}
			[Token(Token = "0x60003A6")]
			[Address(RVA = "0xBF1AE4", Offset = "0xBF1AE4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mAutoConflictResolutionStrategy = value;\n\treturn;\n")]
			set
			{
				AutoConflictResolutionStrategy = value;
			}
		}

		[Token(Token = "0x17000116")]
		public GPGSSavedGameDataSource GPGSDataSource
		{
			[Token(Token = "0x60003A7")]
			[Address(RVA = "0xBF1AEC", Offset = "0xBF1AEC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mGpgsDataSource;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return GPGSDataSource;
			}
			[Token(Token = "0x60003A8")]
			[Address(RVA = "0xBF1AF4", Offset = "0xBF1AF4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mGpgsDataSource = value;\n\treturn;\n")]
			set
			{
				GPGSDataSource = value;
			}
		}

		[Token(Token = "0x60003A9")]
		[Address(RVA = "0xBF1AFC", Offset = "0xBF1AFC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EDA948]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022EB4]) = v38;\nL_0014:\n\tthis.mAutoInit = 1;\n\tthis.mAndroidXmlResources = v45.Empty;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GameServicesSettings()
		{
			mAutoInit = true;
			mAndroidXmlResources = string.Empty;
		}
	}
}
