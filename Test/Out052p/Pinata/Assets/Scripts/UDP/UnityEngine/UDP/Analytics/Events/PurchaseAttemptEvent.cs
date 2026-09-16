using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Common.MiniJSON;

namespace UnityEngine.UDP.Analytics.Events
{
	[Token(Token = "0x200002F")]
	internal class PurchaseAttemptEvent : AndroidJavaProxy
	{
		[Token(Token = "0x4000092")]
		private const string EVENT_NAME = "appRuntimePurchaseAttempt";

		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<string, object> _params;

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x15C6624", Offset = "0x15C6624", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ED47B0]);\n\tv27 = *([v26 @ X8_v26]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, productId, uuid, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202999C]) = v44;\nL_001D:\n\tgoto L_0028;\n\tv51 = *([v47 @ X0_v2+E0]);\n\tv52 = v51 == 0;\n\tv53 = ~v52;\n\tgoto L_0028;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v47, productId, uuid, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0028:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.internal.analytics.IEvent\");\n\tgoto L_0039;\n\tv68 = *([1F0B328]);\n\tv69 = *([v68 @ X8_v22]);\n\tv70 = \"il2cpp_codegen_initialize_method\"(v69, v62, v61, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv73 = 0 | 1;\n\t*([20299F8]) = v73;\nL_0039:\n\tv79 = UnityEngine.UDP.Analytics.Common::GetCommonParams(v77.m_sessionInfo);\n\tthis._params = v79;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v79, \"product_id\", productId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this._params, \"cp_order_id\", uuid);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public PurchaseAttemptEvent(string productId, string uuid)
			: base("com.unity.udp.sdk.internal.analytics.IEvent")
		{
			(_params = Common.GetCommonParams(AnalyticsClient.m_sessionInfo)).Add("product_id", productId);
			_params.Add("cp_order_id", uuid);
		}

		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x15C6730", Offset = "0x15C6730", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EE07A0]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202999D]) = v35;\nL_0018:\n\treturn \"appRuntimePurchaseAttempt\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetEventName()
		{
			return "appRuntimePurchaseAttempt";
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x15C6778", Offset = "0x15C6778", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Common.MiniJSON.Json+Serializer::Serialize(this._params);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetParams()
		{
			return Json.Serializer.Serialize(_params);
		}
	}
}
