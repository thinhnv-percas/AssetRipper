using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[AttributeUsage(AttributeTargets.Method)]
[Token(Token = "0x2000009")]
public sealed class MonoPInvokeCallbackAttribute : Attribute
{
	[Token(Token = "0x400000D")]
	[FieldOffset(Offset = "0x10")]
	private Type type;

	[Token(Token = "0x6000029")]
	[Address(RVA = "0x3C6143C", Offset = "0x3C6143C", Length = "0x34")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Attribute::.ctor(this);\n\tthis.type = t;\n\treturn;\n")]
	public MonoPInvokeCallbackAttribute(Type t)
	{
		type = t;
	}
}
