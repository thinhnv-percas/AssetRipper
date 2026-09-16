using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x74179C", Offset = "0x74179C")]
	[Token(Token = "0x200000B")]
	public sealed class HideMonoScriptAttribute : Attribute
	{
		[Token(Token = "0x6000007")]
		[Address(RVA = "0x167F140", Offset = "0x167F140", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HideMonoScriptAttribute()
		{
		}
	}
}
