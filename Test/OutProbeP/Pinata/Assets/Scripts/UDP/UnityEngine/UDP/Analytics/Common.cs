using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.UDP.Analytics
{
	[Token(Token = "0x2000024")]
	internal class Common
	{
		[Token(Token = "0x60000B5")]
		[Address(RVA = "0x15C626C", Offset = "0x15C626C", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = &v11 @ stack_-10_v2;\n\tgoto L_0017;\n\tv20 = *([1ECCDC0]);\n\tv21 = *([v20 @ X8_v33]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2029991]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v44);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"client_id\", sessionInfo.m_ClientId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"device_id\", sessionInfo.m_DeviceId);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"event_type\", \"runtime\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"platform\", sessionInfo.m_Platform);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"system_info\", sessionInfo.m_SystemInfo);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"sdk_dist\", \"unityiap\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"target_store\", sessionInfo.m_TargetStore);\n\tv132 = &v11 @ stack_-10_v2 - 0x14;\n\t*([v10 @ X29_v1-14]) = sessionInfo.m_Vr;\n\t// 94 Box v134 @ X0_v14 (System.Object), typeof(System.Boolean), v132 @ X1_v9\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"vr\", v134);\n\tv141 = UnityEngine.UDP.Analytics.PlatformWrapper::GetCurrentMillisecondsInUTC();\n\t// 109 Box v147 @ X0_v18 (System.Object), typeof(System.UInt64), &v141 @ X0_v16 (System.UInt64)\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"ts\", v147);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v44, \"source\", \"sdk\");\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Dictionary<string, object> GetCommonParams(SessionInfo sessionInfo)
		{
			//IL_00c4: Expected O, but got I
			//IL_00d7: Expected I4, but got O
			object obj2 = default(object);
			object obj = obj2;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("client_id", sessionInfo.MClientId);
			dictionary.Add("device_id", sessionInfo.MDeviceId);
			dictionary.Add("event_type", "runtime");
			dictionary.Add("platform", sessionInfo.MPlatform);
			dictionary.Add("system_info", sessionInfo.MSystemInfo);
			dictionary.Add("sdk_dist", "unityiap");
			dictionary.Add("target_store", sessionInfo.MTargetStore);
			object obj3 = (long)(IntPtr)obj2 - 20L;
			_ = sessionInfo.MVr;
			object value = (byte)(int)obj3 != 0;
			dictionary.Add("vr", value);
			ulong currentMillisecondsInUTC = PlatformWrapper.GetCurrentMillisecondsInUTC();
			object value2 = currentMillisecondsInUTC;
			dictionary.Add("ts", value2);
			dictionary.Add("source", "sdk");
			return dictionary;
		}
	}
}
