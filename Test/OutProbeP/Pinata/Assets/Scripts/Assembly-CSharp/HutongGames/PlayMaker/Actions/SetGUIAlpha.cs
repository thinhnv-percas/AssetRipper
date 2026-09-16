using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756CC0", Offset = "0x756CC0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756CC0", Offset = "0x756CC0")]
	[Token(Token = "0x200020A")]
	public class SetGUIAlpha : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40014CA")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat alpha;

		[Token(Token = "0x40014CB")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool applyGlobally;

		[Token(Token = "0x6000A8D")]
		[Address(RVA = "0x993D30", Offset = "0x993D30", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.alpha = v12;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 1f;
			alpha = fsmFloat;
		}

		[Token(Token = "0x6000A8E")]
		[Address(RVA = "0x993D5C", Offset = "0x993D5C", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1EBB380]);\n\tv27 = *([v26 @ X8_v24]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021743]) = v46;\nL_001D:\n\tgoto L_0024;\n\tv53 = *([v49 @ X0_v2+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_0024;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0024:\n\tv61 = UnityEngine.GUI::get_color();\n\tv67 = UnityEngine.GUI::get_color();\n\tv73 = UnityEngine.GUI::get_color();\n\tv81 = HutongGames.PlayMaker.FsmFloat::get_Value(this.alpha);\n\tv90 = 0;\n\tv111 = 0x101059C(&v90 @ stack_-50_v2, 0, v30, v31, v32, v33, v34, v35, v61, v67.g, v73.b, v81, v40, v41, v42, v43);\n\t// 72 MakeStruct v84 @ AGG993E1C_0_v2 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v112 @ stack_-4C, 0, v113 @ stack_-44\n\tUnityEngine.GUI::set_color(v84);\n\tv150 = HutongGames.PlayMaker.FsmBool::get_Value(this.applyGlobally);\n\tv152 = v150 == 0;\n\tif (v152) goto L_0095;\n\tgoto L_005D;\n\tv176 = *([v153 @ X0_v16+E0]);\n\tv177 = v176 == 0;\n\tv178 = ~v177;\n\tif (v178) goto L_005D;\n\tv180 = \"il2cpp_codegen_runtime_class_init\"(v153, v123, v30, v31, v32, v33, v34, v35, v100, v98, v96, v94, v40, v41, v42, v43);\nL_005D:\n\tv168 = UnityEngine.GUI::get_color();\n\tgoto L_0075;\n\tv189 = *([v185 @ X0_v19+E0]);\n\tv190 = v189 == 0;\n\tv191 = ~v190;\n\tif (v191) goto L_0075;\n\tv193 = \"il2cpp_codegen_runtime_class_init\"(v185, v123, v30, v31, v32, v33, v34, v35, v168, v167, v166, v165, v40, v41, v42, v43);\nL_0075:\n\tgoto L_FFFFFFFF;\n\tv200 = *([1EEB750]);\n\tv201 = *([v200 @ X8_v17]);\n\tv202 = \"il2cpp_codegen_initialize_method\"(v201, v123, v30, v31, v32, v33, v34, v35, v168, v167, v166, v165, v40, v41, v42, v43);\n\tv205 = 0 | 1;\n\t*([2021816]) = v205;\n\tgoto L_0087;\n\tv210 = *([v206 @ X0_v22 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tgoto L_0087;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v206, v123, v30, v31, v32, v33, v34, v35, v168, v167, v166, v165, v40, v41, v42, v43);\n\tv213 = PlayMakerGUI;\nL_0087:\n\tv173 = *([v169 @ X0_v23 (Il2CppClass<PlayMakerGUI>)+B8]);\n\tv173.guiColor = v168;\n\t*([v173 @ X8_v14 (Il2CppStaticFields<PlayMakerGUI>)+44]) = v168.g;\n\t*([v173 @ X8_v14 (Il2CppStaticFields<PlayMakerGUI>)+48]) = v168.b;\n\t*([v173 @ X8_v14 (Il2CppStaticFields<PlayMakerGUI>)+4C]) = v168.a;\nL_0095:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_0042: Expected O, but got I4
			//IL_0071: Expected F4, but got O
			//IL_008c: Expected F4, but got O
			//IL_00f2: Expected I, but got O
			//IL_0100: Expected I, but got O
			Color color = GUI.color;
			Color color2 = GUI.color;
			Color color3 = GUI.color;
			float value = alpha.Value;
			object obj = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color color4 = default(Color);
			color4.r = 0f;
			object obj2 = default(object);
			color4.g = (float)obj2;
			color4.b = 0f;
			object obj3 = default(object);
			color4.a = (float)obj3;
			GUI.color = color4;
			if (applyGlobally.Value)
			{
				Color color5 = GUI.color;
				IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
				IntPtr intPtr2 = (IntPtr)PlayMakerGUI.fsmList;
				PlayMakerGUI.guiColor = color5;
				_ = color5.g;
				_ = color5.b;
				_ = color5.a;
			}
		}

		[Token(Token = "0x6000A8F")]
		[Address(RVA = "0x993EEC", Offset = "0x993EEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetGUIAlpha()
		{
		}
	}
}
