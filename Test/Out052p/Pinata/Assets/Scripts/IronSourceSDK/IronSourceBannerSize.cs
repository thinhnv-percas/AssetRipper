using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x200000A")]
public class IronSourceBannerSize
{
	[Token(Token = "0x400004A")]
	[FieldOffset(Offset = "0x10")]
	private int width;

	[Token(Token = "0x400004B")]
	[FieldOffset(Offset = "0x14")]
	private int height;

	[Token(Token = "0x400004C")]
	[FieldOffset(Offset = "0x18")]
	private string description;

	[Token(Token = "0x400004D")]
	public static IronSourceBannerSize BANNER = new IronSourceBannerSize
	{
		width = 0,
		description = "BANNER"
	};

	[Token(Token = "0x400004E")]
	public static IronSourceBannerSize LARGE = new IronSourceBannerSize
	{
		width = 0,
		description = "LARGE"
	};

	[Token(Token = "0x400004F")]
	public static IronSourceBannerSize RECTANGLE = new IronSourceBannerSize
	{
		width = 0,
		description = "RECTANGLE"
	};

	[Token(Token = "0x4000050")]
	public static IronSourceBannerSize SMART = new IronSourceBannerSize
	{
		width = 0,
		description = "SMART"
	};

	[Token(Token = "0x17000007")]
	public string Description
	{
		[Token(Token = "0x6000175")]
		[Address(RVA = "0x15938B0", Offset = "0x15938B0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.description;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Description;
		}
	}

	[Token(Token = "0x17000008")]
	public int Width
	{
		[Token(Token = "0x6000176")]
		[Address(RVA = "0x15938B8", Offset = "0x15938B8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.width;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Width;
		}
	}

	[Token(Token = "0x17000009")]
	public int Height
	{
		[Token(Token = "0x6000177")]
		[Address(RVA = "0x15938C0", Offset = "0x15938C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.height;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return Height;
		}
	}

	[Token(Token = "0x6000172")]
	[Address(RVA = "0x159380C", Offset = "0x159380C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private IronSourceBannerSize()
	{
	}

	[Token(Token = "0x6000173")]
	[Address(RVA = "0x1593814", Offset = "0x1593814", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EA56B0]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, width, height, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20296C7]) = v44;\nL_0019:\n\tSystem.Object::.ctor(this);\n\tthis.width = width;\n\tthis.height = height;\n\tthis.description = \"CUSTOM\";\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourceBannerSize(int width, int height)
	{
		this.width = width;
		this.height = height;
		description = "CUSTOM";
	}

	[Token(Token = "0x6000174")]
	[Address(RVA = "0x1593884", Offset = "0x1593884", Length = "0x2C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.width = 0;\n\tthis.description = description;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public IronSourceBannerSize(string description)
	{
		width = 0;
		this.description = description;
	}
}
