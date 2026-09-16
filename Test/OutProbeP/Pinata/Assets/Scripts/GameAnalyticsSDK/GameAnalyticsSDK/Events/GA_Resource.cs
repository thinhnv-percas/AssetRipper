using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Wrapper;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000017")]
	public static class GA_Resource
	{
		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x15A0DF8", Offset = "0x15A0DF8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EA9978]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, currency, itemType, itemId, fields, methodInfo, v42, v43, amount, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([20297D2]) = v53;\nL_0023:\n\tgoto L_0039;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_0039;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, currency, itemType, itemId, fields, methodInfo, v42, v43, amount, v44, v45, v46, v47, v48, v49, v50);\nL_0039:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddResourceEvent(flowType, currency, amount, itemType, itemId, fields);\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(GAResourceFlowType flowType, string currency, float amount, string itemType, string itemId, IDictionary<string, object> fields)
		{
			GA_Wrapper.AddResourceEvent(flowType, currency, amount, itemType, itemId, fields);
		}
	}
}
