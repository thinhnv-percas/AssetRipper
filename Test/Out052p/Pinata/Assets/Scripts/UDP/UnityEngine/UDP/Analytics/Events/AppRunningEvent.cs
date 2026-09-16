using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Common.MiniJSON;

namespace UnityEngine.UDP.Analytics.Events
{
	[Token(Token = "0x200002C")]
	internal class AppRunningEvent : AndroidJavaProxy
	{
		[Token(Token = "0x400008C")]
		private const string EVENT_NAME = "appRuntimeAppRunning";

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x20")]
		private Dictionary<string, object> _params;

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x15C5AAC", Offset = "0x15C5AAC", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1F095B0]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, sessionInfo, duration, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2029996]) = v44;\nL_001D:\n\tgoto L_0028;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, sessionInfo, duration, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.internal.analytics.IEvent\");\n\tv64 = UnityEngine.UDP.Analytics.Common::GetCommonParams(sessionInfo);\n\tthis._params = v64;\n\t// 50 Box v71 @ X0_v8 (System.Object), typeof(System.UInt64), &duration @ X2 (System.UInt64)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v64, \"duration\", v71);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AppRunningEvent(SessionInfo sessionInfo, ulong duration)
			: base("com.unity.udp.sdk.internal.analytics.IEvent")
		{
			Dictionary<string, object> dictionary = (_params = Common.GetCommonParams(sessionInfo));
			object value = duration;
			dictionary.Add("duration", value);
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x15C6534", Offset = "0x15C6534", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F00AA8]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2029997]) = v35;\nL_0018:\n\treturn \"appRuntimeAppRunning\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetEventName()
		{
			return "appRuntimeAppRunning";
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x15C657C", Offset = "0x15C657C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Common.MiniJSON.Json+Serializer::Serialize(this._params);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetParams()
		{
			return Json.Serializer.Serialize(_params);
		}
	}
}
