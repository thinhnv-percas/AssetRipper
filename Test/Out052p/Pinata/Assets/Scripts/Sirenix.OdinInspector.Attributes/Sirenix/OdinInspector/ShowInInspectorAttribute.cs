using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using JetBrains.Annotations;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7418F0", Offset = "0x7418F0")]
	[MeansImplicitUse]
	[Token(Token = "0x2000013")]
	public class ShowInInspectorAttribute : Attribute
	{
		[Token(Token = "0x600000E")]
		[Address(RVA = "0x167F378", Offset = "0x167F378", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ShowInInspectorAttribute()
		{
		}
	}
}
