using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.DomainReload.Runtime
{
	[AttributeUsage(AttributeTargets.Field)]
	[Token(Token = "0x2000004")]
	public class ClearOnReloadAttribute : Attribute
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		public readonly object valueToAssign;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		public readonly bool assignNewTypeInstance;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x3F447F8", Offset = "0x3F447F8", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.valueToAssign = 0;\n\tthis.assignNewTypeInstance = 0;\n\treturn;\n")]
		public ClearOnReloadAttribute()
		{
			valueToAssign = null;
			assignNewTypeInstance = false;
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x3F44830", Offset = "0x3F44830", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.valueToAssign = valueToAssign;\n\tthis.assignNewTypeInstance = 0;\n\treturn;\n")]
		public ClearOnReloadAttribute(object valueToAssign)
		{
			this.valueToAssign = valueToAssign;
			assignNewTypeInstance = false;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x3F4486C", Offset = "0x3F4486C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.valueToAssign = 0;\n\tthis.assignNewTypeInstance = assignNewTypeInstance;\n\treturn;\n")]
		public ClearOnReloadAttribute(bool assignNewTypeInstance = false)
		{
			valueToAssign = null;
			this.assignNewTypeInstance = assignNewTypeInstance;
		}
	}
}
