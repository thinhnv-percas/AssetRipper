using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x200000E")]
	public class AppInfo
	{
		[Token(Token = "0x1700000B")]
		public string ClientId
		{
			[CompilerGenerated]
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x15C6DB8", Offset = "0x15C6DB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ClientId>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ClientId;
			}
		}

		[Token(Token = "0x1700000C")]
		public string AppSlug
		{
			[CompilerGenerated]
			[Token(Token = "0x6000047")]
			[Address(RVA = "0x15C6DC0", Offset = "0x15C6DC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<AppSlug>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return AppSlug;
			}
		}

		[Token(Token = "0x1700000D")]
		public string ClientKey
		{
			[CompilerGenerated]
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x15C6DC8", Offset = "0x15C6DC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ClientKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ClientKey;
			}
		}

		[Token(Token = "0x1700000E")]
		public string RSAPublicKey
		{
			[CompilerGenerated]
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x15C6DD0", Offset = "0x15C6DD0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<RSAPublicKey>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return RSAPublicKey;
			}
		}
	}
}
