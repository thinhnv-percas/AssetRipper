using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000019")]
public static class EventDispatcherExtension
{
	[Token(Token = "0x6000092")]
	[Address(RVA = "0xBFAFC4", Offset = "0xBFAFC4", Length = "0x88")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv49 = SingletonMono`1<EventDispatcher>;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv41 = 1;\n\t*([1A355E1]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0021:\n\tv53 = SingletonMono`1<EventDispatcher>::get_Instance();\n\tEventDispatcher::RegisterListener(v53, eventID, callback);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void RegisterListener(this MonoBehaviour sender, EventID eventID, Action<Component, object> callback)
	{
		EventDispatcher instance = SingletonMono<EventDispatcher>.Instance;
		instance.RegisterListener(eventID, callback);
	}

	[Token(Token = "0x6000093")]
	[Address(RVA = "0xBFB04C", Offset = "0xBFB04C", Length = "0x90")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, eventID, param, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = SingletonMono`1<EventDispatcher>;\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, eventID, param, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A355E2]) = v44;\nL_0020:\n\tgoto L_0023;\n\tv53 = \"il2cpp_codegen_runtime_class_init\"(v45, eventID, param, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0023:\n\tv56 = SingletonMono`1<EventDispatcher>::get_Instance();\n\tEventDispatcher::PostEvent(v56, eventID, sender, param);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void PostEvent(this MonoBehaviour sender, EventID eventID, object param)
	{
		EventDispatcher instance = SingletonMono<EventDispatcher>.Instance;
		instance.PostEvent(eventID, sender, param);
	}

	[Token(Token = "0x6000094")]
	[Address(RVA = "0xBFB0DC", Offset = "0xBFB0DC", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, eventID, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv49 = SingletonMono`1<EventDispatcher>;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, eventID, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv41 = 1;\n\t*([1A355E3]) = v41;\nL_001E:\n\tgoto L_0021;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, eventID, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv53 = SingletonMono`1<EventDispatcher>::get_Instance();\n\tEventDispatcher::PostEvent(v53, eventID, sender, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static void PostEvent(this MonoBehaviour sender, EventID eventID)
	{
		EventDispatcher instance = SingletonMono<EventDispatcher>.Instance;
		instance.PostEvent(eventID, sender);
	}
}
