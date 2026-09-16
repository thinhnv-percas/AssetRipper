using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757198", Offset = "0x757198")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x757198", Offset = "0x757198")]
	[Token(Token = "0x2000218")]
	public class GUILayoutBeginCentered : FsmStateAction
	{
		[Token(Token = "0x6000ABF")]
		[Address(RVA = "0xB794F4", Offset = "0xB794F4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Reset()
		{
		}

		[Token(Token = "0x6000AC0")]
		[Address(RVA = "0xB794F8", Offset = "0xB794F8", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EC6D48]);\n\tv19 = *([v18 @ X8_v43]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202294B]) = v39;\nL_0017:\n\tv44 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0020;\n\tv49 = v44;\n\tv50 = 0x8907BC(v49, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv53 = *([v44 @ X19_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0020:\n\tv54 = *([v44 @ X19_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv55 = v54 == 0;\n\tif (v55) goto L_0041;\n\tv57 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_002D;\n\tv79 = v57;\n\tv80 = 0x8907BC(v79, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002D:\n\tv81 = *([v57 @ X19_v16 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv67 = ~v81;\n\tif (v67) goto L_0041;\n\tgoto L_0041;\n\tv92 = v72;\n\tv93 = 0x8907BC(v92, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0041:\n\tgoto L_0047;\n\tv82 = v74;\n\tv83 = 0x8907BC(v82, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0047:\n\tUnityEngine.GUILayout::BeginVertical(v85.Value);\n\tUnityEngine.GUILayout::FlexibleSpace();\n\tv98 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0055;\n\tv103 = v98;\n\tv104 = 0x8907BC(v103, v86, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv107 = *([v98 @ X19_v5 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_0055:\n\tv108 = *([v98 @ X19_v5 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv109 = v108 == 0;\n\tif (v109) goto L_0076;\n\tv111 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0062;\n\tv133 = v111;\n\tv134 = 0x8907BC(v133, v86, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0062:\n\tv135 = *([v111 @ X19_v14 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv121 = ~v135;\n\tif (v121) goto L_0076;\n\tgoto L_0076;\n\tv146 = v126;\n\tv147 = 0x8907BC(v146, v86, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0076:\n\tgoto L_007C;\n\tv136 = v128;\n\tv137 = 0x8907BC(v136, v86, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007C:\n\tUnityEngine.GUILayout::BeginHorizontal(v139.Value);\n\tUnityEngine.GUILayout::FlexibleSpace();\n\tv152 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_008A;\n\tv157 = v152;\n\tv158 = 0x8907BC(v157, v140, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv161 = *([v152 @ X19_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]);\nL_008A:\n\tv162 = *([v152 @ X19_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]) & 0x200;\n\tv163 = v162 == 0;\n\tif (v163) goto L_00AB;\n\tv165 = Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>;\n\tgoto L_0097;\n\tv187 = v165;\n\tv188 = 0x8907BC(v187, v140, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0097:\n\tv189 = *([v165 @ X19_v12 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]) == 0;\n\tv175 = ~v189;\n\tif (v175) goto L_00AB;\n\tgoto L_00AB;\n\tv204 = v180;\n\tv205 = 0x8907BC(v204, v140, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00AB:\n\tgoto L_00B7;\n\tv190 = v182;\n\tv191 = 0x8907BC(v190, v140, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00B7:\n\tUnityEngine.GUILayout::BeginVertical(v193.Value);\n\treturn;\n// 110 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X19_v2 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X19_v16 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginVertical();
			GUILayout.FlexibleSpace();
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X19_v5 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v111 @ X19_v14 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			IntPtr intPtr5 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X19_v8 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X19_v12 (Il2CppClass<System.EmptyArray`1<UnityEngine.GUILayoutOption>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			GUILayout.BeginVertical();
		}

		[Token(Token = "0x6000AC1")]
		[Address(RVA = "0xB796F4", Offset = "0xB796F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutBeginCentered()
		{
		}
	}
}
