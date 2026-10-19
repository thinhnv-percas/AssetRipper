using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Extensions
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	[Token(Token = "0x200000F")]
	public class EnumClassAttribute : PropertyAttribute
	{
		[Token(Token = "0x1700000D")]
		[field: Token(Token = "0x4000034")]
		[field: FieldOffset(Offset = "0x18")]
		public string Path
		{
			[Token(Token = "0x600004F")]
			[Address(RVA = "0x81A9A94", Offset = "0x81A9A94", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Path;\n")]
			get;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x81A9A9C", Offset = "0x81A9A9C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.PropertyAttribute::.ctor(this);\n\tthis.Path = path;\n\treturn;\n")]
		public EnumClassAttribute(string path)
		{
			Path = path;
		}
	}
}
