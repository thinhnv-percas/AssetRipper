using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Wrapper;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000014")]
	public static class GA_Design
	{
		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x15A0608", Offset = "0x15A0608", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv26 = *([1ED9018]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, fields, methodInfo, v30, v31, v32, v33, v34, eventValue, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20297CB]) = v44;\nL_001B:\n\tv48 = 0;\n\tv51 = 0x115CA98(&v48 @ stack_-38_v1 (System.Nullable`1<System.Single>), Il2CppMethodInfo, methodInfo, v30, v31, v32, v33, v34, eventValue, v35, v36, v37, v38, v39, v40, v41);\n\tGameAnalyticsSDK.Events.GA_Design::CreateNewEvent(eventName, 0, fields);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(string eventName, float eventValue, IDictionary<string, object> fields)
		{
			float? num = null;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115CA98 (inside System.Nullable`1<System.Int64>::Unbox +0xA8)");
			CreateNewEvent(eventName, null, fields);
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x15A077C", Offset = "0x15A077C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tGameAnalyticsSDK.Events.GA_Design::CreateNewEvent(eventName, 0, fields);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void NewEvent(string eventName, IDictionary<string, object> fields)
		{
			CreateNewEvent(eventName, null, fields);
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x15A0694", Offset = "0x15A0694", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv29 = *([1F02138]);\n\tv30 = *([v29 @ X8_v18]);\n\tv31 = \"il2cpp_codegen_initialize_method\"(v30, eventValue, fields, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20297CC]) = v47;\nL_0019:\n\tv48 = eventValue & 0xFF00000000;\n\tv49 = v48 == 0;\n\tif (v49) goto L_0041;\n\tv54 = 0x115CAB0(&eventValue @ X1 (System.Nullable`1<System.Single>), Il2CppMethodInfo, fields, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0031;\n\tv84 = *([v64 @ X0_v8+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0031;\n\tv88 = \"il2cpp_codegen_runtime_class_init\"(v64, v53, fields, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0031:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddDesignEvent(eventName, v37, fields);\n\treturn;\nL_0041:\n\tgoto L_0051;\n\tv68 = *([v57 @ X0_v2+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0051;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v57, eventValue, fields, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0051:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::AddDesignEvent(eventName, fields);\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void CreateNewEvent(string eventName, float? eventValue, IDictionary<string, object> fields)
		{
			//IL_004b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0050: Expected I4, but got Unknown
			if ((int)((_003F?)eventValue & 0xFF00000000L) != 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115CAB0 (inside System.Nullable`1<System.Int64>::Unbox +0xC0)");
				float eventValue2 = default(float);
				GA_Wrapper.AddDesignEvent(eventName, eventValue2, fields);
			}
			else
			{
				GA_Wrapper.AddDesignEvent(eventName, fields);
			}
		}
	}
}
