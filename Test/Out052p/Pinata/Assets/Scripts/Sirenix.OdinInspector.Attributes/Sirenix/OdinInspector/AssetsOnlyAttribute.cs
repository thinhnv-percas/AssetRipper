using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x741678", Offset = "0x741678")]
	[Token(Token = "0x2000002")]
	public sealed class AssetsOnlyAttribute : Attribute
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x167F128", Offset = "0x167F128", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AssetsOnlyAttribute()
		{
		}
	}
}
