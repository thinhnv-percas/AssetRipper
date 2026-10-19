using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
[Token(Token = "0x2000002")]
public class OnContainerInitializeAttribute : Attribute
{
	[Token(Token = "0x17000001")]
	[field: Token(Token = "0x4000001")]
	[field: FieldOffset(Offset = "0x10")]
	public Type[] TargetTypes
	{
		[Token(Token = "0x6000001")]
		[Address(RVA = "0x3F2E2B8", Offset = "0x3F2E2B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.TargetTypes;\n")]
		get;
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x3F2E2C0", Offset = "0x3F2E2C0", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.TargetTypes = targetTypes;\n\treturn;\n")]
	public OnContainerInitializeAttribute(params Type[] targetTypes)
	{
		TargetTypes = targetTypes;
	}
}
