using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7417D4", Offset = "0x7417D4")]
	[Token(Token = "0x200000C")]
	public class HideReferenceObjectPickerAttribute : Attribute
	{
		[Token(Token = "0x6000008")]
		[Address(RVA = "0x167F148", Offset = "0x167F148", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public HideReferenceObjectPickerAttribute()
		{
		}
	}
}
