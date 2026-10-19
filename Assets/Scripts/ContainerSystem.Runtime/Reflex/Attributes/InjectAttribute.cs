using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using JetBrains.Annotations;

namespace Reflex.Attributes
{
	[MeansImplicitUse(ImplicitUseKindFlags.Assign)]
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
	[Token(Token = "0x200003D")]
	public class InjectAttribute : Attribute
	{
		[Token(Token = "0x17000020")]
		[field: Token(Token = "0x400005F")]
		[field: FieldOffset(Offset = "0x10")]
		public bool IsOptional
		{
			[Token(Token = "0x60000CF")]
			[Address(RVA = "0x3F389EC", Offset = "0x3F389EC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.IsOptional;\n")]
			get;
			[Token(Token = "0x60000D0")]
			[Address(RVA = "0x3F389F4", Offset = "0x3F389F4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.IsOptional = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x60000D1")]
		[Address(RVA = "0x3F389FC", Offset = "0x3F389FC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.IsOptional = isOptional;\n\treturn;\n")]
		public InjectAttribute(bool isOptional = false)
		{
			IsOptional = isOptional;
		}
	}
}
