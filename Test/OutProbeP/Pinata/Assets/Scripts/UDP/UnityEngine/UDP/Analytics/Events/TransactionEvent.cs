using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Common.MiniJSON;

namespace UnityEngine.UDP.Analytics.Events
{
	[Token(Token = "0x2000030")]
	internal class TransactionEvent : AndroidJavaProxy
	{
		[Token(Token = "0x4000094")]
		private const string EVENT_NAME = "appRuntimeTransaction";

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x20")]
		private readonly Dictionary<string, object> _params;

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x15C6780", Offset = "0x15C6780", Length = "0x188")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1F08DF0]);\n\tv39 = *([v38 @ X8_v32]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, cpOrderId, productId, currency, price, receipt, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([202999E]) = v53;\nL_0023:\n\tgoto L_002E;\n\tv60 = *([v56 @ X0_v2+E0]);\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tgoto L_002E;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v56, cpOrderId, productId, currency, price, receipt, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_002E:\n\tUnityEngine.AndroidJavaProxy::.ctor(this, \"com.unity.udp.sdk.internal.analytics.IEvent\");\n\tgoto L_003F;\n\tv77 = *([1F0B328]);\n\tv78 = *([v77 @ X8_v28]);\n\tv79 = \"il2cpp_codegen_initialize_method\"(v78, v71, v70, currency, price, receipt, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv82 = 0 | 1;\n\t*([20299F8]) = v82;\nL_003F:\n\tv88 = UnityEngine.UDP.Analytics.Common::GetCommonParams(v86.m_sessionInfo);\n\tthis._params = v88;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v88, \"cp_order_id\", cpOrderId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this._params, \"product_id\", productId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this._params, \"receipt\", receipt);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this._params, \"currency\", currency);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(this._params, \"price\", price);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransactionEvent(string cpOrderId, string productId, string currency, string price, string receipt)
			: base("com.unity.udp.sdk.internal.analytics.IEvent")
		{
			(_params = Common.GetCommonParams(AnalyticsClient.m_sessionInfo)).Add("cp_order_id", cpOrderId);
			_params.Add("product_id", productId);
			_params.Add("receipt", receipt);
			_params.Add("currency", currency);
			_params.Add("price", price);
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x15C6908", Offset = "0x15C6908", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1F08190]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202999F]) = v35;\nL_0018:\n\treturn \"appRuntimeTransaction\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetEventName()
		{
			return "appRuntimeTransaction";
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x15C6950", Offset = "0x15C6950", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.UDP.Common.MiniJSON.Json+Serializer::Serialize(this._params);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public string GetParams()
		{
			return Json.Serializer.Serialize(_params);
		}
	}
}
