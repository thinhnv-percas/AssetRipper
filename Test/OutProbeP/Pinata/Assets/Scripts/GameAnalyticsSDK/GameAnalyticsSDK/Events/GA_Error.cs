using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Wrapper;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000015")]
	public static class GA_Error
	{
		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x15A052C", Offset = "0x15A052C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Error::CreateNewEvent(severity, message, fields);\n\treturn;\n")]
		public static void NewEvent(GAErrorSeverity severity, string message, IDictionary<string, object> fields)
		{
			CreateNewEvent(severity, message, fields);
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x15A088C", Offset = "0x15A088C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EEA778]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, message, fields, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20297CD]) = v44;\nL_001D:\n\tgoto L_002D;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_002D;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, message, fields, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002D:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddErrorEvent(severity, message, fields);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void CreateNewEvent(GAErrorSeverity severity, string message, IDictionary<string, object> fields)
		{
			GA_Wrapper.AddErrorEvent(severity, message, fields);
		}
	}
}
