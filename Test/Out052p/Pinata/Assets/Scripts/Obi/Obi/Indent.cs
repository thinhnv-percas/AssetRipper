using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x744980", Offset = "0x744980")]
	[Token(Token = "0x2000048")]
	public class Indent : MultiPropertyAttribute
	{
		[Token(Token = "0x6000367")]
		[Address(RVA = "0xE2F180", Offset = "0xE2F180", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Indent()
		{
		}
	}
}
