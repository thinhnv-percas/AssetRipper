using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x741750", Offset = "0x741750")]
	[Token(Token = "0x2000006")]
	public class VerticalGroupAttribute : PropertyGroupAttribute
	{
		[Token(Token = "0x6000005")]
		[Address(RVA = "0x167F49C", Offset = "0x167F49C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSirenix.OdinInspector.PropertyGroupAttribute::.ctor(this, groupId, order);\n\treturn;\n")]
		public VerticalGroupAttribute(string groupId, int order = 0)
			: base(groupId, order)
		{
		}
	}
}
