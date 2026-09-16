using AssetRipperInjected;
using Cpp2ILInjected;

[Token(Token = "0x2000009")]
public static class IronSourceAdUnits
{
	[Token(Token = "0x17000003")]
	public static string REWARDED_VIDEO
	{
		[Token(Token = "0x600016E")]
		[Address(RVA = "0x15936EC", Offset = "0x15936EC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EEC398]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296C3]) = v35;\nL_0018:\n\treturn \"rewardedvideo\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return "rewardedvideo";
		}
	}

	[Token(Token = "0x17000004")]
	public static string INTERSTITIAL
	{
		[Token(Token = "0x600016F")]
		[Address(RVA = "0x1593734", Offset = "0x1593734", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EBE208]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296C4]) = v35;\nL_0018:\n\treturn \"interstitial\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return "interstitial";
		}
	}

	[Token(Token = "0x17000005")]
	public static string OFFERWALL
	{
		[Token(Token = "0x6000170")]
		[Address(RVA = "0x159377C", Offset = "0x159377C", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE7C70]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296C5]) = v35;\nL_0018:\n\treturn \"offerwall\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return "offerwall";
		}
	}

	[Token(Token = "0x17000006")]
	public static string BANNER
	{
		[Token(Token = "0x6000171")]
		[Address(RVA = "0x15937C4", Offset = "0x15937C4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1ED3E10]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20296C6]) = v35;\nL_0018:\n\treturn \"banner\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return "banner";
		}
	}
}
