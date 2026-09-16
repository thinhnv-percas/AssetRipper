using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Common.MiniJSON;

namespace UnityEngine.UDP.Analytics.Events
{
	[Token(Token = "0x200002E")]
	internal class AppStopEvent : AndroidJavaProxy
	{
		[Token(Token = "0x4000090")]
		private const string EVENT_NAME = "appRuntimeAppStop";

		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<string, object> _params;

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x15C5990", Offset = "0x15C5990", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB8888]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, sessionInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202999A]) = v41;\nL_001B:\n\tgoto L_0026;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0026;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, sessionInfo, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0026:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.internal.analytics.IEvent\");\n\tv61 = UnityEngine.UDP.Analytics.Common::GetCommonParams(sessionInfo);\n\tthis._params = v61;\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppStopEvent(SessionInfo sessionInfo)
			: base("com.unity.udp.sdk.internal.analytics.IEvent")
		{
			Dictionary<string, object> commonParams = Common.GetCommonParams(sessionInfo);
			_params = commonParams;
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x15C65D4", Offset = "0x15C65D4", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F03A98]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202999B]) = v35;\nL_0018:\n\treturn \"appRuntimeAppStop\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetEventName()
		{
			return "appRuntimeAppStop";
		}

		[Token(Token = "0x60000E6")]
		[Address(RVA = "0x15C661C", Offset = "0x15C661C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Common.MiniJSON.Json+Serializer::Serialize(this._params);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetParams()
		{
			return Json.Serializer.Serialize(_params);
		}
	}
}
