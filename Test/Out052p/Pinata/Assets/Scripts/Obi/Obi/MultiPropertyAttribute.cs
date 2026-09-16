using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AttributeUsageAttribute), RVA = "0x7449D0", Offset = "0x7449D0")]
	[Token(Token = "0x200004C")]
	public abstract class MultiPropertyAttribute : PropertyAttribute
	{
		[Token(Token = "0x600036E")]
		[Address(RVA = "0xE2E760", Offset = "0xE2E760", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		protected internal MultiPropertyAttribute()
		{
		}
	}
}
