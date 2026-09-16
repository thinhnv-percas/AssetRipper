using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x73B550", Offset = "0x73B550")]
	[Token(Token = "0x2000012")]
	internal sealed class MonoPInvokeCallbackAttribute : Attribute
	{
		[Token(Token = "0x6000081")]
		[Address(RVA = "0x160154C", Offset = "0x160154C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MonoPInvokeCallbackAttribute(Type t)
		{
		}
	}
}
