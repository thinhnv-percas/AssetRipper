using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000003")]
public sealed class CallSite
{
	[Token(Token = "0x17000002")]
	[field: Token(Token = "0x4000002")]
	[field: FieldOffset(Offset = "0x10")]
	public string ClassName
	{
		[Token(Token = "0x6000003")]
		[Address(RVA = "0x3F2E2F4", Offset = "0x3F2E2F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.ClassName;\n")]
		get;
	}

	[Token(Token = "0x17000003")]
	[field: Token(Token = "0x4000003")]
	[field: FieldOffset(Offset = "0x18")]
	public string FunctionName
	{
		[Token(Token = "0x6000004")]
		[Address(RVA = "0x3F2E2FC", Offset = "0x3F2E2FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.FunctionName;\n")]
		get;
	}

	[Token(Token = "0x17000004")]
	[field: Token(Token = "0x4000004")]
	[field: FieldOffset(Offset = "0x20")]
	public string Path
	{
		[Token(Token = "0x6000005")]
		[Address(RVA = "0x3F2E304", Offset = "0x3F2E304", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Path;\n")]
		get;
	}

	[Token(Token = "0x17000005")]
	[field: Token(Token = "0x4000005")]
	[field: FieldOffset(Offset = "0x28")]
	public int Line
	{
		[Token(Token = "0x6000006")]
		[Address(RVA = "0x3F2E30C", Offset = "0x3F2E30C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Line;\n")]
		get;
	}

	[Token(Token = "0x6000007")]
	[Address(RVA = "0x3F2E314", Offset = "0x3F2E314", Length = "0x78")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.ClassName = className;\n\tthis.FunctionName = functionName;\n\tthis.Path = path;\n\tthis.Line = line;\n\treturn;\n")]
	public CallSite(string className, string functionName, string path, int line)
	{
		ClassName = className;
		FunctionName = functionName;
		Path = path;
		Line = line;
	}
}
