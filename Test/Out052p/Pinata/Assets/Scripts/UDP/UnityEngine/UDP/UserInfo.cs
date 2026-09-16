using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.Scripting;

namespace UnityEngine.UDP
{
	[Token(Token = "0x200001A")]
	public class UserInfo
	{
		[Preserve]
		[Token(Token = "0x17000016")]
		public string Channel
		{
			[CompilerGenerated]
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x15CCE08", Offset = "0x15CCE08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Channel>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Channel;
			}
			[CompilerGenerated]
			[Token(Token = "0x600007B")]
			[Address(RVA = "0x15CCE10", Offset = "0x15CCE10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Channel>k__BackingField = value;\n\treturn;\n")]
			set
			{
				Channel = value;
			}
		}

		[Preserve]
		[Token(Token = "0x17000017")]
		public string UserId
		{
			[CompilerGenerated]
			[Token(Token = "0x600007C")]
			[Address(RVA = "0x15CCE18", Offset = "0x15CCE18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UserId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UserId;
			}
			[CompilerGenerated]
			[Token(Token = "0x600007D")]
			[Address(RVA = "0x15CCE20", Offset = "0x15CCE20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UserId>k__BackingField = value;\n\treturn;\n")]
			set
			{
				UserId = value;
			}
		}

		[Preserve]
		[Token(Token = "0x17000018")]
		public string UserLoginToken
		{
			[CompilerGenerated]
			[Token(Token = "0x600007E")]
			[Address(RVA = "0x15CCE28", Offset = "0x15CCE28", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<UserLoginToken>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return UserLoginToken;
			}
			[CompilerGenerated]
			[Token(Token = "0x600007F")]
			[Address(RVA = "0x15CCE30", Offset = "0x15CCE30", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<UserLoginToken>k__BackingField = value;\n\treturn;\n")]
			set
			{
				UserLoginToken = value;
			}
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x15C8DD0", Offset = "0x15C8DD0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public UserInfo()
		{
		}
	}
}
