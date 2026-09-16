using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000006")]
public class IronSourceError
{
	[Token(Token = "0x400001A")]
	[FieldOffset(Offset = "0x10")]
	internal string description;

	[Token(Token = "0x400001B")]
	[FieldOffset(Offset = "0x18")]
	internal int code;

	[Token(Token = "0x6000067")]
	[Address(RVA = "0x159412C", Offset = "0x159412C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.code;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public int getErrorCode()
	{
		return code;
	}

	[Token(Token = "0x6000068")]
	[Address(RVA = "0x1594134", Offset = "0x1594134", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.description;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string getDescription()
	{
		return description;
	}

	[Token(Token = "0x6000069")]
	[Address(RVA = "0x159413C", Offset = "0x159413C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.code;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public int getCode()
	{
		return code;
	}

	[Token(Token = "0x600006A")]
	[Address(RVA = "0x1594144", Offset = "0x1594144", Length = "0x3C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.code = errorCode;\n\tthis.description = errorDescription;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourceError(int errorCode, string errorDescription)
	{
		code = errorCode;
		description = errorDescription;
	}

	[Token(Token = "0x600006B")]
	[Address(RVA = "0x1594180", Offset = "0x1594180", Length = "0x7C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0C3E8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20296D0]) = v38;\nL_0014:\n\tv40 = this.code;\n\t// 25 Box v45 @ X0_v3 (System.Object), typeof(System.Int32), &v40 @ X8_v3 (System.Int32)\n\treturnVal1 = System.String::Concat(v45, \" : \", this.description);\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override string ToString()
	{
		int num = code;
		object obj = num;
		return string.Concat(obj, " : ", description);
	}
}
