using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000B6")]
	public class EnumFlagsAttribute : PropertyAttribute
	{
		[Token(Token = "0x40003A2")]
		[FieldOffset(Offset = "0x10")]
		public string enumName;

		[Token(Token = "0x60006E3")]
		[Address(RVA = "0xBFB6B8", Offset = "0xBFB6B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnumFlagsAttribute()
		{
		}

		[Token(Token = "0x60006E4")]
		[Address(RVA = "0xBFB6C0", Offset = "0xBFB6C0", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.enumName = name;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnumFlagsAttribute(string name)
		{
			enumName = name;
		}
	}
}
