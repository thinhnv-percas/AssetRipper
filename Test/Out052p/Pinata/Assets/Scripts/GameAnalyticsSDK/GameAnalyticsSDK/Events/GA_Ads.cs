using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Wrapper;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000011")]
	public static class GA_Ads
	{
		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x159FB18", Offset = "0x159FB18", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EE5F10]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, adType, adSdkName, adPlacement, duration, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297C3]) = v50;\nL_0021:\n\tgoto L_0035;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0035;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, adType, adSdkName, adPlacement, duration, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0035:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddAdEventWithDuration(adAction, adType, adSdkName, adPlacement, duration);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, long duration)
		{
			GA_Wrapper.AddAdEventWithDuration(adAction, adType, adSdkName, adPlacement, duration);
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x159FC40", Offset = "0x159FC40", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EF0640]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, adType, adSdkName, adPlacement, noAdReason, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20297C4]) = v50;\nL_0021:\n\tgoto L_0035;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0035;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, adType, adSdkName, adPlacement, noAdReason, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0035:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddAdEventWithReason(adAction, adType, adSdkName, adPlacement, noAdReason);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement, GAAdError noAdReason)
		{
			GA_Wrapper.AddAdEventWithReason(adAction, adType, adSdkName, adPlacement, noAdReason);
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x159FD68", Offset = "0x159FD68", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EF4758]);\n\tv31 = *([v30 @ X8_v9]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20297C5]) = v47;\nL_001F:\n\tgoto L_0031;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0031;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, adType, adSdkName, adPlacement, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0031:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddAdEvent(adAction, adType, adSdkName, adPlacement);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAAdAction adAction, GAAdType adType, string adSdkName, string adPlacement)
		{
			GA_Wrapper.AddAdEvent(adAction, adType, adSdkName, adPlacement);
		}
	}
}
