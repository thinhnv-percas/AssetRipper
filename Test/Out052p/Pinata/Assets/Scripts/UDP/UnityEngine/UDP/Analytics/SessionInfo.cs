using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP.Analytics
{
	[HideInInspector]
	[Token(Token = "0x200002A")]
	internal class SessionInfo
	{
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x10")]
		private string m_AppId;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x18")]
		private string m_SessionId;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x20")]
		private string m_ClientId;

		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x28")]
		private string m_DeviceId;

		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x30")]
		private string m_Platform;

		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x38")]
		private string m_TargetStore;

		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x40")]
		private string m_SystemInfo;

		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x48")]
		internal bool m_Vr;

		[Token(Token = "0x1700001D")]
		public string MAppId
		{
			[Token(Token = "0x60000CB")]
			[Address(RVA = "0x15C6AE0", Offset = "0x15C6AE0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_AppId = value;\n\treturn;\n")]
			set
			{
				MAppId = value;
			}
		}

		[Token(Token = "0x1700001E")]
		public string MSessionId
		{
			[Token(Token = "0x60000CC")]
			[Address(RVA = "0x15C6AE8", Offset = "0x15C6AE8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_SessionId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MSessionId;
			}
			[Token(Token = "0x60000CD")]
			[Address(RVA = "0x15C6AF0", Offset = "0x15C6AF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_SessionId = value;\n\treturn;\n")]
			set
			{
				MSessionId = value;
			}
		}

		[Token(Token = "0x1700001F")]
		public string MClientId
		{
			[Token(Token = "0x60000CE")]
			[Address(RVA = "0x15C6AF8", Offset = "0x15C6AF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_ClientId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MClientId;
			}
			[Token(Token = "0x60000CF")]
			[Address(RVA = "0x15C6B00", Offset = "0x15C6B00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_ClientId = value;\n\treturn;\n")]
			set
			{
				MClientId = value;
			}
		}

		[Token(Token = "0x17000020")]
		public string MDeviceId
		{
			[Token(Token = "0x60000D0")]
			[Address(RVA = "0x15C6B08", Offset = "0x15C6B08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_DeviceId;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MDeviceId;
			}
			[Token(Token = "0x60000D1")]
			[Address(RVA = "0x15C6B10", Offset = "0x15C6B10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_DeviceId = value;\n\treturn;\n")]
			set
			{
				MDeviceId = value;
			}
		}

		[Token(Token = "0x17000021")]
		public string MPlatform
		{
			[Token(Token = "0x60000D2")]
			[Address(RVA = "0x15C6B18", Offset = "0x15C6B18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Platform;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MPlatform;
			}
			[Token(Token = "0x60000D3")]
			[Address(RVA = "0x15C6B20", Offset = "0x15C6B20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Platform = value;\n\treturn;\n")]
			set
			{
				MPlatform = value;
			}
		}

		[Token(Token = "0x17000022")]
		public string MTargetStore
		{
			[Token(Token = "0x60000D4")]
			[Address(RVA = "0x15C6B28", Offset = "0x15C6B28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_TargetStore;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MTargetStore;
			}
			[Token(Token = "0x60000D5")]
			[Address(RVA = "0x15C6B30", Offset = "0x15C6B30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_TargetStore = value;\n\treturn;\n")]
			set
			{
				MTargetStore = value;
			}
		}

		[Token(Token = "0x17000023")]
		public string MSystemInfo
		{
			[Token(Token = "0x60000D6")]
			[Address(RVA = "0x15C6B38", Offset = "0x15C6B38", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_SystemInfo;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MSystemInfo;
			}
			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x15C6B40", Offset = "0x15C6B40", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_SystemInfo = value;\n\treturn;\n")]
			set
			{
				MSystemInfo = value;
			}
		}

		[Token(Token = "0x17000024")]
		public bool MVr
		{
			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x15C6B48", Offset = "0x15C6B48", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_Vr;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MVr;
			}
			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x15C6B50", Offset = "0x15C6B50", Length = "0xC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_Vr = value;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				m_Vr = value;
			}
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x15C4F74", Offset = "0x15C4F74", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SessionInfo()
		{
		}
	}
}
