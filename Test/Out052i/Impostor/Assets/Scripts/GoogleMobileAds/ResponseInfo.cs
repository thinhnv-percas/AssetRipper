using AssetRipperInjected;
using Cpp2ILInjected;
using GoogleMobileAds.Common;

[Token(Token = "0x2000002")]
public class ResponseInfo
{
	[Token(Token = "0x4000001")]
	[FieldOffset(Offset = "0x10")]
	private IResponseInfoClient client;

	[Token(Token = "0x6000001")]
	[Address(RVA = "0x133C060", Offset = "0x133C060", Length = "0x28")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.client = client;\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ResponseInfo(IResponseInfoClient client)
	{
		this.client = client;
	}

	[Token(Token = "0x6000002")]
	[Address(RVA = "0x133C088", Offset = "0x133C088", Length = "0xA0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IResponseInfoClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3671D]) = v33;\nL_0019:\n\tgoto L_0043;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = v34;\n\tv80 = 0;\n\tv81 = 0xB349B4(v79, v40, v80, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0043;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 << 4;\n\tv150 = v37 + v149;\n\tv151 = v150 + 0x138;\nL_0043:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IResponseInfoClient::GetMediationAdapterClassName(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string GetMediationAdapterClassName()
	{
		return client.GetMediationAdapterClassName();
	}

	[Token(Token = "0x6000003")]
	[Address(RVA = "0x133C128", Offset = "0x133C128", Length = "0xA4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv14 = GoogleMobileAds.Common.IResponseInfoClient;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A3671E]) = v33;\nL_0019:\n\tgoto L_0044;\n\tv43 = *([v37 @ X8_v3+B0]);\n\tv44 = v43 + 8;\n\tv46 = *([v93 @ X10_v7-8]);\n\tv98 = v46 == v40;\n\tif (v98) goto L_0038;\n\tv76 = v92 - 1;\n\tv78 = v93 + 0x10;\n\tv49 = v92 != 1;\n\tif (v49) goto L_FFFFFFFF;\n\tv79 = 1;\n\tv80 = v34;\n\tv81 = 0xB349B4(v80, v40, v79, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tgoto L_0044;\nL_0038:\n\tv148 = *([v93 @ X10_v7]);\n\tv149 = v148 + 1;\n\tv150 = v149 << 4;\n\tv151 = v37 + v150;\n\tv152 = v151 + 0x138;\nL_0044:\n\tinterfaceTailCallResult = GoogleMobileAds.Common.IResponseInfoClient::GetResponseId(this.client);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public string GetResponseId()
	{
		return client.GetResponseId();
	}

	[Token(Token = "0x6000004")]
	[Address(RVA = "0x133C1CC", Offset = "0x133C1CC", Length = "0x20")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.client;\n\tv5 = *([v2 @ X0_v1 (GoogleMobileAds.Common.IResponseInfoClient)]);\n\tv6 = *([v5 @ X8_v1 (Il2CppClass<GoogleMobileAds.Common.IResponseInfoClient>)+168]);\n\tv7 = *([v5 @ X8_v1 (Il2CppClass<GoogleMobileAds.Common.IResponseInfoClient>)+170]);\n\t// 10 IndirectJump v6 @ X2_v1, v2 @ X0_v1 (GoogleMobileAds.Common.IResponseInfoClient), v2 @ X0_v1 (GoogleMobileAds.Common.IResponseInfoClient), v7 @ X1_v1, v6 @ X2_v1, v9 @ X3, v10 @ X4, v11 @ X5, v12 @ X6, v13 @ X7, v14 @ V0, v15 @ V1, v16 @ V2, v17 @ V3, v18 @ V4, v19 @ V5, v20 @ V6, v21 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public override string ToString()
	{
		//IL_0017: Expected I, but got O
		//IL_0027: Expected O, but got I
		//IL_0037: Expected O, but got I
		IResponseInfoClient responseInfoClient = client;
		nint num = (nint)responseInfoClient;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X8_v1 (Il2CppClass<GoogleMobileAds.Common.IResponseInfoClient>)+168]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5 @ X8_v1 (Il2CppClass<GoogleMobileAds.Common.IResponseInfoClient>)+170]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X2_v1 (should have been resolved before IL gen)");
		return null;
	}
}
