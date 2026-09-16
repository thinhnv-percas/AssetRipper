using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000004")]
public class AppsFlyerTrackerCallbacks : MonoBehaviour
{
	[Token(Token = "0x600002C")]
	[Address(RVA = "0x1667384", Offset = "0x1667384", Length = "0x48")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EF86F0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF94]) = v35;\nL_0018:\n\tAppsFlyerTrackerCallbacks::printCallback(v32, \"AppsFlyerTrackerCallbacks on Start\");\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void Start()
	{
		printCallback("AppsFlyerTrackerCallbacks on Start");
	}

	[Token(Token = "0x600002D")]
	[Address(RVA = "0x1667434", Offset = "0x1667434", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
	private void Update()
	{
	}

	[Token(Token = "0x600002E")]
	[Address(RVA = "0x1667438", Offset = "0x1667438", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF36E8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, conversionData, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF95]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: got conversion data = \", conversionData);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void didReceiveConversionData(string conversionData)
	{
		string text = "AppsFlyerTrackerCallbacks:: got conversion data = " + conversionData;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x600002F")]
	[Address(RVA = "0x1667494", Offset = "0x1667494", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBA450]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF96]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: got conversion data error = \", error);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void didReceiveConversionDataWithError(string error)
	{
		string text = "AppsFlyerTrackerCallbacks:: got conversion data error = " + error;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x6000030")]
	[Address(RVA = "0x16674F0", Offset = "0x16674F0", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF8FA8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, validateResult, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF97]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: got didFinishValidateReceipt  = \", validateResult);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void didFinishValidateReceipt(string validateResult)
	{
		string text = "AppsFlyerTrackerCallbacks:: got didFinishValidateReceipt  = " + validateResult;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x6000031")]
	[Address(RVA = "0x166754C", Offset = "0x166754C", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA4E00]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF98]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: got idFinishValidateReceiptWithError error = \", error);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void didFinishValidateReceiptWithError(string error)
	{
		string text = "AppsFlyerTrackerCallbacks:: got idFinishValidateReceiptWithError error = " + error;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x6000032")]
	[Address(RVA = "0x16675A8", Offset = "0x16675A8", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE90B8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, validateResult, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF99]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: got onAppOpenAttribution  = \", validateResult);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onAppOpenAttribution(string validateResult)
	{
		string text = "AppsFlyerTrackerCallbacks:: got onAppOpenAttribution  = " + validateResult;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x6000033")]
	[Address(RVA = "0x1667604", Offset = "0x1667604", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF1BC0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF9A]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: got onAppOpenAttributionFailure error = \", error);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onAppOpenAttributionFailure(string error)
	{
		string text = "AppsFlyerTrackerCallbacks:: got onAppOpenAttributionFailure error = " + error;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x6000034")]
	[Address(RVA = "0x1667660", Offset = "0x1667660", Length = "0x48")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F0AF68]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202AF9B]) = v35;\nL_0018:\n\tAppsFlyerTrackerCallbacks::printCallback(v32, \"AppsFlyerTrackerCallbacks:: got onInAppBillingSuccess succcess\");\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInAppBillingSuccess()
	{
		printCallback("AppsFlyerTrackerCallbacks:: got onInAppBillingSuccess succcess");
	}

	[Token(Token = "0x6000035")]
	[Address(RVA = "0x16676A8", Offset = "0x16676A8", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB5820]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, error, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF9C]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: got onInAppBillingFailure error = \", error);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInAppBillingFailure(string error)
	{
		string text = "AppsFlyerTrackerCallbacks:: got onInAppBillingFailure error = " + error;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x6000036")]
	[Address(RVA = "0x1667704", Offset = "0x1667704", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC7380]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, link, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF9D]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"AppsFlyerTrackerCallbacks:: generated userInviteLink \", link);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onInviteLinkGenerated(string link)
	{
		string text = "AppsFlyerTrackerCallbacks:: generated userInviteLink " + link;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
	}

	[Token(Token = "0x6000037")]
	[Address(RVA = "0x1667760", Offset = "0x1667760", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED7728]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, link, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF9E]) = v38;\nL_0018:\n\tv44 = System.String::Concat(\"onOpenStoreLinkGenerated:: generated store link \", link);\n\tAppsFlyerTrackerCallbacks::printCallback(v44, v44);\n\tUnityEngine.Application::OpenURL(link);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void onOpenStoreLinkGenerated(string link)
	{
		string text = "onOpenStoreLinkGenerated:: generated store link " + link;
		((AppsFlyerTrackerCallbacks)(object)text).printCallback(text);
		Application.OpenURL(link);
	}

	[Token(Token = "0x6000038")]
	[Address(RVA = "0x16673CC", Offset = "0x16673CC", Length = "0x68")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EFA460]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, str, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([202AF9F]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, str, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0026:\n\tUnityEngine.Debug::Log(str);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private void printCallback(string str)
	{
		Debug.Log(str);
	}

	[Token(Token = "0x6000039")]
	[Address(RVA = "0x16677C8", Offset = "0x16677C8", Length = "0x1008")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n\tUnityEngine.Canvas::.ctor(X0, X1);\n\treturn;\n\tX0 = *([X20]);\n\tX0 = 0x1662008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1022 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public AppsFlyerTrackerCallbacks()
	{
	}
}
