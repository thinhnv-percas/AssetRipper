using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Common.MiniJSON;

namespace UnityEngine.UDP.Analytics.Events
{
	[Token(Token = "0x2000031")]
	internal class TransactionFailedEvent : AndroidJavaProxy
	{
		[Token(Token = "0x4000096")]
		private const string EVENT_NAME = "appRuntimeFailedTransaction";

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<string, object> _params;

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x15C6958", Offset = "0x15C6958", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EF9450]);\n\tv31 = *([v30 @ X8_v28]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, cpOrderId, productId, reason, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20299A0]) = v47;\nL_001F:\n\tgoto L_002A;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_002A;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, cpOrderId, productId, reason, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002A:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.internal.analytics.IEvent\");\n\tgoto L_003B;\n\tv71 = *([1F0B328]);\n\tv72 = *([v71 @ X8_v24]);\n\tv73 = \"il2cpp_codegen_initialize_method\"(v72, v65, v64, reason, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv76 = 0 | 1;\n\t*([20299F8]) = v76;\nL_003B:\n\tv82 = UnityEngine.UDP.Analytics.Common::GetCommonParams(v80.m_sessionInfo);\n\tthis._params = v82;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v82, \"cp_order_id\", cpOrderId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this._params, \"product_id\", productId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this._params, \"reason\", reason);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransactionFailedEvent(string cpOrderId, string productId, string reason)
			: base("com.unity.udp.sdk.internal.analytics.IEvent")
		{
			(_params = Common.GetCommonParams(AnalyticsClient.m_sessionInfo)).Add("cp_order_id", cpOrderId);
			_params.Add("product_id", productId);
			_params.Add("reason", reason);
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x15C6A90", Offset = "0x15C6A90", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE8EE0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20299A1]) = v35;\nL_0018:\n\treturn \"appRuntimeFailedTransaction\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetEventName()
		{
			return "appRuntimeFailedTransaction";
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x15C6AD8", Offset = "0x15C6AD8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Common.MiniJSON.Json+Serializer::Serialize(this._params);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetParams()
		{
			return Json.Serializer.Serialize(_params);
		}
	}
}
