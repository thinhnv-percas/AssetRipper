using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.InitializationSystem.Runtime
{
	[Token(Token = "0x2000011")]
	public abstract class InitializationAttribute : Attribute
	{
		[Token(Token = "0x17000002")]
		[field: Token(Token = "0x4000019")]
		[field: FieldOffset(Offset = "0x10")]
		public Type[] TargetTypes
		{
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x81B1C20", Offset = "0x81B1C20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.TargetTypes;\n")]
			get;
		}

		[Token(Token = "0x6000031")]
		[Address(RVA = "0x81B1BB8", Offset = "0x81B1BB8", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.TargetTypes = targetTypes;\n\treturn;\n")]
		protected InitializationAttribute(Type[] targetTypes)
		{
			TargetTypes = targetTypes;
		}
	}
}
