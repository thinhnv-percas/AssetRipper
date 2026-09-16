using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Wrapper;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000012")]
	public static class GA_Business
	{
		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x159FE80", Offset = "0x159FE80", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv46 = *([1EAAF18]);\n\tv47 = *([v46 @ X8_v11]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, amount, itemType, itemId, cartType, receipt, signature, fields, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([20297C6]) = v59;\nL_0027:\n\tgoto L_0038;\n\tv66 = *([v62 @ X0_v2+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_0038;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, amount, itemType, itemId, cartType, receipt, signature, fields, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0038:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddBusinessEventWithReceipt(currency, amount, itemType, itemId, cartType, receipt, \"google_play\", signature, fields);\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEventGooglePlay(string currency, int amount, string itemType, string itemId, string cartType, string receipt, string signature, IDictionary<string, object> fields)
		{
			GA_Wrapper.AddBusinessEventWithReceipt(currency, amount, itemType, itemId, cartType, receipt, "google_play", signature, fields);
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x15A001C", Offset = "0x15A001C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1F0CFA8]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, amount, itemType, itemId, cartType, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20297C7]) = v53;\nL_0023:\n\tgoto L_0039;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0039;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, amount, itemType, itemId, cartType, fields, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0039:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddBusinessEvent(currency, amount, itemType, itemId, cartType, fields);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(string currency, int amount, string itemType, string itemId, string cartType, IDictionary<string, object> fields)
		{
			GA_Wrapper.AddBusinessEvent(currency, amount, itemType, itemId, cartType, fields);
		}
	}
}
