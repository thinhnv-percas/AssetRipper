using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000018")]
public class EventDispatcher : SingletonMono<EventDispatcher>
{
	[Token(Token = "0x400003F")]
	[FieldOffset(Offset = "0x20")]
	private Dictionary<EventID, List<Action<Component, object>>> _listenersDict;

	[Token(Token = "0x600008B")]
	[Address(RVA = "0xBFA6C4", Offset = "0xBFA6C4", Length = "0x1D8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv120 = Il2CppMethodInfo;\n\tv121 = \"il2cpp_codegen_initialize_runtime_metadata\"(v120, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv189 = Il2CppMethodInfo;\n\tv190 = \"il2cpp_codegen_initialize_runtime_metadata\"(v189, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv194 = System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v194, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A355DA]) = v40;\nL_002A:\n\tv50 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::ContainsKey(this._listenersDict, eventID);\n\tv123 = v50 == 0;\n\tif (v123) goto L_005C;\n\tv100 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::get_Item(this._listenersDict, eventID);\n\tv112 = v100._items;\n\tv83 = v100._version + 1;\n\tv100._version = v83;\n\tv157 = v100._size;\n\tv201 = v100._size < v112.Length;\n\tv153 = ~v201;\n\tif (v153) goto L_009F;\n\tv159 = v100._size + 1;\n\tv100._size = v159;\n\tv112[v157 @ X10_v7 (System.Int32)] = callback;\n\treturn;\nL_005C:\n\tv101 = new System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>();\n\tSystem.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>::.ctor(v101);\n\tv114 = v101._items;\n\tv84 = v101._version + 1;\n\tv101._version = v84;\n\tv85 = v101._size;\n\tv202 = v101._size < v114.Length;\n\tv77 = ~v202;\n\tif (v77) goto L_0084;\n\tv204 = v101._size + 1;\n\tv101._size = v204;\n\tv114[v85 @ X10_v4 (System.Int32)] = callback;\n\tgoto L_0093;\nL_0084:\n\tSystem.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>::AddWithResize(v101, callback);\nL_0093:\n\tSystem.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::Add(this._listenersDict, eventID, v101);\n\treturn;\nL_009F:\n\tSystem.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>::AddWithResize(v100, callback);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void RegisterListener(EventID eventID, Action<Component, object> callback)
	{
		if (_listenersDict.ContainsKey(eventID))
		{
			List<Action<Component, object>> list = _listenersDict[eventID];
			Action<Component, object>[] items = list._items;
			int version = list._version + 1;
			list._version = version;
			int count = list.Count;
			if (list.Count < items.Length)
			{
				int size = list.Count + 1;
				list._size = size;
				items[count] = callback;
			}
			else
			{
				list.Add(callback);
			}
			return;
		}
		List<Action<Component, object>> list2 = new List<Action<Component, object>>();
		Action<Component, object>[] items2 = list2._items;
		int version2 = list2._version + 1;
		list2._version = version2;
		int count2 = list2.Count;
		if (list2.Count < items2.Length)
		{
			int size2 = list2.Count + 1;
			list2._size = size2;
			items2[count2] = callback;
		}
		else
		{
			list2.Add(callback);
		}
		_listenersDict.Add(eventID, list2);
	}

	[Token(Token = "0x600008C")]
	[Address(RVA = "0xBFA89C", Offset = "0xBFA89C", Length = "0x264")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, eventID, sender, param, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, eventID, sender, param, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv80 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, eventID, sender, param, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A355DB]) = v55;\nL_002B:\n\tv68 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::TryGetValue(this._listenersDict, eventID, &v65 @ stack_-68_v5 (System.Object));\n\tv82 = v68 == 0;\n\tif (v82) goto L_00C4;\n\tv150 = *([v65 @ stack_-68_v5 (System.Object)+18]) < 1;\n\tif (v150) goto L_00C4;\n\tv290 = v65 == 0;\n\tif (v290) goto L_0068;\nL_004E:\n\tv298 = System.Collections.Generic.List`1<System.Object>::get_Item(v294, v139);\n\tv135 = v298 == 0;\n\tif (v135) goto L_006A;\n\tv247 = *([v298 @ X0_v20+28]);\n\t*([v298 @ X0_v20+18])(v184, *([v298 @ X0_v20+40]), sender, param, *([v298 @ X0_v20+28]), methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0058:\n\tv139 = v139 + 1;\n\tv151 = v139 >= *([v65 @ stack_-68_v5 (System.Object)+18]);\n\tif (v151) goto L_00C4;\n\tv304 = v65 == 0;\n\tv297 = ~v304;\n\tif (v297) goto L_004E;\nL_0068:\n\tv279 = new System.NullReferenceException();\n\tgoto L_00CF;\nL_006A:\n\tthrow System.NullReferenceException;\n\tgoto L_006E;\n\tgoto L_006E;\nL_006E:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tstack[0] = X0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_00D2;\n\tX0 = stack[0];\n\tX0 = 0x1854E70(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tstack[0] = X0;\n\tX0 = *([19352D8]);\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = stack[0];\n\tX8 = *([X8]);\n\tX1 = *([X8]);\n\tX0 = 0xAD9AE8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00C7;\n\tX8 = stack[0];\n\tX8 = *([X8]);\n\tstack[0] = X8;\n\tX0 = 0x1854E80(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X25;\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0092;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0092:\n\tX0 = stack[0];\n\tX1 = 0;\n\tUnityEngine.Debug::LogException(X0, X1);\n\tX8 = stack[8];\n\tstack[0] = X8;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X26;\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX2 = X0;\n\tX0 = stack[0];\n\tX1 = X23;\n\tSystem.Collections.Generic.List`1<System.Object>::RemoveAt(X0, X1, X2);\n\tX8 = stack[8];\n\tstack[0] = X8;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X27;\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = stack[0];\n\tX8 = *([X8+18]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B4;\n\tX8 = *([X22+20]);\n\tstack[0] = X8;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX0 = X28;\n\tX0 = 0xAD94AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX2 = X0;\n\tX0 = stack[0];\n\tX1 = X21;\n\tX0 = System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>::Remove(X0, X1, X2);\nL_00B4:\n\tX29 = X29 - 1;\n\tX23 = X23 - 1;\n\tgoto L_0058;\nL_00C4:\n\treturn;\n\tthrow System.NullReferenceException;\nL_00C7:\n\tv141 = 0x1854E90(8, v127, v130, v125, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv204 = *([v203 @ stack_-70]);\n\t*([v141 @ X0_v10]) = v204;\n\tv206 = 0x185A000 + 0xF88;\n\tv208 = 0x1854EA0(v141, v206, 0, v125, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00CF:\n\tgoto L_00D1;\nL_00D1:\n\tv291 = 0x1854E80(v279, v249, v253, v247, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00D2:\n\t;\n\tv301 = 0xBD3CD0(v279, v249, v253, v247, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv255 = 0x9DACB4(v301, v249, v253, v247, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\treturn;\n// 104 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe void PostEvent(EventID eventID, Component sender, object param = null)
	{
		//IL_0119: Expected I4, but got O
		object value;
		if (!_listenersDict.TryGetValue(eventID, out *(List<Action<Component, object>>*)(&value)))
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ stack_-68_v5 (System.Object)+18]");
		if ((nint)0 < (nint)1)
		{
			return;
		}
		bool flag = value == null;
		object obj = value;
		int num = 0;
		nint num2 = 0;
		System.Int32Enum int32Enum = (System.Int32Enum)eventID;
		object obj2 = value;
		if (!flag)
		{
			bool flag3;
			do
			{
				object obj3 = ((List<object>)obj)[num];
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v298 @ X0_v20+28]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v298 @ X0_v20+18] (should have been resolved before IL gen)");
					num++;
					int num3 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ stack_-68_v5 (System.Object)+18]");
					if ((nint)num3 < (nint)0)
					{
						bool flag2 = value == null;
						flag3 = !flag2;
						obj = value;
						int32Enum = (System.Int32Enum)sender;
						obj2 = param;
						continue;
					}
					return;
				}
				throw new NullReferenceException();
			}
			while (flag3);
		}
		NullReferenceException ex = new NullReferenceException();
		Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BD3CD0");
		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
	}

	[Token(Token = "0x600008D")]
	[Address(RVA = "0xBFAB00", Offset = "0xBFAB00", Length = "0x10C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv45 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v45, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv78 = Il2CppMethodInfo;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv115 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v115, eventID, callback, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A355DC]) = v40;\nL_0029:\n\tv53 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::TryGetValue(this._listenersDict, eventID, &v50 @ stack_-28_v3 (System.Object));\n\tv81 = v53 == 0;\n\tif (v81) goto L_0055;\n\tv91 = System.Collections.Generic.List`1<System.Object>::Contains(v50, callback);\n\tv93 = v91 == 0;\n\tif (v93) goto L_0055;\n\tv65 = System.Collections.Generic.List`1<System.Object>::Remove(v50, callback);\n\tv120 = *([v50 @ stack_-28_v3 (System.Object)+18]) == 0;\n\tv94 = ~v120;\n\tif (v94) goto L_0055;\n\tv90 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::Remove(this._listenersDict, eventID);\nL_0055:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public unsafe void RemoveListener(EventID eventID, Action<Component, object> callback)
	{
		object value;
		if (_listenersDict.TryGetValue(eventID, out *(List<Action<Component, object>>*)(&value)) && ((List<object>)value).Contains((object)callback))
		{
			bool flag = ((List<object>)value).Remove((object)callback);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ stack_-28_v3 (System.Object)+18]");
			if ((nint)0 == 0)
			{
				bool flag2 = _listenersDict.Remove(eventID);
			}
		}
	}

	[Token(Token = "0x600008E")]
	[Address(RVA = "0xBFAC0C", Offset = "0xBFAC0C", Length = "0x264")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0038;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv143 = Il2CppMethodInfo;\n\tv144 = \"il2cpp_codegen_initialize_runtime_metadata\"(v143, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv149 = Il2CppMethodInfo;\n\tv150 = \"il2cpp_codegen_initialize_runtime_metadata\"(v149, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv214 = Il2CppMethodInfo;\n\tv215 = \"il2cpp_codegen_initialize_runtime_metadata\"(v214, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv230 = Il2CppMethodInfo;\n\tv231 = \"il2cpp_codegen_initialize_runtime_metadata\"(v230, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv239 = Il2CppMethodInfo;\n\tv240 = \"il2cpp_codegen_initialize_runtime_metadata\"(v239, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv306 = Il2CppMethodInfo;\n\tv307 = \"il2cpp_codegen_initialize_runtime_metadata\"(v306, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv357 = Il2CppMethodInfo;\n\tv358 = \"il2cpp_codegen_initialize_runtime_metadata\"(v357, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv362 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v362, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A355DD]) = v50;\nL_0038:\n\tv56 = this._listenersDict == 0;\n\tif (v56) goto L_00A6;\n\tv75 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::GetEnumerator(this._listenersDict);\nL_0051:\n\tv193 = System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::MoveNext(&v74 @ stack_-B8_v3 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>));\n\tv217 = v193 == 0;\n\tif (v217) goto L_0095;\n\tv254 = *([v232 @ stack_-78+18]);\n\tv176 = *([v232 @ stack_-78+18]) < 1;\n\tv245 = *([v232 @ stack_-78+18]) - 1;\n\tif (v176) goto L_0051;\nL_0068:\n\tv317 = System.Collections.Generic.List`1<System.Object>::get_Item(v232, v245);\n\tv359 = v317 == 0;\n\tif (v359) goto L_0079;\n\tv363 = *([v317 @ X0_v29+20]);\n\tv376 = *([v363 @ X0_v38]);\n\t*([v376 @ X8_v16+138])(v372, v363, 0, *([v376 @ X8_v16+140]), v34, v35, v36, v37, v38, v74, v145, v41, v42, v43, v44, v45, v46);\n\tv380 = v372 & 1;\n\tv374 = v380 == 0;\n\tif (v374) goto L_008F;\nL_0079:\n\tSystem.Collections.Generic.List`1<System.Object>::RemoveAt(v232, v245);\n\tv383 = *([v232 @ stack_-78+18]) == 0;\n\tv384 = ~v383;\n\tif (v384) goto L_0084;\n\tv397 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::Remove(this._listenersDict, v145);\nL_0084:\n\tv386 = v254 - 2;\nL_008F:\n\tv245 = v386 - 1;\n\tv152 = v386 >= 1;\n\tif (v152) goto L_0068;\n\tgoto L_0051;\nL_0095:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::Dispose(&v74 @ stack_-B8_v3 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>));\nL_00A2:\n\treturn;\n\tv381 = new System.NullReferenceException();\n\tv257 = new System.NullReferenceException();\n\tv134 = new System.NullReferenceException();\nL_00A6:\n\tv141 = new System.NullReferenceException();\n\tgoto L_00B8;\n\tgoto L_00B8;\n\tgoto L_00B8;\n\tgoto L_00B8;\n\tgoto L_00B8;\n\tgoto L_00B8;\n\tgoto L_00B8;\nL_00B8:\n\tv212 = v129 != 1;\n\tif (v212) goto L_00C6;\n\tv219 = 0x1854E70(v141, v129, v82, v34, v35, v36, v37, v38, v74, v145, v41, v42, v43, v44, v45, v46);\n\tv235 = 0x1854E80(v219, v129, v82, v34, v35, v36, v37, v38, v74, v145, v41, v42, v43, v44, v45, v46);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::Dispose(&v118 @ stack_-90_v2 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>));\n\tv225 = *([v219 @ X0_v14]) == 0;\n\tif (v225) goto L_00A2;\n\tthrow System.OutOfMemoryException;\nL_00C6:\n\tgoto L_00CA;\n\tX19 = X0;\nL_00CA:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>::Dispose(&v118 @ stack_-90_v2 (System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Object>+Enumerator<System.Int32Enum, System.Object>));\n\tgoto L_00D1;\n\tv352 = 0xBD3CD0(v141, *([v126 @ X23_v1 (Il2CppMethodInfo)]), v82, v34, v35, v36, v37, v38, v74, v145, v41, v42, v43, v44, v45, v46);\nL_00D1:\n\tv355 = new System.OutOfMemoryException();\n\tv346 = 0x9DACB4(v355, *([v126 @ X23_v1 (Il2CppMethodInfo)]), v82, v34, v35, v36, v37, v38, v74, v145, v41, v42, v43, v44, v45, v46);\n\treturn;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void RemoveRedundancies()
	{
		//IL_00a2: Expected O, but got I
		bool flag = _listenersDict == null;
		Dictionary<System.Int32Enum, object>.Enumerator enumerator2 = default(Dictionary<System.Int32Enum, object>.Enumerator);
		Dictionary<System.Int32Enum, object>.Enumerator enumerator = enumerator2;
		nint num = 0;
		if (!flag)
		{
			Dictionary<EventID, List<Action<Component, object>>>.Enumerator enumerator3 = _listenersDict.GetEnumerator();
			object obj2 = default(object);
			object obj5 = default(object);
			System.Int32Enum key = default(System.Int32Enum);
			while (enumerator2.MoveNext())
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ stack_-78+18]");
				int num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ stack_-78+18]");
				bool flag2 = (nint)0 < (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ stack_-78+18]");
				int num3 = (int)(-1);
				if (flag2)
				{
					continue;
				}
				bool flag5;
				do
				{
					object obj = ((List<object>)obj2)[num3];
					int num5;
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X0_v29+20]");
						object obj3 = 0;
						object obj4 = obj3;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v376 @ X8_v16+138] (should have been resolved before IL gen)");
						int num4 = (int)((nint)obj5 & 1);
						bool flag3 = num4 == 0;
						num5 = num3;
						if (flag3)
						{
							goto IL_0277;
						}
					}
					((List<object>)obj2).RemoveAt(num3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ stack_-78+18]");
					if ((nint)0 == 0)
					{
						bool flag4 = _listenersDict.Remove((EventID)key);
					}
					num5 = num2 - 2;
					goto IL_0277;
					IL_0277:
					num3 = num5 - 1;
					flag5 = num5 >= 1;
					num2 = num5;
				}
				while (flag5);
			}
			enumerator2.Dispose();
			return;
		}
		NullReferenceException ex = new NullReferenceException();
		IntPtr intPtr = default(IntPtr);
		if (intPtr == (IntPtr)1)
		{
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
			Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
			enumerator.Dispose();
			object obj6 = default(object);
			if (obj6 != null)
			{
				throw new OutOfMemoryException();
			}
		}
		else
		{
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9DACB4");
		}
	}

	[Token(Token = "0x600008F")]
	[Address(RVA = "0xBFAE70", Offset = "0xBFAE70", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A355DE]) = v33;\nL_001A:\n\tSystem.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::Clear(this._listenersDict);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void ClearAllListener()
	{
		_listenersDict.Clear();
	}

	[Token(Token = "0x6000090")]
	[Address(RVA = "0xBFAEC0", Offset = "0xBFAEC0", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A355DF]) = v33;\nL_001A:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::get_Count(this._listenersDict);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public int ListenerCount()
	{
		return _listenersDict.Count;
	}

	[Token(Token = "0x6000091")]
	[Address(RVA = "0xBFAF10", Offset = "0xBFAF10", Length = "0xB4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv52 = System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv64 = SingletonMono`1<EventDispatcher>;\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A355E0]) = v46;\nL_0025:\n\tv50 = new System.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>();\n\tSystem.Collections.Generic.Dictionary`2<EventID, System.Collections.Generic.List`1<System.Action`2<UnityEngine.Component, System.Object>>>::.ctor(v50);\n\tthis._listenersDict = v50;\n\tgoto L_0039;\n\tv65 = \"il2cpp_codegen_runtime_class_init\"(v59, v54, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0039:\n\tSingletonMono`1<EventDispatcher>::.ctor(this);\n\treturn;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public EventDispatcher()
	{
		Dictionary<EventID, List<Action<Component, object>>> listenersDict = new Dictionary<EventID, List<Action<Component, object>>>();
		_listenersDict = listenersDict;
		base._002Ector();
	}
}
