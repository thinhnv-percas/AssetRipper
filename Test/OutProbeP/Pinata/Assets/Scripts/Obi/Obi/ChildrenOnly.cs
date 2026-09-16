using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x74496C", Offset = "0x74496C")]
	[Token(Token = "0x2000047")]
	public class ChildrenOnly : MultiPropertyAttribute
	{
		[Token(Token = "0x6000366")]
		[Address(RVA = "0xE2E758", Offset = "0xE2E758", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ChildrenOnly()
		{
		}
	}
}
