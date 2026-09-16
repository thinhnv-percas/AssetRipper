using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x2000017")]
	public sealed class AppOptions : IDisposable
	{
		[CompilerGenerated]
		[AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x73B784", Offset = "0x73B784")]
		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x40")]
		private string _003CPackageName_003Ek__BackingField;

		[Token(Token = "0x17000019")]
		public Uri DatabaseUrl
		{
			[CompilerGenerated]
			[Token(Token = "0x6000097")]
			[Address(RVA = "0x15FAA44", Offset = "0x15FAA44", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<DatabaseUrl>k__BackingField = value;\n\treturn;\n")]
			set
			{
				DatabaseUrl = value;
			}
		}

		[Token(Token = "0x1700001A")]
		public string AppId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000098")]
			[Address(RVA = "0x15FAA4C", Offset = "0x15FAA4C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AppId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppId;
			}
			[CompilerGenerated]
			[Token(Token = "0x6000099")]
			[Address(RVA = "0x15FAA54", Offset = "0x15FAA54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<AppId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				AppId = value;
			}
		}

		[Token(Token = "0x1700001B")]
		public string ApiKey
		{
			[CompilerGenerated]
			[Token(Token = "0x600009A")]
			[Address(RVA = "0x15FAA5C", Offset = "0x15FAA5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ApiKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ApiKey;
			}
			[CompilerGenerated]
			[Token(Token = "0x600009B")]
			[Address(RVA = "0x15FAA64", Offset = "0x15FAA64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ApiKey>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ApiKey = value;
			}
		}

		[Token(Token = "0x1700001C")]
		public string MessageSenderId
		{
			[CompilerGenerated]
			[Token(Token = "0x600009C")]
			[Address(RVA = "0x15FAA6C", Offset = "0x15FAA6C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<MessageSenderId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				MessageSenderId = value;
			}
		}

		[Token(Token = "0x1700001D")]
		public string StorageBucket
		{
			[CompilerGenerated]
			[Token(Token = "0x600009D")]
			[Address(RVA = "0x15FAA74", Offset = "0x15FAA74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<StorageBucket>k__BackingField = value;\n\treturn;\n")]
			set
			{
				StorageBucket = value;
			}
		}

		[Token(Token = "0x1700001E")]
		public string ProjectId
		{
			[CompilerGenerated]
			[Token(Token = "0x600009E")]
			[Address(RVA = "0x15FAA7C", Offset = "0x15FAA7C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ProjectId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				ProjectId = value;
			}
		}

		[Token(Token = "0x1700001F")]
		internal string PackageName
		{
			[CompilerGenerated]
			[Token(Token = "0x600009F")]
			[Address(RVA = "0x15FAA84", Offset = "0x15FAA84", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<PackageName>k__BackingField = value;\n\treturn;\n")]
			set
			{
				_003CPackageName_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x15FA5B4", Offset = "0x15FA5B4", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv17 = Firebase.AppOptionsInternal::get_DatabaseUrl(other);\n\tthis.<DatabaseUrl>k__BackingField = v17;\n\tv35 = Firebase.AppOptionsInternal::get_AppId(other);\n\tthis.<AppId>k__BackingField = v35;\n\tv37 = Firebase.AppOptionsInternal::get_ApiKey(other);\n\tthis.<ApiKey>k__BackingField = v37;\n\tv49 = Firebase.AppOptionsInternal::get_MessageSenderId(other);\n\tthis.<MessageSenderId>k__BackingField = v49;\n\tv51 = Firebase.AppOptionsInternal::get_StorageBucket(other);\n\tthis.<StorageBucket>k__BackingField = v51;\n\tv53 = Firebase.AppOptionsInternal::get_ProjectId(other);\n\tthis.<ProjectId>k__BackingField = v53;\n\tv41 = Firebase.AppOptionsInternal::get_PackageName(other);\n\tthis.<PackageName>k__BackingField = v41;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal AppOptions(AppOptionsInternal other)
		{
			Uri databaseUrl = other.DatabaseUrl;
			DatabaseUrl = databaseUrl;
			string appId = other.AppId;
			AppId = appId;
			string apiKey = other.ApiKey;
			ApiKey = apiKey;
			string messageSenderId = other.MessageSenderId;
			MessageSenderId = messageSenderId;
			string storageBucket = other.StorageBucket;
			StorageBucket = storageBucket;
			string projectId = other.ProjectId;
			ProjectId = projectId;
			string packageName = other.PackageName;
			_003CPackageName_003Ek__BackingField = packageName;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x15FAA40", Offset = "0x15FAA40", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public void Dispose()
		{
		}
	}
}
