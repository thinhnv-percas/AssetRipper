using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine.UDP.Analytics.Events;

namespace UnityEngine.UDP.Analytics
{
	[Token(Token = "0x2000029")]
	public class UdpAnalytics
	{
		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x15C6B5C", Offset = "0x15C6B5C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EEDC88]);\n\tv35 = *([v34 @ X8_v7]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, price, currency, receipt, cpOrderId, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20299A8]) = v50;\nL_001B:\n\tv51 = UnityEngine.UDP.Analytics.AnalyticsClient::GetSessionId();\n\tv53 = System.String::IsNullOrEmpty(v51);\n\tv55 = v53 == 0;\n\tif (v55) goto L_0025;\n\tgoto L_0042;\nL_0025:\n\tv59 = System.String::IsNullOrEmpty(v48);\n\tv74 = v59 == 0;\n\tif (v74) goto L_002E;\n\tgoto L_0042;\nL_002E:\n\tv90 = new UnityEngine.UDP.Analytics.Events.TransactionEvent();\n\tUnityEngine.UDP.Analytics.Events.TransactionEvent::.ctor(v90, cpOrderId, v48, currency, price, receipt);\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(v90);\nL_0042:\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AnalyticsResult Transaction(string productionId, string price, string currency, string receipt, string cpOrderId)
		{
			string sessionId = AnalyticsClient.GetSessionId();
			if (string.IsNullOrEmpty(sessionId))
			{
				return AnalyticsResult.kNotInitialized;
			}
			string text = default(string);
			if (string.IsNullOrEmpty(text))
			{
				return AnalyticsResult.kInvalidData;
			}
			TransactionEvent e = new TransactionEvent(cpOrderId, text, currency, price, receipt);
			EventDispatcher.DispatchEvent(e);
			return default(AnalyticsResult);
		}

		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x15C6C60", Offset = "0x15C6C60", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED6308]);\n\tv27 = *([v26 @ X8_v7]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, cpOrderId, reason, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20299A9]) = v44;\nL_0017:\n\tv45 = UnityEngine.UDP.Analytics.AnalyticsClient::GetSessionId();\n\tv47 = System.String::IsNullOrEmpty(v45);\n\tv49 = v47 == 0;\n\tif (v49) goto L_0021;\n\tgoto L_003A;\nL_0021:\n\tv53 = System.String::IsNullOrEmpty(v42);\n\tv64 = v53 == 0;\n\tif (v64) goto L_002A;\n\tgoto L_003A;\nL_002A:\n\tv78 = new UnityEngine.UDP.Analytics.Events.TransactionFailedEvent();\n\tUnityEngine.UDP.Analytics.Events.TransactionFailedEvent::.ctor(v78, cpOrderId, v42, reason);\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(v78);\nL_003A:\n\treturn returnVal1;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AnalyticsResult TransactionFailed(string productionId, string cpOrderId, string reason)
		{
			string sessionId = AnalyticsClient.GetSessionId();
			if (string.IsNullOrEmpty(sessionId))
			{
				return AnalyticsResult.kNotInitialized;
			}
			string text = default(string);
			if (string.IsNullOrEmpty(text))
			{
				return AnalyticsResult.kInvalidData;
			}
			TransactionFailedEvent e = new TransactionFailedEvent(cpOrderId, text, reason);
			EventDispatcher.DispatchEvent(e);
			return default(AnalyticsResult);
		}

		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x15C6D10", Offset = "0x15C6D10", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB61E0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, uuid, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20299AA]) = v41;\nL_0015:\n\tv42 = UnityEngine.UDP.Analytics.AnalyticsClient::GetSessionId();\n\tv44 = System.String::IsNullOrEmpty(v42);\n\tv46 = v44 == 0;\n\tif (v46) goto L_001F;\n\tgoto L_0036;\nL_001F:\n\tv50 = System.String::IsNullOrEmpty(v39);\n\tv59 = v50 == 0;\n\tif (v59) goto L_0028;\n\tgoto L_0036;\nL_0028:\n\tv72 = new UnityEngine.UDP.Analytics.Events.PurchaseAttemptEvent();\n\tUnityEngine.UDP.Analytics.Events.PurchaseAttemptEvent::.ctor(v72, v39, uuid);\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(v72);\nL_0036:\n\treturn returnVal1;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static AnalyticsResult PurchaseAttempt(string productionId, string uuid)
		{
			string sessionId = AnalyticsClient.GetSessionId();
			if (string.IsNullOrEmpty(sessionId))
			{
				return AnalyticsResult.kNotInitialized;
			}
			string text = default(string);
			if (string.IsNullOrEmpty(text))
			{
				return AnalyticsResult.kInvalidData;
			}
			PurchaseAttemptEvent e = new PurchaseAttemptEvent(text, uuid);
			EventDispatcher.DispatchEvent(e);
			return default(AnalyticsResult);
		}

		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x15C6C48", Offset = "0x15C6C48", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.UDP.Analytics.EventDispatcher::DispatchEvent(e);\n\treturn 0;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static AnalyticsResult dispatchEvent(object e)
		{
			EventDispatcher.DispatchEvent(e);
			return default(AnalyticsResult);
		}

		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x15C6C24", Offset = "0x15C6C24", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = UnityEngine.UDP.Analytics.AnalyticsClient::GetSessionId();\n\tv9 = System.String::IsNullOrEmpty(v6);\n\tv10 = ~v9;\n\treturn v10;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool isInitialized()
		{
			string sessionId = AnalyticsClient.GetSessionId();
			bool flag = string.IsNullOrEmpty(sessionId);
			return !flag;
		}
	}
}
