using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x74186C", Offset = "0x74186C")]
	[Token(Token = "0x2000011")]
	public class PropertyOrderAttribute : Attribute
	{
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x10")]
		public int Order;

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x167F320", Offset = "0x167F320", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.Order = order;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PropertyOrderAttribute(int order)
		{
			Order = order;
		}
	}
}
